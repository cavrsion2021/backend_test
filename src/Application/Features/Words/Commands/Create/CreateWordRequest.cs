using Anagrama.Api.Application.Features.Words.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama.Api.Application.Features.Words.Commands.Create
{
    public class CreateWordRequest : IRequest<WordDto>, IValidatableObject
    {
        /// <summary>
        /// First word 
        /// </summary>
        /// <example>
        /// Alva
        /// </example>
        [Required(ErrorMessage ="This field is required.")]
        public string FirstWord { get; set; }

        /// <summary>
        /// First word 
        /// </summary>
        /// <example>
        /// Vala
        /// </example>
        [Required(ErrorMessage = "This field is required.")]
        public string SecondWord { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new();




            return errors;
        }
    }


}
