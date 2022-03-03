using Anagrama.Api.Application.Common.Exceptions;
using Anagrama.Api.Application.Common.Interfaces;
using Anagrama.Api.Application.Common.Mappings;
using Anagrama.Api.Application.Common.Models;
using Anagrama.Api.Application.Features.Words.Dtos;
using Anagrama.Api.Domain.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anagrama.Api.Application.Features.Words.Queries.GetAll
{
    public class GetAllWordHandler : IRequestHandler<GetAllWordRequest, PaginatedList<WordDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllWordHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<WordDto>> Handle(GetAllWordRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Word> query = from dt in _context.Words select dt;

            if (request.Id != null && request.Id > 0)
                query = query.Where(x => x.Id == request.Id);

            if (!string.IsNullOrEmpty(request.FirstWord))
                query = query.Where(x => x.FirstWord.ToLower().Contains(request.FirstWord.ToLower()));

            if (!string.IsNullOrEmpty(request.SecondWord))
                query = query.Where(x => x.SecondWord.ToLower().Contains(request.SecondWord.ToLower()));

            if (request.IsAnagram != null)
                query = query.Where(x => x.IsAnagram.Equals(request.IsAnagram));

            var vm = await query
                .AsNoTracking()
                .ProjectTo<WordDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            if (vm.Items.Count <= 0)
                throw new NotFoundException("No se encontraron registros");

            return vm;
        }
    }
}
