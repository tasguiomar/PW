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

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
