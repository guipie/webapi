using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class UserSignMapConfig : EntityMappingConfiguration<UserSign>
    {
        public override void Map(EntityTypeBuilder<UserSign>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

