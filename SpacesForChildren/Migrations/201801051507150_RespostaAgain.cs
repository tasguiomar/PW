namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RespostaAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pedidoes", "Resposta");
            AddColumn("dbo.Pedidoes", "Resposta", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "Resposta");
        }
    }
}
