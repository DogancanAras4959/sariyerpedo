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
    public class SliderMapping : IEntityTypeConfiguration<Sliders>
    {
        public void Configure(EntityTypeBuilder<Sliders> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.slogan).HasMaxLength(400);
            builder.Property(x => x.subTitle).HasMaxLength(75);
            builder.Property(x => x.UrlTitle).HasMaxLength(25);
            builder.Property(x => x.title).HasMaxLength(150);
            builder.Property(x => x.url).HasMaxLength(75);
        }
    }
}
