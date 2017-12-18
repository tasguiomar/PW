namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Servicoes", "InstituicaoID", "dbo.Instituicaos");
            DropIndex("dbo.Servicoes", new[] { "InstituicaoID" });
            DropColumn("dbo.Servicoes", "InstituicaoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicoes", "InstituicaoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Servicoes", "InstituicaoID");
            AddForeignKey("dbo.Servicoes", "InstituicaoID", "dbo.Instituicaos", "InstituicaoID", cascadeDelete: true);
        }
    }
}
