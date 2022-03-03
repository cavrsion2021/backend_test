﻿using Anagrama.Api.Application.Common.Interfaces;
using Anagrama.Api.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anagrama.Api.Application.Common.Abstracts
{
    public abstract class CommandRequestHandler<TRequest, TData> : IRequestHandler<TRequest, CommandResult<TData>> where TRequest : IRequest<CommandResult<TData>>
    {
        private readonly IBaseDbContext _context;

        public CommandRequestHandler(IBaseDbContext context)
        {
            _context = context;
        }

        public virtual async Task<CommandResult<TData>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _context.BeginTransactionAsync();
                TData vm = await HandleCommand(request, cancellationToken);
                await _context.CommitTransactionAsync();

                return CommandResult<TData>.Ok(vm);
            }
            catch (Exception e)
            {
                _context.RollbackTransaction();
                return CommandResult<TData>.Fail(e.Message);
            }
        }

        public abstract Task<TData> HandleCommand(TRequest request, CancellationToken cancellationToken);
    }
}
