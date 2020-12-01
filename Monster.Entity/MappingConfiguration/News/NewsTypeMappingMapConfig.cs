using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class NewsTypeMappingMapConfig : EntityMappingConfiguration<NewsTypeMapping>
    {
        public override void Map(EntityTypeBuilder<NewsTypeMapping>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

