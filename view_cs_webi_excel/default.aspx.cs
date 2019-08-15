using CrystalDecisions.Enterprise;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SimpleWebiXLSViewer
{	
    /*
     * Log onto Enterprise using client-supplied logon credentials, retrieve
     * the Webi SI_ID value and save in HTTP Session, then redirect to viewer page.
     */
	public partial class _default : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void btnSubmit_Click(object sender, System.EventArgs e) 
        {
            /*
             * Log onto BusinessObjects Enterprise.
             */
            EnterpriseSession boEnterpriseSession = (EnterpriseSession)Session["EnterpriseSession"];
            if (boEnterpriseSession == null) {
                try {
                    boEnterpriseSession = (new SessionMgr()).Logon(txtUserName.Text, txtPassword.Text, txtCMSName.Text, lstAuthType.SelectedItem.Value);
                } catch (Exception ex) {
                    Session["ErrorMessage"] = "Error encountered logging onto BusinessObjects Enterprise: "
                                              + ex.Message;
                    Response.Redirect("ErrorPage.aspx");
                }
            }
            
            // Store EnterpriseSession object in HTTP Session, to keep the EnterpriseSession alive.
            Session["EnterpriseSession"] = boEnterpriseSession;


            /*
             * Retrieve Web Intelligence document SI_ID and redirect to the viewer page.
             */

            InfoStore boInfoStore = new InfoStore(boEnterpriseSession.GetService("InfoStore"));

            InfoObjects boInfoObjects = boInfoStore.Query("Select SI_ID From CI_INFOOBJECTS Where SI_KIND='Webi' And SI_NAME='" + txtWebiName.Text + "'");

            if (boInfoObjects.Count == 0) {
                Session["ErrorMessage"] = "Web Intelligence Report '" + txtWebiName.Text + "' not found.";
                Response.Redirect("ErrorPage.aspx");
            }

            /*
             * Save Web Intelligence SI_ID in HTTP Session and redirect to the viewer page.
             */

            Session["WebiID"] = boInfoObjects[1].ID;

            Response.Redirect("ViewWebiXLS.ashx");

		}
	}
}
