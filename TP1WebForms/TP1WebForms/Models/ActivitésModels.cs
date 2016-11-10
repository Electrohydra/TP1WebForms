using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace TP1WebForms.Models
{
    public class ActivitésModels : DbContext
    {
        public DbSet<Activité> Activités { get; set; }
    }

    // Classe activité avec les paramètres que l'on veux retrouver pour chaque activité
    public class Activité
    {
        public int Id { get; set; } // le ID de l'activité
        public string NomActivité { get; set; } // le genre d'activité qui aura lieu
        public int ÂgeMin { get; set; } // l'âge minimum requis pour pouvoir aller à l'événement
        public string Date { get; set; } // la date de l'événement
        public string HeureDébut { get; set; } // heure de début de l'activité
        public string heureFin { get; set; } // heure de fin prévus pour l'activité
    }
}
