using Anagrama.Api.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama.Api.Infrastructure.Services
{
    public class AnagramService : IAnagram
    {
        public async Task<bool> IsAnagram(string FirstWord, string SecondWord)
        {
            char[] FirstWordArray = FirstWord.ToLower().ToCharArray();
            char[] SecondWordArray = SecondWord.ToLower().ToCharArray();

            Array.Sort(FirstWordArray);
            Array.Sort(SecondWordArray);
            
            return new String(FirstWordArray).Trim().Equals(new String(SecondWordArray));
        }
    }
}
