namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacaoServicos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servicoes", "ServicosDescricao", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Servicoes", "ServicosIdadeMin");
            DropColumn("dbo.Servicoes", "ServicosIdadeMax");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicoes", "ServicosIdadeMax", c => c.Int(nullable: false));
            AddColumn("dbo.Servicoes", "ServicosIdadeMin", c => c.Int(nullable: false));
            AlterColumn("dbo.Servicoes", "ServicosDescricao", c => c.String());
        }
    }
}
