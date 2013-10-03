using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class KeywordMap : EntityTypeConfiguration<Keyword>
    {
        public KeywordMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Keywords");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.KeywordsId).HasColumnName("KeywordsId");

            // Relationships
            this.HasRequired(t => t.Parent)
                .WithMany(t => t.Children)
                .HasForeignKey(d => d.KeywordsId);

        }
    }
}
