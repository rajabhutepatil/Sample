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
using CrystalDecisions.ReportAppServer.Controllers;
using CrystalDecisions.ReportAppServer.ReportDefModel;

public partial class Viewer : System.Web.UI.Page
{

    CrystalDecisions.Enterprise.EnterpriseSession boEnterpriseSession;
    CrystalDecisions.Enterprise.InfoObject boInfoObject;
    CrystalDecisions.ReportAppServer.ClientDoc.ReportClientDocument boReportClientDocument;

    protected void Page_Load(object sender, EventArgs e)
    {
        CrystalDecisions.Enterprise.SessionMgr boSessionMgr;
        CrystalDecisions.Enterprise.InfoStore boInfoStore;
        CrystalDecisions.Enterprise.EnterpriseService boEnterpriseService;
        CrystalDecisions.Enterprise.InfoObjects boInfoObjects;
        string boReportName;
        string boQuery;
        CrystalDecisions.ReportAppServer.ClientDoc.ReportAppFactory boReportAppFactory;

        //Log on to the Enterprise CMS
        boSessionMgr = new CrystalDecisions.Enterprise.SessionMgr();
        boEnterpriseSession = boSessionMgr.Logon(Request.QueryString["username"], Request.QueryString["password"], Request.QueryString["cms"], Request.QueryString["authtype"]);
        Session.Add("boEnterpriseSession", boEnterpriseSession);
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

        ExportOptions exportOptions = new ExportOptions();
        //This sets which format we will export to.
        exportOptions.ExportFormatType = CrReportExportFormatEnum.crReportExportFormatMSExcel;
        //Create the FormatOptions class for PDF.
        ExcelExportFormatOptions ExcelexportOptions = new ExcelExportFormatOptions();
        ExcelexportOptions.BaseAreaGroupNumber = 1;
        ExcelexportOptions.BaseAreaType = CrAreaSectionKindEnum.crAreaSectionKindReportHeader;
        ExcelexportOptions.ConstantColWidth = 20;
        ExcelexportOptions.ConvertDatesToStrings = true;
        ExcelexportOptions.StartPageNumber = 1;
        ExcelexportOptions.EndPageNumber = 5;
        ExcelexportOptions.ExcelTabHasColumnHeadings = true;
        ExcelexportOptions.ExportPageAreaPairType = CrExportPageAreaKindEnum.crExportPageAreaKindForEachPage;
        ExcelexportOptions.ExportPageBreaks = true;
        ExcelexportOptions.MaintainRelativeObjectPosition = true;
        ExcelexportOptions.ShowGridlines = false;
        ExcelexportOptions.UseConstantColWidth = true;

        //Set the export format options with the page range we just set.
        exportOptions.FormatOptions = ExcelexportOptions;

        //This exports the report to a byte() that we will stream out.
        Byte[] oByte = (Byte[])boReportClientDocument.PrintOutputController.ExportEx(exportOptions).ByteArray;

        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-disposition", "filename=MyReport.xls");
        Response.BinaryWrite(oByte);
        Response.End();

        boReportClientDocument.Close();
        boEnterpriseSession.Logoff();
    }
}
