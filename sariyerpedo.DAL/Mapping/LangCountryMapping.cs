using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.DAL.Mapping
{
    public class LangCountryMapping : IEntityTypeConfiguration<LangCountry>
    {
        public void Configure(EntityTypeBuilder<LangCountry> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.langTitle).HasMaxLength(40);
        }
    }
}
