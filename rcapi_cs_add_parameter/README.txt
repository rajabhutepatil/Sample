Business Objects Technical Customer Assurance

SAMPLE - rcapi_cs_add_parameter.zip


SYSTEM REQUIREMENTS

	The minimum requirements for this application are
	- Microsoft C# .NET 2003
	- BusinessObjects Enterprise XI Release 2
	- Crystal Reports XI Release 2


DESCRIPTION

	This is a sample application that shows how to add a parameter to an existing
	report using Business Objects Enterprise XI release 2.  This application 
	requires the report SimpleRCAPIReport.rpt to be published into your Enterprise
	system.  


FILES

	- default.aspx	
	- default.aspx.cs
	- default.aspx.resx
	- rcapi_cs_add_parameter.csproj
	- rcapi_cs_add_parameter.csproj.webinfo
	- README.txt
	- SimpleRCAPIReport.rpt
	- style.css
	- viewer.aspx	
	- viewer.aspx.cs
	- viewer.aspx.resx
	- Web.config


ASSEMBLIES

	- CrystalDecisions.Enterprise
	- CrystalDecisions.Enterprise.Framework
	- CrystalDecisions.Enterprise.InfoStore
	- CrystalDecisions.Web
	- CrystalDecisions.ReportAppServer.ClientDoc
	- CrystalDecisions.ReportAppServer.Controllers
	- CrystalDecisions.ReportAppServer.DataDefModel
	- CrystalDecisions.ReportAppServer.ReportDefModel


INSTALLATION

	1. Copy the "rcapi_cs_add_parameter" folder to the "C:\inetpub\wwwroot" directory.
	2. Configure the "rcapi_cs_add_parameter" directory as an application in Internet
	Information Services.
		a)  From the START menu, select Run, type "inetmgr" and click "OK" to load 
		the IIS Manager.
		b)  Expand the server node and you will see the Default Web Site node. 
		c)  Right-click on the "rcapi_cs_add_parameter" node and select "Properties".
		d)  In the Properties window, click on the "Create" button and click "OK" to 
		close the window.
	3. Open Windows Explorer and navigate to "C:\inetpub\wwwroot\rcapi_cs_add_parameter" 
	and double click on the "rcapi_cs_add_parameter.csproj" file to open the project.
	4. Set the start page to "default.aspx" by right clicking on the "default.aspx" 
	file in the Solution Explorer and selecting "Set as Start Page".
	5. Publish the report SimpleRCAPIReport.rpt to your Enterprise system.
	5. From the Debug menu, select "Start" to run the application. 


TECH ID: STO
Last updated on May 11, 2007