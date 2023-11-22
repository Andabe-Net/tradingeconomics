<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="TradeSpace.homepage" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--javascript code--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find
                ("tr:first"))).dataTable({
                    "order": [[1, 'asc'], [2, 'asc']],
                    "pageLength": 6
                });
        });
    </script>


</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <center>
            <img src="imgs/foreground1.png" class="d-block img-fluid" />
        </center>

    </div>
    <br />
    <br />

    <div class="container-fluid">
        <center>
            <img src="imgs/worldshake.png" class="d-block img-fluid" />
        </center>
    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <asp:GridView ID="GridViewAllCountries" class="table table-responsive table-striped" runat="server" AutoGenerateColumns="True" BorderColor="White" Caption="  ~~Insights Into World Economies Ranking" GridLines="Horizontal" HeaderStyle-BorderColor="#FFCC99" CaptionAlign="Top" BackColor="#333333" CellPadding="-1" ForeColor="#66FF66" HeaderStyle-BackColor="#666633" HeaderStyle-ForeColor="#CCCCCC" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="NotSet" BorderStyle="None"></asp:GridView>

            </div>
        </div>

    </div>


</asp:Content>
