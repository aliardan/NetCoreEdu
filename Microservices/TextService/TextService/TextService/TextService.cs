using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TextRepository;

namespace TextService.TextService
{
    public class TextService
    {
        private readonly ITextRepository _textRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public TextService(
            ITextRepository textRepository,
            IHttpClientFactory httpClientFactory)
        {
            _textRepository = textRepository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Guid> SaveByUrlAsync(string textName, string url)
        {
            var textId = Guid.NewGuid();
            using var httpClient = _httpClientFactory.CreateClient();
            var content = await httpClient.GetStringAsync(url);
            var text = new TextRepository.Text(content, textName, textId);
            await _textRepository.CreateAsync(text);
            return textId;
        }
        public async Task<Guid> SaveAsync(string textName, string content)
        {
            var textId = Guid.NewGuid();
            var text = new TextRepository.Text(content, textName, textId);
            await _textRepository.CreateAsync(text);
            return textId;
        }

        public async Task<Guid> SaveAsync(string textName, Stream content)
        {
            var textId = Guid.NewGuid();
            using var reader = new StreamReader(content, Encoding.UTF8);
            var stringContent = await reader.ReadToEndAsync();
            var text = new TextRepository.Text(stringContent,textName,textId);
            await _textRepository.CreateAsync(text);
            return textId;
        }

        public async Task<IEnumerable<Text>> GetAllAsync()
        {
            return (await _textRepository.GetAllAsync()).Select(Convert);
        }

        public async Task<Text> GetByIdAsync(Guid id)
        {
          var text = await _textRepository.GetByIdAsync(id);
          return Convert(text);
        }

        private Text Convert(TextRepository.Text text)
        {
            return new Text(text.Content,text.TextName,text.Id);
        }

        private TextRepository.Text Convert(Text text)
        {
            return new TextRepository.Text(text.Content, text.TextName, text.Id);
        }
    }
}
