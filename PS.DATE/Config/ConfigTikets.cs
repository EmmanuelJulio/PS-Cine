using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DATE.Config
{
    public class ConfigTickets
    {
        public ConfigTickets(EntityTypeBuilder<Tickets> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => new { x.TiketId, x.FuncionId });
        }


    }
}
