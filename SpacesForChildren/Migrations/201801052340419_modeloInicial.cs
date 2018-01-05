namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anuncios",
                c => new
                    {
                        AnuncioID = c.Int(nullable: false, identity: true),
                        AnuncioTitulo = c.String(nullable: false, maxLength: 100),
                        AnuncioDescricao = c.String(nullable: false, maxLength: 500),
                        AnuncioData = c.DateTime(nullable: false),
                        ServicoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnuncioID)
                .ForeignKey("dbo.Servicoes", t => t.ServicoID, cascadeDelete: true)
                .Index(t => t.ServicoID);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        PaiID = c.Int(nullable: false),
                        AnuncioID = c.Int(nullable: false),
                        Resposta = c.Int(nullable: false),
                        Avaliacao = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoID)
                .ForeignKey("dbo.Anuncios", t => t.AnuncioID, cascadeDelete: true)
                .ForeignKey("dbo.Pais", t => t.PaiID, cascadeDelete: true)
                .Index(t => t.PaiID)
                .Index(t => t.AnuncioID);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaiID = c.Int(nullable: false, identity: true),
                        PaisNome = c.String(nullable: false, maxLength: 150),
                        PaisCc = c.Int(nullable: false),
                        PaisNif = c.Int(nullable: false),
                        PaisTelemovel = c.Int(nullable: false),
                        PaisEmail = c.String(),
                    })
                .PrimaryKey(t => t.PaiID);
            
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
                "dbo.Servicoes",
                c => new
                    {
                        ServicoID = c.Int(nullable: false, identity: true),
                        ServicosDescricao = c.String(nullable: false, maxLength: 500),
                        ServicosPreco = c.Single(nullable: false),
                        ServicosTipo = c.Int(nullable: false),
                        InstituicaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServicoID)
                .ForeignKey("dbo.Instituicaos", t => t.InstituicaoID, cascadeDelete: true)
                .Index(t => t.InstituicaoID);
            
            CreateTable(
                "dbo.Instituicaos",
                c => new
                    {
                        InstituicaoID = c.Int(nullable: false, identity: true),
                        InstituicaoTipo = c.Int(nullable: false),
                        InstituicaoNome = c.String(nullable: false, maxLength: 100),
                        InstituicaoEmail = c.String(),
                        InstituicaoTelefone = c.Int(nullable: false),
                        InstituicaoCidade = c.String(nullable: false),
                        InstituicaoMorada = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.InstituicaoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anuncios", "ServicoID", "dbo.Servicoes");
            DropForeignKey("dbo.Pedidoes", "PaiID", "dbo.Pais");
            DropForeignKey("dbo.Avaliacaos", "ServicoID", "dbo.Servicoes");
            DropForeignKey("dbo.Servicoes", "InstituicaoID", "dbo.Instituicaos");
            DropForeignKey("dbo.Avaliacaos", "PaiID", "dbo.Pais");
            DropForeignKey("dbo.Pedidoes", "AnuncioID", "dbo.Anuncios");
            DropIndex("dbo.Servicoes", new[] { "InstituicaoID" });
            DropIndex("dbo.Avaliacaos", new[] { "ServicoID" });
            DropIndex("dbo.Avaliacaos", new[] { "PaiID" });
            DropIndex("dbo.Pedidoes", new[] { "AnuncioID" });
            DropIndex("dbo.Pedidoes", new[] { "PaiID" });
            DropIndex("dbo.Anuncios", new[] { "ServicoID" });
            DropTable("dbo.Instituicaos");
            DropTable("dbo.Servicoes");
            DropTable("dbo.Avaliacaos");
            DropTable("dbo.Pais");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Anuncios");
        }
    }
}
