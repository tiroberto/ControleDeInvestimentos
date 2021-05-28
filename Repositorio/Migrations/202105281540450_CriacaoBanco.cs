namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carteiras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Investimentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoInvestimentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvestimentoCarteiras",
                c => new
                    {
                        Investimento_Id = c.Int(nullable: false),
                        Carteira_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Investimento_Id, t.Carteira_Id })
                .ForeignKey("dbo.Investimentoes", t => t.Investimento_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carteiras", t => t.Carteira_Id, cascadeDelete: true)
                .Index(t => t.Investimento_Id)
                .Index(t => t.Carteira_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvestimentoCarteiras", "Carteira_Id", "dbo.Carteiras");
            DropForeignKey("dbo.InvestimentoCarteiras", "Investimento_Id", "dbo.Investimentoes");
            DropIndex("dbo.InvestimentoCarteiras", new[] { "Carteira_Id" });
            DropIndex("dbo.InvestimentoCarteiras", new[] { "Investimento_Id" });
            DropTable("dbo.InvestimentoCarteiras");
            DropTable("dbo.TipoInvestimentoes");
            DropTable("dbo.Investimentoes");
            DropTable("dbo.Carteiras");
        }
    }
}
