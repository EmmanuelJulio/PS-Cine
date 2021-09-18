using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DATE.Config
{
    public class ConfigSalas
    {
        public ConfigSalas(EntityTypeBuilder<Salas> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.SalasId);
            entityTypeBuilder.HasMany(x => x.Funciones).WithOne(m => m.Salas).HasForeignKey(x => x.SalaId);

        }

    }
}
