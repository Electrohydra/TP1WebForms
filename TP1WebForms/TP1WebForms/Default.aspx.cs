using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace TP1WebForms
{/*
    [Serializable]
    public class Activité
    {
        public string nomActivité { get; set; }
        public int âgeMin { get; set; }
        public string date { get; set; }
        public string heureDébut { get; set; }
        public string heureFin { get; set; }

        public Activité(string n, int a, string d, string hd, string hf)
        {
            nomActivité = n;
            âgeMin = a;
            date = d;
            heureDébut = hd;
            heureFin = hf;
        }

        public static List<Activité> getDetails()
        {
            /*Activité p1 = new Activité("John", 21, "24our", "12h", "13h");
            Activité p2 = new Activité("Smith", 22, "24our", "12h", "13h");
            Activité p3 = new Activité("Cena", 23, "24our", "12h", "13h");
            List<Activité> li = new List<Activité>();
            li.Add(p1);
            li.Add(p2);
            li.Add(p3);
            return li;
        }
    }*/

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridViewActivités.DataSource = Activité.getDetails();
            //GridViewActivités.DataBind();
        }
    }
}