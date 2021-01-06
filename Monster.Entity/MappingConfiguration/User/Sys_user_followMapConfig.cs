using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class Sys_user_followMapConfig : EntityMappingConfiguration<Sys_user_follow>
    {
        public override void Map(EntityTypeBuilder<Sys_user_follow>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

