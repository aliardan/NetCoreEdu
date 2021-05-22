using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileRepository;
using File = FileRepository.File;

namespace TextService.Controllers
{
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public TextController(
            IHttpClientFactory httpClientFactory,
            IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("[controller]")]
        public async Task<ActionResult<Guid>> Save([FromQuery] string fileName)
        {
            using var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string content = await reader.ReadToEndAsync();
            var file = new File(content, fileName, Guid.NewGuid());
            await _fileRepository.CreateAsync(file);
            return new ActionResult<Guid>(file.Id);
        }

        [HttpPost("[controller]/SaveFromString")]
        public async Task<ActionResult<Guid>> SaveFromString([FromQuery] string fileName, [FromQuery] string content)
        {
            var file = new File(content, fileName, Guid.NewGuid());
            await _fileRepository.CreateAsync(file);
            return new ActionResult<Guid>(file.Id);
        }

        [HttpPost("[controller]/SaveFromUrl")]
        public async Task<ActionResult<Guid>> SaveFromUrl([FromQuery] string fileName, [FromQuery] string url)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            var content = await httpClient.GetStringAsync(url);
            var file = new File(content, fileName, Guid.NewGuid());
            await _fileRepository.CreateAsync(file);
            return new ActionResult<Guid>(file.Id);
        }

        [HttpGet("[controller]")]
        public async Task<ActionResult<IEnumerable<File>>> Get()
        {
            var list = await _fileRepository.GetAllAsync();
            var result = new ActionResult<IEnumerable<File>>(list);
            return result;
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<File>> GetById([FromRoute][DefaultValue("00000000-0000-0000-0000-00000000000")] Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            var result = new ActionResult<File>(file);
            return result;
        }
    }
}
