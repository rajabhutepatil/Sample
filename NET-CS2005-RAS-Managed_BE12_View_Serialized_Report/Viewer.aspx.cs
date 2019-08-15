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

using CrystalDecisions.Enterprise;
using CrystalDecisions.ReportAppServer.ClientDoc;

public partial class Viewer : System.Web.UI.Page
{

    CrystalDecisions.Enterprise.EnterpriseSession boEnterpriseSession;
    CrystalDecisions.Enterprise.InfoObject boInfoObject;
    CrystalDecisions.ReportAppServer.ClientDoc.ReportClientDocument boReportClientDocument;

    protected void Page_Load(object sender, EventArgs e)
    {
        CrystalDecisions.Enterprise.SessionMgr boSessionMgr = new CrystalDecisions.Enterprise.SessionMgr();
        CrystalDecisions.Enterprise.InfoStore boInfoStore;
        CrystalDecisions.Enterprise.EnterpriseService boEnterpriseService;
        CrystalDecisions.Enterprise.InfoObjects boInfoObjects;
        string boReportName;
        string boQuery;
        CrystalDecisions.ReportAppServer.ClientDoc.ReportAppFactory boReportAppFactory;
        CrystalDecisions.ReportAppServer.Utilities.Conversion boConversion = new CrystalDecisions.ReportAppServer.Utilities.Conversion();

        if (ViewState["boEnterpriseSession"] != null)
        {
            boEnterpriseSession = boSessionMgr.GetSession(ViewState["boEnterpriseSession"].ToString());
        }
        else
        {
            //Log on to the Enterprise CMS
            boEnterpriseSession = boSessionMgr.Logon(Request.QueryString["username"], Request.QueryString["password"], Request.QueryString["cms"], Request.QueryString["authtype"]);
            ViewState.Add("boEnterpriseSession", boEnterpriseSession);
        }

        //get report object from session or create a new report object
        if (ViewState["boSerializedReport"] != null)
        {
            //Reconstruct the serialized ReportClientDocument
            string boSerializedReport = ViewState["boSerializedReport"].ToString();
            boReportClientDocument = (ReportClientDocument)boConversion.ToReportClientDocument(boSerializedReport);
        }
        else
        {
            boEnterpriseService = boEnterpriseSession.GetService("", "InfoStore");
            boInfoStore = new CrystalDecisions.Enterprise.InfoStore(boEnterpriseService);

            boReportName = "World Sales Report";

            //Retrieve the report object from the InfoStore, only need the SI_ID for RAS
            boQuery = "Select SI_ID From CI_INFOOBJECTS Where SI_NAME = '" + boReportName +
                "' AND SI_Instance=0";
            boInfoObjects = boInfoStore.Query(boQuery);
            boInfoObject = boInfoObjects[1];

            boEnterpriseService = null;

            //Retrieve the RASReportFactory
            boEnterpriseService = boEnterpriseSession.GetService("RASReportFactory");
            boReportAppFactory = (CrystalDecisions.ReportAppServer.ClientDoc.ReportAppFactory)boEnterpriseService.Interface;
            //Open the report from Enterprise
            boReportClientDocument = boReportAppFactory.OpenDocument(boInfoObject.ID, 0);

            //Serialize the ReportClientDocument
            string boSerializedReport = boConversion.ToString(boReportClientDocument);
            //Add the reportClientDocument to session
            ViewState.Add("boSerializedReport", boSerializedReport);
        }

        //Set the ReportSource of the viewer to the report in Session
        boCrystalReportViewer.ReportSource = boReportClientDocument;
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        boReportClientDocument.Close();
        boEnterpriseSession.Logoff();
        Response.Redirect("Default.aspx");
    }
}
