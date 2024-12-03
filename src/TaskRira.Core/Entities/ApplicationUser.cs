using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskRira.Core.Common;

namespace TaskRira.Core.Entities
{
    public class ApplicationUser: BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NationalCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string BirthDate { get; set; }


    }

    public class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUser", "user");
            builder.Property(b => b.Name).HasMaxLength(200);
            builder.Property(b => b.Family).HasMaxLength(300);
            builder.Property(b => b.NationalCode).HasMaxLength(20);
            builder.Property(b => b.BirthDate).HasMaxLength(20);
        }
    }
}
