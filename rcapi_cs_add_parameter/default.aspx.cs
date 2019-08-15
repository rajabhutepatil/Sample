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

namespace rcapi_cs_add_parameter
{
	/// <summary>
	/// Summary description for _default.
	/// </summary>
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtCMSName;
		protected System.Web.UI.WebControls.TextBox txtUserName;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.DropDownList lstAuthType;
		protected System.Web.UI.WebControls.Button submitBtn;
		protected System.Web.UI.HtmlControls.HtmlForm sampleForm;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void submitBtn_Click(object sender, System.EventArgs e)
		{
			string queryString;

			queryString = "?username=" + txtUserName.Text;
			queryString += "&password=" + txtPassword.Text;
			queryString += "&cms=" + txtCMSName.Text;
			queryString += "&authtype=" + lstAuthType.SelectedValue;

			Response.Redirect("Viewer.aspx" + queryString);
		}
	}
}
