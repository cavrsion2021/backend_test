
using Anagrama.Api.Application.Common.Mappings;
using Anagrama.Api.Domain.Entities;
using AutoMapper;

namespace Anagrama.Api.Application.Features.Words.Dtos
{
    public class WordDto : IMapFrom<Word>
    {
        public int Id { get; set; }
        public string FirstWord { get; set; }
        public string SecondWord { get; set; }
        public bool IsAnagram { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Word, WordDto>();
        }
    }
}
