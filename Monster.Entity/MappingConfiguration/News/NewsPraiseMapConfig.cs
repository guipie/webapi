using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class NewsPraiseMapConfig : EntityMappingConfiguration<NewsPraise>
    {
        public override void Map(EntityTypeBuilder<NewsPraise>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

