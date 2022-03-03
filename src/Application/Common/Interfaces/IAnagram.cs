using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama.Api.Application.Common.Interfaces
{
    public interface IAnagram
    {
        Task<bool> IsAnagram(string FirstWord, string SecondWord);
    }
}
