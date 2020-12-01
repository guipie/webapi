using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class MovieWebsiteMapConfig : EntityMappingConfiguration<MovieWebsite>
    {
        public override void Map(EntityTypeBuilder<MovieWebsite>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

