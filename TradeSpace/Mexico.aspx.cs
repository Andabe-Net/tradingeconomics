using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//BELOW ARE THE STEPS FOR MY SOLUTION...THAT OBTAINS AND DISPLAYS INFORMATION FOR MEXICO SORTED BY CATEGORY IN THE MEXICO PAGE
//THIS PAGE FIRST ATTEMPTS TO CALL THE API DIRECTLY, IF ANY ERROR OCCURS THEN  DATA IS READ FROM LOCAL DIRECTORY



namespace TradeSpace.countryPages
{
    public partial class Mexico : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            await ReadMexicoData();
        }

        //defined function
        async Task ReadMexicoData()
        {
            //attempts to read data from TradingEconomics API
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.tradingeconomics.com/country/mexico?c=51bb232c06f049e:cfjz1i6i1vkm2m8"))
                    {
                        request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
                        var response = await httpClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();

                            DataTable mexicoDataTable = JsonConvert.DeserializeObject<DataTable>(content);
                            DataTable FilteredTable = mexicoDataTable.DefaultView.ToTable(true, "Category", "LatestValue", "PreviousValue", "Frequency", "LatestValueDate", "PreviousValueDate", "Source", "Unit");

                            GridViewMexico.DataSource = FilteredTable;
                            GridViewMexico.AutoGenerateColumns = true;
                            GridViewMexico.DataBind();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //reads data from local directory in the case of API call Failure
                try
                {
                    StreamReader readsMexico = new StreamReader(Server.MapPath("~/countriesdata/mexicofulldata.json"));

                    DataTable mexicoData = JsonConvert.DeserializeObject<DataTable>(readsMexico.ReadToEnd());
                    DataTable FilteredTable = mexicoData.DefaultView.ToTable(true, "Category", "LatestValue", "PreviousValue", "Frequency", "LatestValueDate", "PreviousValueDate", "Source", "Unit");

                    GridViewMexico.DataSource = FilteredTable;
                    GridViewMexico.AutoGenerateColumns = true;
                    GridViewMexico.DataBind();
                }
                catch (Exception e)
                {
                    Response.Write("<script>alert('" + ex.Message + "???" + e.Message + "');</script>");
                }

                Response.Write("<script>alert('You're Receiving this message because an Error may have occured with your Request...Please, click OK to Load Data from Local Server Storage');</script>");


            }
        }

    }
}