using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired();

            this.Property(t => t.LastName)
                .IsRequired();

            this.Property(t => t.fbid)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Contacts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.KeywordsId).HasColumnName("KeywordsId");
            this.Property(t => t.fbid).HasColumnName("fbid");

            // Relationships
            this.HasRequired(t => t.Keyword)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.KeywordsId);

        }
    }
}
