using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public enum TipoServ { Creche, Transporte, Natação, Música, Infantário, Berçário, CTL, Dança, Teatro, Outro };

    public class Servico
    {
        public int ServicosID { get; set; }
        public string ServicosDescricao { get; set; }
        public float ServicosPreco { get; set; }
        public TipoServ ServicosTipo { get; set; }
        public int AvaliacaoID { get; set; }
        public int InstituicaoID { get; set; }

        public virtual Instituicao Instituicao { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
    }
}

https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application