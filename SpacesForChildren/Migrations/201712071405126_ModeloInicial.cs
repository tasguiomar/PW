namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anuncios",
                c => new
                    {
                        AnuncioID = c.Int(nullable: false, identity: true),
                        AnuncioTitulo = c.String(),
                        AnuncioDescricao = c.String(),
                        AnuncioData = c.DateTime(),
                        InstituicaoID = c.Int(nullable: false),
                        ServicoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnuncioID)
                .ForeignKey("dbo.Instituicaos", t => t.InstituicaoID, cascadeDelete: true)
                .ForeignKey("dbo.Servicoes", t => t.ServicoID, cascadeDelete: true)
                .Index(t => t.InstituicaoID)
                .Index(t => t.ServicoID);
            
            CreateTable(
                "dbo.Instituicaos",
                c => new
                    {
                        InstituicaoID = c.Int(nullable: false, identity: true),
                        InstituicaoTipo = c.Int(nullable: false),
                        InstituicaoNome = c.String(),
                        InstituicaoEmail = c.String(),
                        InstituicaoTelefone = c.Int(nullable: false),
                        InstituicaoCidade = c.String(),
                        InstituicaoMorada = c.String(),
                    })
                .PrimaryKey(t => t.InstituicaoID);
            
            CreateTable(
                "dbo.Respostas",
                c => new
                    {
                        RespostaID = c.Int(nullable: false, identity: true),
                        RespostaDecisao = c.Int(nullable: false),
                        InstituicaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RespostaID)
                .ForeignKey("dbo.Instituicaos", t => t.InstituicaoID, cascadeDelete: true)
                .Index(t => t.InstituicaoID);
            
            CreateTable(
                "dbo.Servicoes",
                c => new
                    {
                        ServicoID = c.Int(nullable: false, identity: true),
                        ServicosDescricao = c.String(),
                        ServicosPreco = c.Single(nullable: false),
                        ServicosTipo = c.Int(nullable: false),
                        InstituicaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicoID)
                .ForeignKey("dbo.Instituicaos", t => t.InstituicaoID, cascadeDelete: false)
                .Index(t => t.InstituicaoID);
            
            CreateTable(
                "dbo.Avaliacaos",
                c => new
                    {
                        AvaliacaoID = c.Int(nullable: false, identity: true),
                        AvaliacaoPreco = c.Int(nullable: false),
                        AvaliacaoLocalizacao = c.Int(nullable: false),
                        AvaliacaoAmbiente = c.Int(nullable: false),
                        AvaliacaoGeral = c.Int(nullable: false),
                        PaiID = c.Int(nullable: false),
                        ServicoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AvaliacaoID)
                .ForeignKey("dbo.Pais", t => t.PaiID, cascadeDelete: true)
                .ForeignKey("dbo.Servicoes", t => t.ServicoID, cascadeDelete: true)
                .Index(t => t.PaiID)
                .Index(t => t.ServicoID);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaiID = c.Int(nullable: false, identity: true),
                        PaisNome = c.String(),
                        PaisCc = c.Int(nullable: false),
                        PaisNif = c.Int(nullable: false),
                        PaisTelemovel = c.Int(nullable: false),
                        PaisEmail = c.String(),
                    })
                .PrimaryKey(t => t.PaiID);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        PaiID = c.Int(nullable: false),
                        AnuncioID = c.Int(nullable: false),
                        RespostaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoID)
                .ForeignKey("dbo.Anuncios", t => t.AnuncioID, cascadeDelete: true)
                .ForeignKey("dbo.Pais", t => t.PaiID, cascadeDelete: true)
                .ForeignKey("dbo.Respostas", t => t.RespostaID, cascadeDelete: false)
                .Index(t => t.PaiID)
                .Index(t => t.AnuncioID)
                .Index(t => t.RespostaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anuncios", "ServicoID", "dbo.Servicoes");
            DropForeignKey("dbo.Anuncios", "InstituicaoID", "dbo.Instituicaos");
            DropForeignKey("dbo.Servicoes", "InstituicaoID", "dbo.Instituicaos");
            DropForeignKey("dbo.Avaliacaos", "ServicoID", "dbo.Servicoes");
            DropForeignKey("dbo.Avaliacaos", "PaiID", "dbo.Pais");
            DropForeignKey("dbo.Pedidoes", "RespostaID", "dbo.Respostas");
            DropForeignKey("dbo.Pedidoes", "PaiID", "dbo.Pais");
            DropForeignKey("dbo.Pedidoes", "AnuncioID", "dbo.Anuncios");
            DropForeignKey("dbo.Respostas", "InstituicaoID", "dbo.Instituicaos");
            DropIndex("dbo.Pedidoes", new[] { "RespostaID" });
            DropIndex("dbo.Pedidoes", new[] { "AnuncioID" });
            DropIndex("dbo.Pedidoes", new[] { "PaiID" });
            DropIndex("dbo.Avaliacaos", new[] { "ServicoID" });
            DropIndex("dbo.Avaliacaos", new[] { "PaiID" });
            DropIndex("dbo.Servicoes", new[] { "InstituicaoID" });
            DropIndex("dbo.Respostas", new[] { "InstituicaoID" });
            DropIndex("dbo.Anuncios", new[] { "ServicoID" });
            DropIndex("dbo.Anuncios", new[] { "InstituicaoID" });
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Pais");
            DropTable("dbo.Avaliacaos");
            DropTable("dbo.Servicoes");
            DropTable("dbo.Respostas");
            DropTable("dbo.Instituicaos");
            DropTable("dbo.Anuncios");
        }
    }
}
