<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="america.aspx.cs" Inherits="TradeSpace.america" Async="true" %>

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
            <img src="imgs/usflag.png" class="d-block img-fluid" />
        </center>

    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <asp:GridView ID="GridViewAmerica" class="table table-responsive table-striped" runat="server" GridLines="Horizontal" HeaderStyle-BackColor="#003399" HeaderStyle-ForeColor="White" ForeColor="#990033" BorderColor="#CCCCCC" CellSpacing="4" BorderStyle="None"></asp:GridView>
            </div>
        </div>



    </div>
</asp:Content>
