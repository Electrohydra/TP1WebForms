namespace TP1WebForms.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationActivités : DbMigrationsConfiguration<TP1WebForms.Models.ActivitésModels>
    {
        public ConfigurationActivités()
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


            /*context.Inscriptions.AddOrUpdate(
                 new Models.Inscription
                 {
                     NumMembre = 1,
                     Nom = "Leboeuf",
                     Prénom = "Ariane",
                     DateNaissance = New DateTime(1993,6,24),
                     NumAssuranceMaladie = 1234567,
                     NumPasseport = 234567,
                     NumTéléphone = "450-524-4613",
                     Addresses = "2 rue de la pérade",
                     Grade = Models.Grade.Rouge,
                     DatePassage = new DateTime(2005,5,25),
                     Catégorie = Models.Catégorie.U12,
                     DateInscription = new DateTime(2016,10,31),
                     Cours = "un jour un moment donné"
                 }
*/
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
