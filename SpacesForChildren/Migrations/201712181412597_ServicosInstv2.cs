namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServicosInstv2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anuncios", "Instituicao_InstituicaoID", "dbo.Instituicaos");
            DropIndex("dbo.Anuncios", new[] { "Instituicao_InstituicaoID" });
            DropColumn("dbo.Anuncios", "Instituicao_InstituicaoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Anuncios", "Instituicao_InstituicaoID", c => c.Int());
            CreateIndex("dbo.Anuncios", "Instituicao_InstituicaoID");
            AddForeignKey("dbo.Anuncios", "Instituicao_InstituicaoID", "dbo.Instituicaos", "InstituicaoID");
        }
    }
}
