using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleHoras.APRESENTACAO.Models
{
    public class AlocacaoViewModel 
    {

        public AlocacaoViewModel()
        {

        }

        public int ContratoID { get; set; }
        public int ProfissionalID { get; internal set; }

        public ProfissionalViewModel Profissional { get; set; }
        public ContratoViewModel Contrato { get; set; }
    
    }
}