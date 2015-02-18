<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="Default.aspx.cs" Inherits="SvgFloorPlanner._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base href="/" />
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <title>Embedded Firebird Database-Engine-Test</title>
    <meta name="description" content=""/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />

    <style type="text/css" media="all">
        html{height: 100%;}
        body{height: 100%; margin: 0px; padding: 0px; background-color: #FFFFFF; height: 100%;} 
        form{height: 100%; margin: 0px; padding: 0px; background-color: #FFFFFF; height: 100%;} 

        
        #dgvData table
        {
            border: 1px solid black;
            border-collapse: collapse;
        }
        

        #dgvData td
        {
            border: 1px solid black;
            white-space: nowrap;
            min-width: 50px;
            padding-left: 0.25cm;
            padding-right: 0.25cm;
        }
        
        
        #dgvData th
        {
            border: 1px solid black;    
            background-color: Black;
            color: White;
            font-weight: bold;
            text-transform: uppercase;
            text-align: left;
            padding-left: 0.25cm;
            padding-right: 0.25cm;
            text-shadow: #BCBCBC 2px 2px 2px;
        }
        
        
        #dgvData tr:nth-child(2n)#dgvData   {background-color: #FFFFFF;}
        #dgvData tr:nth-child(2n+1) {background-color: #EEEEEE;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-left: 0.25cm; padding-right: 0.25cm;">
            <h4 style="text-transform: uppercase;">Testing the embedded Firebird database engine</h4>
            <asp:GridView ID="dgvData" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
