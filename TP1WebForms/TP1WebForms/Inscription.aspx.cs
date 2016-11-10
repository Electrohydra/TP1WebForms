using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1WebForms
{
    public partial class Inscription : System.Web.UI.Page
    {
        int numIdTextBoxTel;
        int numIdTextBoxAdd;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (this.SelectedDateNaissance == DateTime.MinValue)
                {
                    this.PopulerAnnée();
                    this.PopulerMois();
                    this.PopulerJours();
                }

                if (this.SelectedDatePassage == DateTime.MinValue)
                {
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

        private int JourNaissance
        {
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
            set
            {
                this.PopulerJours();
                DropDownJourNaissance.ClearSelection();
                DropDownJourNaissance.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        private int MoisNaissance
        {
            get
            {
                return int.Parse(DropDownMoisNaissance.SelectedItem.Value);
            }
            set
            {
                this.PopulerMois();
                DropDownMoisNaissance.ClearSelection();
                DropDownMoisNaissance.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        private int AnnéeNaissance
        {
            get
            {
                return int.Parse(DropDownAnnéeNaissance.SelectedItem.Value);
            }
            set
            {
                this.PopulerAnnée();
                DropDownAnnéeNaissance.ClearSelection();
                DropDownAnnéeNaissance.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        private int JourPassage
        {
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
            set
            {
                this.PopulerJours();
                DropDownJourPassage.ClearSelection();
                DropDownJourPassage.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        private int MoisPassage
        {
            get
            {
                return int.Parse(DropDownMoisPassage.SelectedItem.Value);
            }
            set
            {
                this.PopulerMois();
                DropDownMoisPassage.ClearSelection();
                DropDownMoisPassage.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

        private int AnnéePassage
        {
            get
            {
                return int.Parse(DropDownAnnéePassage.SelectedItem.Value);
            }
            set
            {
                this.PopulerAnnée();
                DropDownAnnéePassage.ClearSelection();
                DropDownAnnéePassage.Items.FindByValue(value.ToString()).Selected = true;
            }
        }

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

        private void PopulerJours()
        {
            DropDownJourNaissance.Items.Clear();
            DropDownJourPassage.Items.Clear();
            ListItem lt = new ListItem();
            lt.Text = "Jour";
            lt.Value = "0";
            DropDownJourNaissance.Items.Add(lt);
            DropDownJourPassage.Items.Add(lt);
            int days = DateTime.DaysInMonth(this.AnnéeNaissance, this.MoisNaissance);
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

        private void PopulerMois()
        {
            DropDownMoisNaissance.Items.Clear();
            DropDownMoisPassage.Items.Clear();
            ListItem lt = new ListItem();
            lt.Text = "Mois";
            lt.Value = "0";
            DropDownMoisNaissance.Items.Add(lt);
            DropDownMoisPassage.Items.Add(lt);
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

        private void PopulerAnnée()
        {
            DropDownAnnéeNaissance.Items.Clear();
            DropDownAnnéePassage.Items.Clear();
            ListItem lt = new ListItem();
            lt.Text = "Année";
            lt.Value = "0";
            DropDownAnnéeNaissance.Items.Add(lt);
            DropDownAnnéePassage.Items.Add(lt);
            for (int i = DateTime.Now.Year; i >= 1950; i--)
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

        protected void AjouterNumTel_Click(object sender, EventArgs e)
        {
            numIdTextBoxTel++;

            var newLabel = new Label();
            var newTextbox = new TextBox();

            // textbox needs a unique id to maintain state information
            newTextbox.ID = "TextBoxTéléphone" + numIdTextBoxTel;

            newLabel.Text = "Numéro de téléphone " + numIdTextBoxTel;

            // add the label and textbox to the panel, then add the panel to the form
            Téléphones.Controls.Add(newLabel);
            Téléphones.Controls.Add(newTextbox);
        }

        protected void AjouterAdd_Click(object sender, EventArgs e)
        {
            numIdTextBoxAdd++;

            var newLabel = new Label();
            var newTextbox = new TextBox();

            // textbox needs a unique id to maintain state information
            newTextbox.ID = "TextBoxAddresse" + numIdTextBoxAdd;

            newLabel.Text = "Addresse " + numIdTextBoxAdd;

            // add the label and textbox to the panel, then add the panel to the form
            Addresses.Controls.Add(newLabel);
            Addresses.Controls.Add(newTextbox);
        }


        public enum Grade { Blanche, Jaune, Orange, Verte, Bleu, Marron, Noire, Rouge };
        public enum Catégorie { U10, U12, U14, U16, U18, U21, Sénior, Vétéran };

        int IDMembre = 1;

        protected void Incription_Click(object sender, EventArgs e)
        {
            int numMembre = GénérerNumMembre();
            string nom = TextBoxNom.Text;
            string prénom = TextBoxPrénom.Text;
            DateTime dateNaissance = new DateTime(Int32.Parse(DropDownAnnéeNaissance.SelectedValue.ToString()),
                Int32.Parse(DropDownMoisNaissance.SelectedValue.ToString()), Int32.Parse(DropDownJourNaissance.SelectedValue.ToString()));
            int numAssuranceMaladie = Int32.Parse(TextBoxNumAM.Text);
            int numPasseport = Int32.Parse(TextBoxNumPC.Text);
            List<string> numTéléphones = CréerListe(numIdTextBoxTel, "TextBoxTéléphone");
            List<string> addresses = CréerListe(numIdTextBoxAdd, "TextBoxAddresse");
            Grade grade = (Grade)Enum.Parse(typeof(Grade), DDGrade.Text);
            DateTime datePassage = new DateTime(Int32.Parse(DropDownAnnéePassage.SelectedValue.ToString()),
                Int32.Parse(DropDownMoisPassage.SelectedValue.ToString()), Int32.Parse(DropDownJourPassage.SelectedValue.ToString()));
            Catégorie catégorie = (Catégorie)Enum.Parse(typeof(Catégorie), DropDownListCatégorie.Text);
            DateTime dateInscription = DateTime.Today;
            string cours = DropDownListCours.Text;

            //ajouter dans la bd
        }

        List<string> CréerListe(int numId, string nomTextBox)
        {
            List<string> li = new List<string>();

            for (int i = 0; i <= numId; i++)
            {

                TextBox t = (TextBox)Page.FindControl(nomTextBox + i.ToString());
                li.Add(t.Text);
            }

            return li;
        }

        int GénérerNumMembre()
        {
            return IDMembre++;
        }
    }
}