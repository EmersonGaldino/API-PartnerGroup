using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPartnerGroup.Models
{
    public class Patrimonio
    {
        public string Nome { get; set; }
        public Marca MarcaId { get; set; }
        public string Descricao { get; set; }
        public int NumeroTombo { get; set; }
    }
}