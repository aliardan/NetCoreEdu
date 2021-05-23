using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TextRepository;

namespace TextService.Controllers
{
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly ITextRepository _textRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public TextController(
            IHttpClientFactory httpClientFactory,
            ITextRepository textRepository)
        {
            _textRepository = textRepository;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Create a new text document on the server
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <returns></returns>
        [HttpPost("[controller]")]
        public async Task<ActionResult<Guid>> Save([FromQuery] string fileName)
        {
            using var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string content = await reader.ReadToEndAsync();
            var text = new Text(content, fileName, Guid.NewGuid());
            await _textRepository.CreateAsync(text);
            return new ActionResult<Guid>(text.Id);
        }

        [HttpPost("[controller]/SaveFromString")]
        public async Task<ActionResult<Guid>> SaveFromString([FromQuery] string fileName, [FromQuery] string content)
        {
            var text = new Text(content, fileName, Guid.NewGuid());
            await _textRepository.CreateAsync(text);
            return new ActionResult<Guid>(text.Id);
        }

        [HttpPost("[controller]/SaveFromUrl")]
        public async Task<ActionResult<Guid>> SaveFromUrl([FromQuery] string fileName, [FromQuery] string url)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            var content = await httpClient.GetStringAsync(url);
            var text = new Text(content, fileName, Guid.NewGuid());
            await _textRepository.CreateAsync(text);
            return new ActionResult<Guid>(text.Id);
        }

        [HttpGet("[controller]")]
        public async Task<ActionResult<IEnumerable<Text>>> Get()
        {
            var list = await _textRepository.GetAllAsync();
            var result = new ActionResult<IEnumerable<Text>>(list);
            return result;
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<Text>> GetById([FromRoute][DefaultValue("00000000-0000-0000-0000-00000000000")] Guid id)
        {
            var text = await _textRepository.GetByIdAsync(id);
            var result = new ActionResult<Text>(text);
            return result;
        }
    }
}
