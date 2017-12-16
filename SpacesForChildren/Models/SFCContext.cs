using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SpacesForChildren.Models
{
    public class SFCContext : DbContext
    {
        public SFCContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Pai> Pais { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

    }
}