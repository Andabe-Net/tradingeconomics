<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="nigeria.aspx.cs" Inherits="TradeSpace.nigeria" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--javascript code used--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find
                ("tr:first"))).dataTable({
                    "order": [0, 'asc'],
                    "pageLength": 5
                });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <center>
            <img src="imgs/foreground1.png" class="d-block img-fluid" />
        </center>

    </div>
    <br />
    <br />
    <br />
    <br />
    <div class="container-fluid">
        <center>
            <img src="imgs/nigeriaflag.png" class="d-block img-fluid" />
        </center>

    </div>

    <div class="container">
        <div class="row">
            <div class="col">
            </div>
        </div>

        <asp:GridView ID="GridViewNigeria" class="table table-responsive table-striped" runat="server" BackColor="White" ForeColor="#006600" GridLines="Horizontal" HeaderStyle-ForeColor="White" CellSpacing="4" HeaderStyle-BackColor="#006600" HeaderStyle-BorderColor="#339966" BorderStyle="None"></asp:GridView>

    </div>
</asp:Content>
