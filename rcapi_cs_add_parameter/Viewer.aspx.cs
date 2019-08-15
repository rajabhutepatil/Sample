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
	/// Summary description for Viewer.
	/// </summary>
	public class Viewer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button CloseButton;
		protected CrystalDecisions.Web.CrystalReportViewer boCrystalReportViewer;

		CrystalDecisions.Enterprise.EnterpriseSession boEnterpriseSession;
		CrystalDecisions.Enterprise.InfoObject boInfoObject;
		CrystalDecisions.ReportAppServer.ClientDoc.ReportClientDocument boReportClientDocument;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			CrystalDecisions.Enterprise.SessionMgr boSessionMgr;
			CrystalDecisions.Enterprise.InfoStore boInfoStore;
			CrystalDecisions.Enterprise.EnterpriseService boEnterpriseService;
			CrystalDecisions.Enterprise.InfoObjects boInfoObjects;
			string boReportName;
			string boQuery;
			CrystalDecisions.ReportAppServer.ClientDoc.ReportAppFactory boReportAppFactory;
			CrystalDecisions.ReportAppServer.DataDefModel.ParameterField boParameterField;
			CrystalDecisions.ReportAppServer.ReportDefModel.Section boSection;
			CrystalDecisions.ReportAppServer.ReportDefModel.FieldObject boFieldObject;

			if(Session["boEnterpriseSession"] != null)
			{
				boEnterpriseSession = (CrystalDecisions.Enterprise.EnterpriseSession)Session["boEnterpriseSession"];
			}
			else
			{
				//Log on to the Enterprise CMS
				boSessionMgr = new CrystalDecisions.Enterprise.SessionMgr();
				boEnterpriseSession = boSessionMgr.Logon(Request.QueryString["username"], Request.QueryString["password"], Request.QueryString["cms"], Request.QueryString["authtype"]);
				Session.Add("boEnterpriseSession", boEnterpriseSession);
			}

			//get report object from session or create a new report object
			if (Session["boReportClientDocument"] != null)
			{
				boReportClientDocument = (CrystalDecisions.ReportAppServer.ClientDoc.ReportClientDocument)Session["boReportClientDocument"];
			}
			else
			{
				boEnterpriseService = boEnterpriseSession.GetService("", "InfoStore");
				boInfoStore = new CrystalDecisions.Enterprise.InfoStore(boEnterpriseService);

				boReportName = "SimpleRCAPIReport.rpt";

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

				//Create a parameter field.
				boParameterField = new CrystalDecisions.ReportAppServer.DataDefModel.ParameterField();
				//Set its name.
				boParameterField.Name = "boParameterField";
				//set its type.
				boParameterField.Type = CrystalDecisions.ReportAppServer.DataDefModel.CrFieldValueTypeEnum.crFieldValueTypeStringField;
				//add it to the report definition.
				boReportClientDocument.DataDefController.ParameterFieldController.Add(boParameterField);
				//This will not prompt as the parameter is not yet in use. We will have to add it to the report first

				//get the section we want to use.  In this case the report header.
				boSection = boReportClientDocument.ReportDefController.ReportDefinition.ReportHeaderArea.Sections[0];

				//Create a new field object.
				boFieldObject = new CrystalDecisions.ReportAppServer.ReportDefModel.FieldObject();
				//set where to get the data from. (The parameter field name.)
				boFieldObject.DataSourceName = "{?boParameterField}";
				//set the type.
				boFieldObject.FieldValueType = CrystalDecisions.ReportAppServer.DataDefModel.CrFieldValueTypeEnum.crFieldValueTypeStringField;
				//set the location
				boFieldObject.Top = 120;
				boFieldObject.Left = 3000;
				//set the size
				boFieldObject.Height = 240;
				boFieldObject.Width = 2115;
				//set the font info.
				boFieldObject.FontColor = new CrystalDecisions.ReportAppServer.ReportDefModel.FontColor();
				boFieldObject.FontColor.Font.Name = "Arial";
				boFieldObject.FontColor.Font.Size = 10;
				//set the alignment
				boFieldObject.Format.HorizontalAlignment = CrystalDecisions.ReportAppServer.ReportDefModel.CrAlignmentEnum.crAlignmentLeft;
				//add the field to the report header.
				boReportClientDocument.ReportDefController.ReportObjectController.Add(boFieldObject, boSection, -1);

				//Add the reportClientDocument to session
				Session.Add("boReportClientDocument", boReportClientDocument);
			}

			//Set the ReportSource of the viewer to the report in Session
			boCrystalReportViewer.ReportSource = Session["boReportClientDocument"];
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
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void CloseButton_Click(object sender, System.EventArgs e)
		{
			//Clean up your report session
			if(Session["boReportClientDocument"] != null)
			{
				boReportClientDocument = (CrystalDecisions.ReportAppServer.ClientDoc.ReportClientDocument)Session["boReportClientDocument"];
				boReportClientDocument.Close();
				boReportClientDocument = null;
				Session.Remove("boReportClientDocument");
			}

			//Clean up your enterprise session
			if (Session["boEnterpriseSession"] != null)
			{
				boEnterpriseSession = (CrystalDecisions.Enterprise.EnterpriseSession)Session["boEnterpriseSession"];
				boEnterpriseSession.Logoff();
				boEnterpriseSession.Dispose();
				boEnterpriseSession = null;
				Session.Remove("boEnterpriseSession");
			}

			Response.Redirect("default.aspx", true);
		}
	}
}
