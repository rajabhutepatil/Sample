SAP Business Objects Technical Customer Assurance

SAMPLE - NET-CS2005-RAS-Managed_BE12_View_Serialized_Report.zip


SYSTEM REQUIREMENTS

	The minimum requirements for this application are
	- Microsoft C# .NET 2005
	- BusinessObjects Enterprise XI 3.1
	- Crystal Reports 2008


DESCRIPTION

	This is a sample application that shows how to view a serialized report using Business Objects 
	Enterprise XI 3.1.


FILES

	- Default.aspx	
	- Default.aspx.cs
	- README.txt
	- style.css
	- viewer.aspx	
	- viewer.aspx.cs
	- Web.config


ASSEMBLIES

	- CrystalDecisions.Enterprise
	- CrystalDecisions.Enterprise.Framework
	- CrystalDecisions.Enterprise.InfoStore
	- CrystalDecisions.Web
	- CrystalDecisions.ReportAppServer.ClientDoc

INSTALLATION

	1. Copy the "NET-CS2005-RAS-Managed_BE12_View_Serialized_Report" folder to the "C:\inetpub\wwwroot" directory.
	2. Configure the "NET-CS2005-RAS-Managed_BE12_View_Serialized_Report" directory as an application in Internet
	Information Services.
		a)  From the START menu, select Run, type "inetmgr" and click "OK" to load 
		the IIS Manager.
		b)  Expand the server node and you will see the Default Web Site node. 
		c)  Right-click on the "NET-CS2005-RAS-Managed_BE12_View_Serialized_Report" node and select "Properties".
		d)  In the Properties window, click on the "Create" button and click "OK" to 
		close the window.
	3. Open Visual Studio 2005 and go to File -> Open -> Web Site.
	4. Browse through Local IIS and select NET-CS2005-RAS-Managed_BE12_View_Serialized_Report and click Open.
	5. Set the start page to "Default.aspx" by right clicking on the "Default.aspx" 
	file in the Solution Explorer and selecting "Set as Start Page".
	6. From the Debug menu, select "Start" to run the application. 


TECH ID: STO
Last updated on June 2, 2009