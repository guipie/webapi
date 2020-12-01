using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class WebsiteHomeConfigMapConfig : EntityMappingConfiguration<WebsiteHomeConfig>
    {
        public override void Map(EntityTypeBuilder<WebsiteHomeConfig>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

