<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="HiveMind.View.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>HiveMind</title>
    <%--Fonts--%>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Ubuntu:wght@300;400;500;700&display=swap" rel="stylesheet" />

    <%--Stylesheet--%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous" />
    <link rel="stylesheet" href="<%=Request.ApplicationPath+"/asset/stylesheet/color.css"%>" />
    <link rel="stylesheet" href="<%=Request.ApplicationPath+"/asset/stylesheet/utils.css"%>" />
    <link rel="stylesheet" href="<%=Request.ApplicationPath+"/asset/stylesheet/main.css"%>" />
</head>
<body>
    <form id="form1" runat="server" class="h-min-100-vh row w-100 p-0 m-0">
        <div class="content-panel col px-0 px-md-5 py-4 d-flex justify-content-between flex-column">
            <header class="px-3 px-md-0">
                <span id="logo" class="h1 font-weight-bold"><span>Hive</span>Mind</span>
            </header>
            <main class="flex-grow-1 justify-content-center align-items-center">
                <div class="d-flex flex-column justify-content-center align-items-center h-100">
                    <img src="<%=Request.ApplicationPath+"/asset/image/icon/error.png"%>" alt="Error Icon" /> 
                    <h1 class="h1">Error Occured</h1>
                    <p>Error occured. Report to customer support for more assistance</p>
                </div>
            </main>
        </div>
    </form>
</body>
</html>
