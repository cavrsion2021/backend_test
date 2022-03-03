using Anagrama.Api.Application.Common.Abstracts;
using Anagrama.Api.Application.Common.Models;
using Anagrama.Api.Application.Features.Words.Dtos;
using MediatR;

namespace Anagrama.Api.Application.Features.Words.Queries.GetAll
{
    /// <summary>
    /// Class for filter Word data
    /// </summary>
    public class GetAllWordRequest : EnumerableRequest, IRequest<PaginatedList<WordDto>>
    {
        /// <summary>
        /// Identification Owner
        /// </summary>
        /// <example>0</example>
        public int? Id { get; set; }
        /// <summary>
        /// Second Word
        /// </summary>
        /// <example>a</example>
        public string FirstWord { get; set; }
        /// <summary>
        /// Second Word
        /// </summary>
        /// <example>a</example>
        public string SecondWord { get; set; }
        /// <summary>
        /// Is Anagram words
        /// </summary>
        /// <example>true</example>
        public bool? IsAnagram { get; set; }
    }
}
