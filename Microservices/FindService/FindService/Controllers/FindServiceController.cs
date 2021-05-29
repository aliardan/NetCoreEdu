using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FindService.Controllers
{
    [ApiController]
    public class FindServiceController
    {
        private readonly FindService.FindService _findService;
        public FindServiceController(FindService.FindService findService)
        {
            _findService = findService;
        }

        [HttpGet ("[controller]/{id}")]
        public async Task<int> Find([FromRoute]Guid id, [FromQuery]string[] words)
        {
            return await _findService.Find(id, words);
        }
    }
}
