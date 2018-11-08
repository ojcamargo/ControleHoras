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
    public class ClienteIpConfig : EntityTypeConfiguration<ClienteIp>
    {
        public ClienteIpConfig()
        {
            //Chave Primaria
            HasKey(x => x.ClienteIpID);
            //Identity Column
            Property(x => x.ClienteIpID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Campos obrigatorios
            Property(x => x.IP).IsRequired();
            Property(x => x.ClienteID).IsRequired();
            //Tamanho maximo
            Property(x => x.IP).HasMaxLength(15);
        }
    }
}
