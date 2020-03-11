<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Contadores._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 503px;
        }
        #buscarbtn {
            width: 89px;
            position:relative;
            top:76px;
            
        }

    </style>
    <body>
        <div style="height: 467px; width: 461px" id="div1">
             <p style="position:relative;"><b>Select option:</b></p>
            <asp:DropDownList CssClass="form-control" runat="server" ID="options" Width="152px" OnSelectedIndexChanged="loadOptions" AutoPostBack="true">
                <asp:ListItem Text="Light meter" Value="0"></asp:ListItem>
                <asp:ListItem Text="Water meter" Value="1"></asp:ListItem>
                <asp:ListItem Text="Gateway" Value="2"></asp:ListItem>
            </asp:DropDownList>

        </div>
        <div style="background-color:darkseagreen; position:relative; top: -350px; left: 0px; height: 312px; width: 461px;" id="div2">  
            <p>
                <asp:Panel  runat="server" Id="serialNumer"><b>Serial Number:</b></asp:Panel>
                <asp:TextBox  runat="server" Id="serialNumerBox"></asp:TextBox>
            </p>
            <p>
                <asp:Panel  runat="server" Id="brand"><b>Brand:</b></asp:Panel>
                <asp:TextBox  runat="server" Id="brandBox"></asp:TextBox>
            </p>
            <p>
                <asp:Panel  runat="server" Id="model"><b>Model:</b></asp:Panel>
                <asp:TextBox runat="server" Id="modelBox"/>
                
            </p>
            <p>
                <asp:Panel Visible="false" style="position:relative;" runat="server" Id="ip" pattern="^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$"><b>IP:</b></asp:Panel>
                <asp:TextBox Visible="false" runat="server" Id="ipBox"></asp:TextBox>
            </p>
            <p>
                <asp:Panel Visible="false" style="position:relative;" runat="server" Id="port"><b>Port:</b></asp:Panel>
                <asp:TextBox Visible="false" runat="server" Id="portBox"></asp:TextBox>
            </p>
            <asp:Button id="addBtn" Text="Add" OnClick="add_Click" runat="server"/>
        </div>
        <div style="background-color:cadetblue; position:relative; bottom: 750px; left: 550px; height: 450px; width: 650px;" id="showMeters">
            <p><b>Gateways</b></p>
             <asp:GridView ID="GridView_Gateways" runat="server" BackColor="White"
             BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
             HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="scrolling-table-container">
                  <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="serialNumber" HeaderText="Serial Number" />
                    <asp:BoundField DataField="brand" HeaderText="Brand" />
                    <asp:BoundField DataField="model" HeaderText="Model" />
                    <asp:BoundField DataField="ip" HeaderText="IP" />
                    <asp:BoundField DataField="port" HeaderText="Port" />
                 </Columns>
            </asp:GridView>
            </p>
            <p><b>Meters</b></p>
             <asp:GridView ID="GridView_Meters" runat="server" BackColor="White"
             BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
             HorizontalAlign="Center" AutoGenerateColumns="False"  CssClass="scrolling-table-container">
                  <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="serialNumber" HeaderText="Serial Number" />
                    <asp:BoundField DataField="brand" HeaderText="Brand" />
                    <asp:BoundField DataField="model" HeaderText="Model" />
                 </Columns>
            </asp:GridView>
            </p>
        </div>
    </body>
    </html>

</asp:Content>
