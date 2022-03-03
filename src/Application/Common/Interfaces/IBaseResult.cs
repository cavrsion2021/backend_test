using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama.Api.Application.Common.Interfaces
{
    public interface IBaseResult<TData>
    {
        TData Data { get; set; }
        string Error { get; set; }
        bool Success { get; }
        bool Failure { get; }
    }
}
