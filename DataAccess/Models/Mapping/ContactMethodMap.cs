using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class ContactMethodMap : EntityTypeConfiguration<ContactMethod>
    {
        public ContactMethodMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Value)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ContactMethods");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.KeywordID).HasColumnName("KeywordID");

            // Relationships
            this.HasRequired(t => t.Contact)
                .WithMany(t => t.ContactMethods)
                .HasForeignKey(d => d.ContactId);
            this.HasRequired(t => t.Keyword)
                .WithMany(t => t.ContactMethods)
                .HasForeignKey(d => d.KeywordID);

        }
    }
}
