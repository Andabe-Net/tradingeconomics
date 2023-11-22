<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mexico.aspx.cs" Inherits="TradeSpace.countryPages.Mexico" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--javascript code--%>
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
            <img src="imgs/mexicoflag.png" class="d-block img-fluid" />
        </center>
    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <asp:GridView ID="GridViewMexico" class="table table-responsive table-striped" runat="server" GridLines="Horizontal" HeaderStyle-BackColor="#CC3300" HeaderStyle-ForeColor="White" BackColor="#339966" ForeColor="White" BorderStyle="None"></asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
