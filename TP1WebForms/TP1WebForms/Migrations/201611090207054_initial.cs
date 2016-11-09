namespace TP1WebForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activité",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomActivité = c.String(),
                        ÂgeMin = c.Int(nullable: false),
                        Date = c.String(),
                        HeureDébut = c.String(),
                        heureFin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Activité");
        }
    }
}
