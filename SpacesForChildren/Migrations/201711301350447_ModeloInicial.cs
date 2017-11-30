namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        { 
            CreateTable(
                "dbo.Instituicoes",
                c => new
                {
                    InstituicaoId = c.Int(nullable: false, identity: true),
                    InstituicaoTipo = c.Int(nullable: false),
                    InstituicaoNome = c.String(nullable: false),
                    InstituicaoEmail = c.String(nullable: false),
                    InstituicaoTelefone = c.Int(nullable: false),
                    InstituicaoCidade = c.String(nullable: false),
                    InstituicaoMorada = c.String(nullable: false),
                })
                .PrimaryKey(t => t.InstituicaoId);

            CreateTable(
                "dbo.Servicos",
                c => new
                {
                    ServicosId = c.Int(nullable: false, identity: true),
                    ServicosDescricao = c.String(nullable: false),
                    ServicosPreco = c.Double(nullable: false),
                    ServicosTipo = c.Int(nullable: false),
                    Instituicao_InstituicaoId = c.Int(),
                })
                .PrimaryKey(t => t.ServicosId)
                .ForeignKey("dbo.Instituicoes", t => t.Instituicao_InstituicaoId)
                .Index(t => t.Instituicao_InstituicaoId);

            CreateTable(
                "dbo.Anuncios",
                c => new
                {
                    AnuncioId = c.Int(nullable: false, identity: true),
                    AnuncioTitulo = c.String(nullable: false),
                    AnuncioDescriacao = c.String(nullable: false),
                    AnuncioData = c.DateTime(nullable: false),
                    Instituicao_InstituicaoId = c.Int(),
                    Servico_ServicoId = c.Int(),
                })
                .PrimaryKey(t => t.AnuncioId)
                .ForeignKey("dbo.Instituicoes", t => t.Instituicao_InstituicaoId)
                .ForeignKey("dbo.Servicos", t => t.Servico_ServicoId)
                .Index(t => t.Instituicao_InstituicaoId)
                .Index(t => t.Servico_ServicoId);

            CreateTable(
                "dbo.Pais",
                c => new
                {
                    PaiId = c.Int(nullable: false, identity: true),
                    PaiNome = c.String(nullable: false),
                    PaiCc = c.Int(nullable: false),
                    PaiNif = c.Int(nullable: false),
                    PaiTelemovel = c.Int(nullable: false),
                    PaiEmail = c.String(),
                })
                .PrimaryKey(t => t.PaiId);

            CreateTable(
                "dbo.Avaliacoes",
                c => new
                {
                    AvaliacaoId = c.Int(nullable: false, identity: true),
                    AvaliacaoPreco = c.Int(nullable: false),
                    AvaliacaoLocalizacao = c.Int(nullable: false),
                    AvaliacaoAmbiente = c.Int(nullable: false),
                    AvaliacaoGeral = c.Int(nullable: false),
                    Pai_PaiId = c.Int(),
                    Servico_ServicoId = c.Int(),
                })
                .PrimaryKey(t => t.AvaliacaoId)
                .ForeignKey("dbo.Pais", t => t.Pai_PaiId)
                .ForeignKey("dbo.Servicos", t => t.Servico_ServicoId)
                .Index(t => t.Pai_PaiId)
                .Index(t => t.Servico_ServicoId);

            CreateTable(
                "dbo.Respostas",
                c => new
                {
                    RespostaId = c.Int(nullable: false, identity: true),
                    RespostaDecisao = c.Int(nullable: false),
                    Servico_ServicoId = c.Int(),
                })
                .PrimaryKey(t => t.RespostaId)
                .ForeignKey("dbo.Servicos", t => t.Servico_ServicoId)
                .Index(t => t.Servico_ServicoId);

            CreateTable(
                "dbo.Pedidos",
                c => new
                {
                    PedidoId = c.Int(nullable: false, identity: true),
                    Pai_PaiId = c.Int(),
                    Anuncio_AnuncioId = c.Int(),
                    Resposta_RespostaId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Pais", t => t.Pai_PaiId)
                .ForeignKey("dbo.Anuncios", t => t.Anuncio_AnuncioId)
                .ForeignKey("dbo.Respostas", t => t.Resposta_RespostaId)
                .Index(t => t.Pai_PaiId)
                .Index(t => t.Anuncio_AnuncioId)
                .Index(t => t.Resposta_RespostaId);
            
        }
        
        public override void Down()
        {
        }
    }
}
