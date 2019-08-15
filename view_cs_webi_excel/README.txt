Business Objects Technical Customer Assurance

SAMPLE - view_cs_webi_excel.zip


SYSTEM REQUIREMENTS

	The minimum requirements for this application are
	- Microsoft C# .NET 2005
	- BusinessObjects Enterprise XI Release 2


DESCRIPTION

    This sample illustrates how to display a Webi Intelligence document in Excel format.

FILES

	- default.aspx	
	- default.aspx.cs
	- ErrorPage.aspx
	- ErrorPage.aspx.cs
	- README.txt
	- style.css
	- ViewWebiXLS.ashx
	- Web.config


ASSEMBLIES
    - BusinessObjects.ReportEngine
    - BusinessObjects.ReportEngine.WI
    - CrystalDecisions.Enterprise.Framework
    - CrystalDecisions.Enterprise.InfoStore


INSTALLATION

	1. This is a file system web project for Visual Studio .NET 2005 so 
	IIS is not required.
	2. Copy the "view_cs_webi_excel" folder to your Desktop.
	3. Run Visual Studio .NET 2005 and select File-> Open-> Web Site...
	4. On the left select "File System", then navigate to the "view_cs_webi_excel" folder
	on the Desktop.
	5. Click Open.
	6. Set the start page to "default.aspx" by right clicking on the "default.aspx" 
	file in the Solution Explorer and selecting "Set as Start Page".
	7. From the Debug menu, select "Start" to run the application. 


Last updated on April 17, 2007