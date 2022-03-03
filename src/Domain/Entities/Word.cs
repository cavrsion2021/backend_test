using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama.Api.Domain.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }
        public bool IsAnagram { get; set; }

    }
}
