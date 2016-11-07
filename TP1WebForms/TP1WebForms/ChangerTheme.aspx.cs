using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1WebForms
{
    public partial class ChangerTheme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            // Enregistrer le thème
            if (!String.IsNullOrEmpty(Request["Theme"]))
            {
                // Conserver le thème dans le ViewState
                //ViewState["SelectedTheme"] = Server.HtmlEncode(Request["Theme"]);

                // Conserver le thème en Session
                //Session["SelectedTheme"] = Server.HtmlEncode(Request["Theme"]);

                // Conserver le thème dans l'Application
                Application["SelectedTheme"] = Server.HtmlEncode(Request["Theme"]);

                //TODO: Conserver le thème dans le profil
                //HttpContext.Current.Profile.SetPropertyValue("SelectedTheme", Server.HtmlEncode(Request["Theme"]));
                //Profile.Personalization.SelectedTheme = Server.HtmlEncode(Request["Theme"]);
            }


            // Appeller BasePage PreInit pour appliquer le thème
            base.OnPreInit(e);
        }
    }
}