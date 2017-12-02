using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models
{
    public enum Resp { Sim, Não };

    public class Resposta
    {
        [Key]
        public int RespostaID { get; set; }
        [Display(Name = "Decisão: ")]
        public Resp RespostaDecisao { get; set; }
        public int InstituicaoID { get; set; }

        [ForeignKey("InstituicaoID")]
        public virtual Instituicao Instituicao { get; set; }
    }
}