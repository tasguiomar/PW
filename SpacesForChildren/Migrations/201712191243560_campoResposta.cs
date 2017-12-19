namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campoResposta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "Resposta", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "Resposta");
        }
    }
}
