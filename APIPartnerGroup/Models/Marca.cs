using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPartnerGroup.Models
{
    public class Marca
    {

        public int MarcaId { get; set; }
        public string Nome { get; set; }

        public List<Patrimonio> patrimonios { get; set; }
    }
}