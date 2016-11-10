using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1WebForms
{
    public partial class Inscription : BasePage
    {
        // id pour les textbox qui seront généré dinamiquement
        int numIdTextBoxTel;
        int numIdTextBoxAdd;

        protected void Page_Load(object sender, EventArgs e)
        {
            //si la page n'est pas PostBack...
            if (!IsPostBack)
            {
                if (this.SelectedDateNaissance == DateTime.MinValue)
                {
                    // on popule les dropdown pour la date de naissance
                    this.PopulerAnnée();
                    this.PopulerMois();
                    this.PopulerJours();
                }

                if (this.SelectedDatePassage == DateTime.MinValue)
                {
                    // on popule les dropdown pour la date de passage
                    this.PopulerAnnée();
                    this.PopulerMois();
                    this.PopulerJours();
                }
                numIdTextBoxTel = 1;
                numIdTextBoxAdd = 1;
            }
            else
            {
                if (Request.Form[DropDownJourNaissance.UniqueID] != null)
                {
                    this.PopulerJours();
                    DropDownJourNaissance.ClearSelection();
                    DropDownJourNaissance.Items.FindByValue(Request.Form[DropDownJourNaissance.UniqueID]).Selected = true;
                }

                if (Request.Form[DropDownJourPassage.UniqueID] != null)
                {
                    this.PopulerJours();
                    DropDownJourPassage.ClearSelection();
                    DropDownJourPassage.Items.FindByValue(Request.Form[DropDownJourPassage.UniqueID]).Selected = true;
                }
            }
        }

        // pour faire populer et garder en mémoire la date sélectionner
        private int JourNaissance
        {
            //on va chercher la valeur dans le dropdown
            get
            {
                if (Request.Form[DropDownJourNaissance.UniqueID] != null)
                {
                    return int.Parse(Request.Form[DropDownJourNaissance.UniqueID]);
                }
                else
                {
                    return int.Parse(DropDownJourNaissance.SelectedItem.Value);
                }
            }
            //on popule le dropdown avec les bonne valeur
            set
            {
                this.PopulerJours();
                DropDownJourNaissance.ClearSelection();
                DropDownJourNaissance.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        // pour faire populer et garder en mémoire la date sélectionner
        private int MoisNaissance
        {
            //on va chercher la valeur dans le dropdown
            get
            {
                return int.Parse(DropDownMoisNaissance.SelectedItem.Value);
            }
            //on popule le dropdown avec les bonne valeur
            set
            {
                this.PopulerMois();
                DropDownMoisNaissance.ClearSelection();
                DropDownMoisNaissance.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        // pour faire populer et garder en mémoire la date sélectionner
        private int AnnéeNaissance
        {
            //on va chercher la valeur dans le dropdown
            get
            {
                return int.Parse(DropDownAnnéeNaissance.SelectedItem.Value);
            }
            //on popule le dropdown avec les bonne valeur
            set
            {
                this.PopulerAnnée();
                DropDownAnnéeNaissance.ClearSelection();
                DropDownAnnéeNaissance.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        // pour faire populer et garder en mémoire la date sélectionner
        private int JourPassage
        {
            //on va chercher la valeur dans le dropdown
            get
            {
                if (Request.Form[DropDownJourPassage.UniqueID] != null)
                {
                    return int.Parse(Request.Form[DropDownJourPassage.UniqueID]);
                }
                else
                {
                    return int.Parse(DropDownJourPassage.SelectedItem.Value);
                }
            }
            //on popule le dropdown avec les bonne valeur
            set
            {
                this.PopulerJours();
                DropDownJourPassage.ClearSelection();
                DropDownJourPassage.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        // pour faire populer et garder en mémoire la date sélectionner
        private int MoisPassage
        {
            //on va chercher la valeur dans le dropdown
            get
            {
                return int.Parse(DropDownMoisPassage.SelectedItem.Value);
            }
            //on popule le dropdown avec les bonne valeur
            set
            {
                this.PopulerMois();
                DropDownMoisPassage.ClearSelection();
                DropDownMoisPassage.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        // pour faire populer et garder en mémoire la date sélectionner
        private int AnnéePassage
        {
            //on va chercher la valeur dans le dropdown
            get
            {
                return int.Parse(DropDownAnnéePassage.SelectedItem.Value);
            }
            //on popule le dropdown avec les bonne valeur
            set
            {
                this.PopulerAnnée();
                DropDownAnnéePassage.ClearSelection();
                DropDownAnnéePassage.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        // on va chercher les items sélectionner pour créer une date pour l'entrer dans la base de donner plus tard
        public DateTime SelectedDateNaissance
        {
            get
            {
                try
                {
                    return DateTime.Parse(this.MoisNaissance + "/" + this.JourNaissance + "/" + this.AnnéeNaissance);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            set
            {
                if (!value.Equals(DateTime.MinValue))
                {
                    this.AnnéeNaissance = value.Year;
                    this.MoisNaissance = value.Month;
                    this.JourNaissance = value.Day;
                }
            }
        }

        // on va chercher les items sélectionner pour créer une date pour l'entrer dans la base de donner plus tard
        public DateTime SelectedDatePassage
        {
            get
            {
                try
                {
                    return DateTime.Parse(this.MoisPassage + "/" + this.JourPassage + "/" + this.AnnéePassage);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            set
            {
                if (!value.Equals(DateTime.MinValue))
                {
                    this.AnnéePassage = value.Year;
                    this.MoisPassage = value.Month;
                    this.JourPassage = value.Day;
                }
            }
        }

        // Pour faire afficher dans le dropdown le bon nombre de jour dans le mois sélectionner
        // on faire les dropdown de naissance et et passage en même temps
        private void PopulerJours()
        {
            DropDownJourNaissance.Items.Clear();
            DropDownJourPassage.Items.Clear();

            ListItem lt = new ListItem();
            lt.Text = "Jour";
            lt.Value = "0";

            DropDownJourNaissance.Items.Add(lt);
            DropDownJourPassage.Items.Add(lt);
            //On regarde combien il y a de jour dans le mois sélectionner
            int days = DateTime.DaysInMonth(this.AnnéeNaissance, this.MoisNaissance);

            // on ajouter les nombre dans le dropdown pour avoir le bon nombre de jour dans le mois
            for (int i = 1; i <= days; i++)
            {
                lt = new ListItem();
                lt.Text = i.ToString();
                lt.Value = i.ToString();
                DropDownJourNaissance.Items.Add(lt);
                DropDownJourPassage.Items.Add(lt);
            }

            DropDownJourNaissance.Items.FindByValue(DateTime.Now.Day.ToString()).Selected = true;
            DropDownJourPassage.Items.FindByValue(DateTime.Now.Day.ToString()).Selected = true;
        }

        // Pour faire afficher les mois de l'année
        // on faire les dropdown de naissance et et passage en même temps
        private void PopulerMois()
        {
            DropDownMoisNaissance.Items.Clear();
            DropDownMoisPassage.Items.Clear();

            ListItem lt = new ListItem();
            lt.Text = "Mois";
            lt.Value = "0";

            DropDownMoisNaissance.Items.Add(lt);
            DropDownMoisPassage.Items.Add(lt);

            // on ajoute les mois dans le dropdown
            for (int i = 1; i <= 12; i++)
            {
                lt = new ListItem();
                lt.Text = Convert.ToDateTime(i.ToString() + "/1/1900").ToString("MMMM");
                lt.Value = i.ToString();
                DropDownMoisNaissance.Items.Add(lt);
                DropDownMoisPassage.Items.Add(lt);
            }

            DropDownMoisNaissance.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
            DropDownMoisPassage.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
        }

        // Pour faire afficher les années
        // on faire les dropdown de naissance et et passage en même temps
        private void PopulerAnnée()
        {
            DropDownAnnéeNaissance.Items.Clear();
            DropDownAnnéePassage.Items.Clear();

            ListItem lt = new ListItem();
            lt.Text = "Année";
            lt.Value = "0";

            DropDownAnnéeNaissance.Items.Add(lt);
            DropDownAnnéePassage.Items.Add(lt);

            // on ajoute les années dans le dropdown, on recule j'usqu'en 1900
            for (int i = DateTime.Now.Year; i >= 1900; i--)
            {
                lt = new ListItem();
                lt.Text = i.ToString();
                lt.Value = i.ToString();
                DropDownAnnéeNaissance.Items.Add(lt);
                DropDownAnnéePassage.Items.Add(lt);
            }

            DropDownAnnéeNaissance.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
            DropDownAnnéePassage.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
        }

        // pour ajouter un nouveau textBox si besoin pour ajouter un autre numéro de téléphone
        protected void AjouterNumTel_Click(object sender, EventArgs e)
        {
            // on monte le nombre total de textBox dans la page
            numIdTextBoxTel++;

            var newLabel = new Label();
            var newTextbox = new TextBox();

            // textbox a besoin d'un id unique pour garder l'information information
            newTextbox.ID = "TextBoxTéléphone" + numIdTextBoxTel;

            newLabel.Text = "Numéro de téléphone " + numIdTextBoxTel;

            // ajoute le label et textBox au panel, puis ajoute le panel à la form
            Téléphones.Controls.Add(newLabel);
            Téléphones.Controls.Add(newTextbox);
        }

        // pour ajouter un nouveau textBox si besoin pour ajouter une autre addresse
        protected void AjouterAdd_Click(object sender, EventArgs e)
        {
            // on monte le nombre total de textBox dans la page
            numIdTextBoxAdd++;

            var newLabel = new Label();
            var newTextbox = new TextBox();

            // textbox a besoin d'un id unique pour garder l'information information
            newTextbox.ID = "TextBoxAddresse" + numIdTextBoxAdd;

            newLabel.Text = "Addresse " + numIdTextBoxAdd;

            // ajoute le label et textBox au panel, puis ajoute le panel à la form
            Addresses.Controls.Add(newLabel);
            Addresses.Controls.Add(newTextbox);
        }

        // les enum pour les différents grade et catégorie du judo
        public enum Grade { Blanche, Jaune, Orange, Verte, Bleu, Marron, Noire, Rouge };
        public enum Catégorie { U10, U12, U14, U16, U18, U21, Sénior, Vétéran };

        int IDMembre = 1;

        // Lorsqu'on click sur le bouton de confirmation, on vérifie les champs puis on ajoute les informations dans la bd
        protected void Incription_Click(object sender, EventArgs e)
        {
            int numMembre = GénérerNumMembre();
            string nom = TextBoxNom.Text;
            string prénom = TextBoxPrénom.Text;

            DateTime dateNaissance = new DateTime(Int32.Parse(DropDownAnnéeNaissance.SelectedValue.ToString()),
                Int32.Parse(DropDownMoisNaissance.SelectedValue.ToString()), Int32.Parse(DropDownJourNaissance.SelectedValue.ToString()));

            int numAssuranceMaladie = Int32.Parse(TextBoxNumAM.Text);
            int numPasseport = Int32.Parse(TextBoxNumPC.Text);

            string numTéléphones = CréerListe(numIdTextBoxTel, "TextBoxTéléphone");
            string addresses = CréerListe(numIdTextBoxAdd, "TextBoxAddresse");

            Grade grade = (Grade)Enum.Parse(typeof(Grade), DDGrade.Text);
            DateTime datePassage = new DateTime(Int32.Parse(DropDownAnnéePassage.SelectedValue.ToString()),
                Int32.Parse(DropDownMoisPassage.SelectedValue.ToString()), Int32.Parse(DropDownJourPassage.SelectedValue.ToString()));

            Catégorie catégorie = (Catégorie)Enum.Parse(typeof(Catégorie), DropDownListCatégorie.Text);

            DateTime dateInscription = DateTime.Today;
            string cours = DropDownListCours.Text;

            //ajouter dans la bd

            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlconnection "].ConnectionString;
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from  TableName";
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, " TableName ");
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataRow drow = ds.Tables["TableName"].NewRow();
            drow["numMembre"] = numMembre;
            drow["nom"] = nom;
            drow["prénom"] = prénom;
            drow["dateNaissance"] = dateNaissance;
            drow["noAssuranceMaladie"] = numAssuranceMaladie;
            drow["noPasseport"] = numPasseport;
            drow["noTelephone"] = numTéléphones;
            drow["grade"] = grade;
            drow["datePassage"] = datePassage;
            drow["catégorie"] = catégorie;
            drow["dateInscription"] = dateInscription;
            drow["cours"] = cours;

            ds.Tables["Inscriptions "].Rows.Add(drow);
            da.Update(ds, " Inscriptions ");


    }

        // on crée une liste des numéro de téléphone ou des addresses de la personne inscrit
        string CréerListe(int numId, string nomTextBox)
        {
            string li = "";

            for (int i = 0; i <= numId; i++)
            {
                // on récupère le contenu de tout les textbox généré
                TextBox t = (TextBox)Page.FindControl(nomTextBox + i.ToString());
                // on les mets tous ensemble pour créer une seule string
                li += "/" + t;
            }

            return li;
        }
        
        // on génère un nouveau ID de membre lorsque l'on crée un nouveau membre
        int GénérerNumMembre()
        {
            return IDMembre++;
        }
    }
}