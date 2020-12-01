using Monster.Entity.MappingConfiguration;
using Monster.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monster.Entity.MappingConfiguration
{
    public class MoviePlayMapConfig : EntityMappingConfiguration<MoviePlay>
    {
        public override void Map(EntityTypeBuilder<MoviePlay>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

