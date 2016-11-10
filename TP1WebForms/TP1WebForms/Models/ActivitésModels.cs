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

    public class Activité
    {
        public int Id { get; set; }
        public string NomActivité { get; set; }
        public int ÂgeMin { get; set; }
        public string Date { get; set; }
        public string HeureDébut { get; set; }
        public string heureFin { get; set; }
    }
}
