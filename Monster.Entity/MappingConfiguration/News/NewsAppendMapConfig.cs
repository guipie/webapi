using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class NewsAppendMapConfig : EntityMappingConfiguration<NewsAppend>
    {
        public override void Map(EntityTypeBuilder<NewsAppend>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

