using Anagrama.Api.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama.Api.Application.Common.Abstracts
{
    public abstract class CommandRequest<TData> : IRequest<CommandResult<TData>>
    {
    }
}
