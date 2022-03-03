using Anagrama.Api.Application.Common.Interfaces;
using Anagrama.Api.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Anagrama.Api.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;
        private IConfiguration _configuration;
        private IWebHostEnvironment _environment;
        private IApplicationDbContext _context;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
        protected IApplicationDbContext Context => _context ??= HttpContext.RequestServices.GetService<IApplicationDbContext>();
        protected IConfiguration Configuration => _configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();
        protected IWebHostEnvironment Env => _environment ??= HttpContext.RequestServices.GetService<IWebHostEnvironment>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Request"></typeparam>
        /// <typeparam name="Response"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual async Task<ActionResult> Command<Request, Response>(Request command) where Request : IRequest<Response>
        {
            //TryValidateModel(command);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await Mediator.Send(command);

            return Ok(result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Request"></typeparam>
        /// <typeparam name="Response"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual async Task<ActionResult> Query<Request, Response>(Request command) where Request : IRequest<Response>
        {
            TryValidateModel(command);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await Mediator.Send(command);

            return Ok(result);
        }

    }
}