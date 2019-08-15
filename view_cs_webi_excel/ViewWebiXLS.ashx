<%@ WebHandler Language="C#" Class="SimpleWebiXLSViewer.ViewWebiXLS" %>

using BusinessObjects.ReportEngine;
using BusinessObjects.ReportEngine.WI;
using CrystalDecisions.Enterprise;
using System;
using System.Web;
using System.Web.SessionState;


namespace SimpleWebiXLSViewer
{
     /** Open Web Intelligence report with SI_ID given by Session attribute "WebiID" using RE.NET
      * and stream it in Excel format to the client web browser.
      */
    public class ViewWebiXLS : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context) {

            EnterpriseSession boEnterpriseSession = null;
            ReportEngines boReportEngines = null;

            try {
                
                /*
                 * Open Web Intelligence Document with ReportEngine and refresh the report.
                 */
                
                boEnterpriseSession = (EnterpriseSession) context.Session["EnterpriseSession"];
                boReportEngines = new ReportEngines(boEnterpriseSession.LogonTokenMgr.DefaultToken);

                IReportEngine boIReportEngine = (IReportEngine) boReportEngines.getService(ReportEngineType.WI_ReportEngine);

                int id = Convert.ToInt32(context.Session["WebiID"]);
                IDocumentInstance boIDocumentInstance = boIReportEngine.OpenDocument(id);
                boIDocumentInstance.Refresh();

                // boIDocumentInstance.MustFillPassword not supported with RE.NET version when this sample created.
                //if (boIDocumentInstance.MustFillPassword) {
                //    Session["ErrorMessage"] = "Context Prompts not supported in this sample.";
                //    Response.Redirect("ErrorPage.aspx");
                //}

                // Flag error for functionality not supported in this sample.
                if (boIDocumentInstance.MustFillContextPrompts) {
                    context.Session["ErrorMessage"] = "Context Prompts not supported in this sample.";
                    context.Response.Redirect("ErrorPage.aspx");
                }

                if (boIDocumentInstance.MustFillPrompts) {
                    context.Session["ErrorMessage"] = "Prompts not supported in this sample.";
                    context.Response.Redirect("ErrorPage.aspx");
                }

                /*
                 * Retrieve Excel format of document and stream out to client web browser.
                 */

                IBinaryView boIBinaryView = (IBinaryView)boIDocumentInstance.GetView(OutputFormatType.Xls);
                
                context.Response.ContentType = "application/vmd.ms-excel";
                context.Response.AddHeader("Content-disposition", "attachment;filename=document.xls");
                boIBinaryView.WriteContent(context.Response.OutputStream);
                
                
                // Close document.
                boIDocumentInstance.CloseDocument();
                
            } finally {
                
                /* 
                 * Close ReportEngine and log off.
                 */
                if (boReportEngines != null)
                    boReportEngines.Close();
                if (boEnterpriseSession != null)
                    boEnterpriseSession.Logoff();
                context.Session["EnterpriseSession"] = null;
                context.Session["WebiID"] = null;
            }
        }

        public bool IsReusable {
            get {
                return true;
            }
        }

    }
}