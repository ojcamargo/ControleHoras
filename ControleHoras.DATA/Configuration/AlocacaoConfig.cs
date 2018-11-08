using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleHoras.DOMINIO.Entities;

namespace ControleHoras.DATA.Configuration
{
    public class AlocacaoConfig : EntityTypeConfiguration<Alocacao>
    {
        public AlocacaoConfig()
        {
            //Chave Primaria
            HasKey(x => new { x.ProfissionalID, x.ContratoID });
            //Campos obrigatorios
            Property(x => x.ProfissionalID).IsRequired();
            Property(x => x.ContratoID).IsRequired();
        }
    }
}
