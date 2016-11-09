namespace TP1WebForms.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TP1WebForms.Models.ActivitésModels>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TP1WebForms.Models.ActivitésModels context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Activités.AddOrUpdate(
                 new Models.Activité
                 {
                     Id = 1,
                     NomActivité = "Gala",
                     ÂgeMin = 16,
                     Date = "16 septembre",
                     HeureDébut = "16h",
                     heureFin = "20h"
                 },
                 new Models.Activité
                 {
                     Id = 2,
                     NomActivité = "Stage",
                     ÂgeMin = 14,
                     Date = "28 octobre",
                     HeureDébut = "12h",
                     heureFin = "16h"
                 },
                 new Models.Activité
                 {
                     Id = 3,
                     NomActivité = "Réunion",
                     ÂgeMin = 18,
                     Date = "24 juin",
                     HeureDébut = "18h",
                     heureFin = "20h"
                 },
                 new Models.Activité
                 {
                     Id = 4,
                     NomActivité = "Compétition",
                     ÂgeMin = 16,
                     Date = "1e février",
                     HeureDébut = "16h",
                     heureFin = "20h"
                 }
                 );

            context.SaveChanges();
        }
    }
}
