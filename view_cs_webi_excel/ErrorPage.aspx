<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="SimpleWebiXLSViewer.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Error</title>
</head>
<body>
    <h1>Error</h1>
    
    <p>The following error was encountered:</p>
    
    <p><%=errorMessage %></p>
    
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
