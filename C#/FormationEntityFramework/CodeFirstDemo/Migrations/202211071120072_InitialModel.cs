namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Ville_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Villes", t => t.Ville_Id)
                .Index(t => t.Ville_Id);
            
            CreateTable(
                "dbo.Villes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomVille = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Ville_Id", "dbo.Villes");
            DropIndex("dbo.Clients", new[] { "Ville_Id" });
            DropTable("dbo.Villes");
            DropTable("dbo.Clients");
        }
    }
}
