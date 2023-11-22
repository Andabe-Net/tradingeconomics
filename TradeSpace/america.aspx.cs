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

//BELOW ARE THE STEPS FOR MY SOLUTION...THAT OBTAINS AND DISPLAYS INFORMATION FOR THE UNITED STATES SORTED BY CATEGORY IN THE AMERICA PAGE
//THIS PAGE FIRST ATTEMPTS TO CALL THE API DIRECTLY, IF ANY ERROR OCCURS THEN  DATA IS READ FROM LOCAL DIRECTORY

namespace TradeSpace
{
    public partial class america : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            await ReadAmericaData();
        }

        async Task ReadAmericaData()
        {
            //attempts to call Trading Economics API
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.tradingeconomics.com---thisiswrongAPIEndPoint"))
                    {
                        request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
                        var response = await httpClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();

                            DataTable americaDataTable = JsonConvert.DeserializeObject<DataTable>(content);
                            DataTable FilteredTable = americaDataTable.DefaultView.ToTable(true, "Category", "LatestValue", "PreviousValue", "Frequency", "LatestValueDate", "PreviousValueDate", "Source", "Unit");

                            GridViewAmerica.DataSource = FilteredTable;
                            GridViewAmerica.AutoGenerateColumns = true;
                            GridViewAmerica.DataBind();
                        }
                    }
                }

            }

            //attempts to load data from local storage if API call fails
            catch (Exception ex)
            {
                try
                {
                    StreamReader readsAmerica = new StreamReader(Server.MapPath("~/countriesdata/country_data_1.json"));

                    DataTable americaData = JsonConvert.DeserializeObject<DataTable>(readsAmerica.ReadToEnd());
                    DataTable FilteredTable = americaData.DefaultView.ToTable(true, "Category", "LatestValue", "PreviousValue", "Frequency", "LatestValueDate", "PreviousValueDate", "Source", "Unit");

                    GridViewAmerica.DataSource = FilteredTable;
                    GridViewAmerica.AutoGenerateColumns = true;
                    GridViewAmerica.DataBind();
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