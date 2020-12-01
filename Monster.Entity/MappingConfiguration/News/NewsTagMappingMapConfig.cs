using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class NewsTagMappingMapConfig : EntityMappingConfiguration<NewsTagMapping>
    {
        public override void Map(EntityTypeBuilder<NewsTagMapping>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

