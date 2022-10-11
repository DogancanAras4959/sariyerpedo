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
    public class ImageFileMapping : IEntityTypeConfiguration<ImageFile>
    {
        public void Configure(EntityTypeBuilder<ImageFile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.folder).HasMaxLength(75);
            builder.HasOne(x => x.sliderImage).WithMany(x => x.imageFileForSliderList).HasForeignKey(x => x.SliderId);
        }
    }
}
