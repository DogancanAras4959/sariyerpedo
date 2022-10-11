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
    public class TreatmentMapping : IEntityTypeConfiguration<Treatments>
    {
        public void Configure(EntityTypeBuilder<Treatments> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.lang).WithMany(x => x.treatmentList).HasForeignKey(x => x.LangId);
        }
    }
}
