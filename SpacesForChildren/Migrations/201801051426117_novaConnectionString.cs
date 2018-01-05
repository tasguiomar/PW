namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novaConnectionString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "Avaliacao", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "Avaliacao");
        }
    }
}
