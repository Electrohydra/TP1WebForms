using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace TP1WebForms.Models
{
    public class Context : DbContext
    {
        public DbSet<Activité> Activités { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
    }
}
