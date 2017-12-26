namespace SpacesForChildren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacaoInstituicoes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instituicaos", "InstituicaoNome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Instituicaos", "InstituicaoCidade", c => c.String(nullable: false));
            AlterColumn("dbo.Instituicaos", "InstituicaoMorada", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instituicaos", "InstituicaoMorada", c => c.String());
            AlterColumn("dbo.Instituicaos", "InstituicaoCidade", c => c.String());
            AlterColumn("dbo.Instituicaos", "InstituicaoNome", c => c.String());
        }
    }
}
