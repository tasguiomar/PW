namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class respost : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pedidoes", "RespostaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidoes", "RespostaID", c => c.Boolean(nullable: false));
        }
    }
}
