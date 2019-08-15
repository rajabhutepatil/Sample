using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submitBtn_Click(object sender, EventArgs e)
    {
        string queryString;

        queryString = "?username=" + txtUserName.Text;
        queryString += "&password=" + txtPassword.Text;
        queryString += "&cms=" + txtCMSName.Text;
        queryString += "&authtype=" + lstAuthType.SelectedValue;

        Response.Redirect("Viewer.aspx" + queryString);
    }
}
