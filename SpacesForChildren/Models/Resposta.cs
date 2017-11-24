using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public enum Resp { Sim, Não };

    public class Resposta
    {
        public int RespostaID { get; set; }
        public Resp RespostaDecisao { get; set; }
        public int InstituicaoID { get; set; }
        public int PedidoID { get; set; }
       

        public virtual Pedido Pedido { get; set; }
        public virtual Instituicao Instituicao { get; set; }
    }
}