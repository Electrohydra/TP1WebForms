using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TP1WebForms.Models
{
    public class InscriptionsModels
    {
        public DbSet<Inscription> Inscriptions { get; set; }
    }

    public enum Grade { Blanche, Jaune, Orange, Verte, Bleu, Marron, Noire, Rouge };
    public enum Catégorie { U10, U12, U14, U16, U18, U21, Sénior, Vétéran };

    public class Inscription
    {
        public int NumMembre { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public DateTime DateNaissance { get; set; }
        public int NumAssuranceMaladie { get; set; }
        public int NumPasseport { get; set; }
        public string NumTéléphone { get; set; }
        public string Addresses { get; set; }
        public Grade Grade { get; set; }
        public DateTime DatePassage { get; set; }
        public Catégorie Catégorie { get; set; }
        public DateTime DateInscription { get; set; }
        public string Cours { get; set; }
        
    }
}