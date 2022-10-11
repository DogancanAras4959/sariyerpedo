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
    public class ImageFileTreatmentMapping : IEntityTypeConfiguration<ImageFileTreatment>
    {
        public void Configure(EntityTypeBuilder<ImageFileTreatment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.folder).HasMaxLength(75);
            builder.HasOne(x => x.treatment).WithMany(x => x.imageFileForTreatmentList).HasForeignKey(x => x.TreatmentId);
        }
    }
}
