namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaIdade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servicoes", "ServicosIdadeMin", c => c.Int(nullable: false));
            AddColumn("dbo.Servicoes", "ServicosIdadeMax", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Servicoes", "ServicosIdadeMax");
            DropColumn("dbo.Servicoes", "ServicosIdadeMin");
        }
    }
}
