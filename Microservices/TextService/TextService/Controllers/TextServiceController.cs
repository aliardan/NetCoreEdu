using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TextService.TextService;

namespace TextService.Controllers
{
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly TextService.TextService _textService;

        public TextController(TextService.TextService textService)
        {
            _textService = textService;
        }

        /// <summary>
        /// Create a new text document on the server
        /// </summary>
        /// <param name="textName">The name of the file</param>
        /// <returns></returns>
        [HttpPost("[controller]")]
        public async Task<ActionResult<Guid>> Save([FromQuery] string textName)
        {
            var textId = await _textService.SaveAsync(textName, HttpContext.Request.Body);
            return new ActionResult<Guid>(textId);
        }

        [HttpPost("[controller]/SaveFromString")]
        public async Task<ActionResult<Guid>> SaveFromString([FromQuery] string textName, [FromQuery] string content)
        {
            var textId = await _textService.SaveAsync(textName, content);
            return new ActionResult<Guid>(textId);
        }

        [HttpPost("[controller]/SaveFromUrl")]
        public async Task<ActionResult<Guid>> SaveFromUrl([FromQuery] string textName, [FromQuery] string url)
        {
            var textId = await _textService.SaveByUrlAsync(textName, url);
            return new ActionResult<Guid>(textId);
        }

        [HttpGet("[controller]")]
        public async Task<ActionResult<IEnumerable<Text>>> Get()
        {
            var texts = await _textService.GetAllAsync();
            return new ActionResult<IEnumerable<Text>>(texts);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<Text>> GetById([FromRoute][DefaultValue("00000000-0000-0000-0000-00000000000")] Guid id)
        {
            var text = await _textService.GetByIdAsync(id);
            return new ActionResult<Text>(text);
        }
    }
}
