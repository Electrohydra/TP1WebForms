using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace TP1WebForms.Models
{
    public class InscriptionModels
    {
    }

    // Classe activité avec les paramètres que l'on veux retrouver pour chaque activité
    public class Inscription
    {
        [Key]
        public int numMembre { get; set; } // le numéro de membre de l'inscription
        public string nom { get; set; } // le nom de l'inscrit
        public string prénom { get; set; } // le prénom de l'inscrit
        DateTime dateNaissance { get; set; } // quand l'inscript est né
        public int noAssuranceMaladie { get; set; } // son numéro d'assurance maladie
        public int noPasseport { get; set; } // son numéro de passeport
        public string noTelephone { get; set; } // son numéro de téléphone
        public string grade { get; set; } // le grade de l'inscript (Blanc, jaune, noir, etc)
        DateTime datePassage { get; set; } // quand l'inscript a passé son dernier grade
        public string catégorie { get; set; } // la catégorie de cours auquel on s'inscrit
        DateTime dateInscription { get; set; } // quand l'inscript à été faite
        public string cours { get; set; } // le nom du cours auquel on s'inscrit
    }
}
