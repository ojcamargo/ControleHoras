using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleHoras.DOMINIO.Entities;

namespace ControleHoras.DATA.Configuration
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            //Chave Primaria
            HasKey(x => x.ClienteID);
            //Identity Column
            Property(x => x.ClienteID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Campos obrigatorios
            Property(x => x.Nome).IsRequired();
            //Tamanho maximo
            Property(x => x.Nome).HasMaxLength(50);
            Property(x => x.Cnpj).HasMaxLength(14);
        }
    }
}
