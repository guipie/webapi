using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class MovieWebsiteTypeMapConfig : EntityMappingConfiguration<MovieWebsiteType>
    {
        public override void Map(EntityTypeBuilder<MovieWebsiteType>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

