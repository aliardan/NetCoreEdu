using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using TextRepository;

namespace FindService.FindService
{
    public class FindService
    {
        private readonly ITextRepository _textRepository;

        public FindService(ITextRepository textRepository)
        {
            _textRepository = textRepository;
        }

        public async Task<int> Find(Guid id, string[] wordsForSearch)
        {
           var text = await _textRepository.GetByIdAsync(id);
           var textWords = text.Content.Split().ToList();
           int counter = 0;
           var wordsForSearchHashSet = new HashSet<string>(wordsForSearch);

           foreach (var textWord in textWords)
           {
               if (wordsForSearchHashSet.Contains(textWord))
               {
                   counter++;
               }
           }

           return counter;
        }
    }
}
