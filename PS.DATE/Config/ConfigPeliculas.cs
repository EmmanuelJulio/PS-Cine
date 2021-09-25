using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DATE.Config
{
    public class ConfigPeliculas
    {
        public ConfigPeliculas(EntityTypeBuilder<PeliculaDTO> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.PeliculaId);
            entityTypeBuilder.HasMany(x => x.Funciones).WithOne(m => m.Peliculas).HasForeignKey(x => x.PeliculaId);
        }
    }
}
