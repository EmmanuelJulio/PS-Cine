using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DATE.Config
{
    public class ConfigFunciones
    { 
        public ConfigFunciones(EntityTypeBuilder<Funciones> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.FuncionId);
            entityTypeBuilder.HasMany(x => x.Tickets).WithOne(m => m.Funciones).HasForeignKey(x => x.FuncionId);
        }
    }
}
