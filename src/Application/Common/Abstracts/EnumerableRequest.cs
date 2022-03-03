using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama.Api.Application.Common.Abstracts
{
    public abstract class EnumerableRequest
    {
        [DefaultValue("1")]
        public int PageNumber { get; set; } = 1;

        [DefaultValue("10")]
        public int PageSize { get; set; } = 10;
    }
}
