using Anagrama.Api.Application.Common.Interfaces;
using Anagrama.Api.Application.Features.Words.Dtos;
using Anagrama.Api.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anagrama.Api.Application.Features.Words.Commands.Create
{
    public class CreateWordHandler : IRequestHandler<CreateWordRequest, WordDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IAnagram _anagram;
        private readonly IMapper _mapper;
        public CreateWordHandler(IApplicationDbContext context, IAnagram anagram, IMapper mapper)
        {
            _context = context;
            _anagram = anagram;
            _mapper = mapper;
        }

        public async Task<WordDto> Handle(CreateWordRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var IsAnagram = await _anagram.IsAnagram(request.FirstWord, request.SecondWord);

                Word entity = new()
                {
                    FirstWord = request.FirstWord,
                    SecondWord= request.SecondWord,
                    IsAnagram = IsAnagram
                };

                _context.Words.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<WordDto>(entity);
        }



    }
}
