namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacaoAnuncios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Anuncios", "AnuncioTitulo", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Anuncios", "AnuncioDescricao", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Anuncios", "AnuncioData", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Anuncios", "AnuncioData", c => c.DateTime());
            AlterColumn("dbo.Anuncios", "AnuncioDescricao", c => c.String());
            AlterColumn("dbo.Anuncios", "AnuncioTitulo", c => c.String());
        }
    }
}
