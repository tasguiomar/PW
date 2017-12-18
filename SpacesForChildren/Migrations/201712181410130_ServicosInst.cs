namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServicosInst : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anuncios", "InstituicaoID", "dbo.Instituicaos");
            DropIndex("dbo.Anuncios", new[] { "InstituicaoID" });
            RenameColumn(table: "dbo.Anuncios", name: "InstituicaoID", newName: "Instituicao_InstituicaoID");
            AddColumn("dbo.Servicoes", "InstituicaoID", c => c.Int(nullable: false));
            AlterColumn("dbo.Anuncios", "Instituicao_InstituicaoID", c => c.Int());
            CreateIndex("dbo.Anuncios", "Instituicao_InstituicaoID");
            CreateIndex("dbo.Servicoes", "InstituicaoID");
            AddForeignKey("dbo.Servicoes", "InstituicaoID", "dbo.Instituicaos", "InstituicaoID", cascadeDelete: true);
            AddForeignKey("dbo.Anuncios", "Instituicao_InstituicaoID", "dbo.Instituicaos", "InstituicaoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anuncios", "Instituicao_InstituicaoID", "dbo.Instituicaos");
            DropForeignKey("dbo.Servicoes", "InstituicaoID", "dbo.Instituicaos");
            DropIndex("dbo.Servicoes", new[] { "InstituicaoID" });
            DropIndex("dbo.Anuncios", new[] { "Instituicao_InstituicaoID" });
            AlterColumn("dbo.Anuncios", "Instituicao_InstituicaoID", c => c.Int(nullable: false));
            DropColumn("dbo.Servicoes", "InstituicaoID");
            RenameColumn(table: "dbo.Anuncios", name: "Instituicao_InstituicaoID", newName: "InstituicaoID");
            CreateIndex("dbo.Anuncios", "InstituicaoID");
            AddForeignKey("dbo.Anuncios", "InstituicaoID", "dbo.Instituicaos", "InstituicaoID", cascadeDelete: true);
        }
    }
}
