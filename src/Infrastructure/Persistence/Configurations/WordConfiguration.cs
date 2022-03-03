using Anagrama.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrama.Api.Infrastructure.Persistence.Configurations
{
    public partial class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstWord)
                .HasColumnType("Varchar(50)")
                .IsRequired(true);

            builder.Property(x => x.SecondWord)
                .HasColumnType("Varchar(50)")
                .IsRequired(true);

        }
    }
}
