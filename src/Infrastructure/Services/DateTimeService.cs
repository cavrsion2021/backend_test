using Anagrama.Api.Application.Common.Interfaces;
using System;

namespace Anagrama.Api.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
