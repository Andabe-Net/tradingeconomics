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

//BELOW ARE THE STEPS FOR MY SOLUTION...THAT OBTAINS AND DISPLAYS INFORMATION FOR NIGERIA SORTED BY CATEGORY IN THE NIGERIA PAGE
//THIS PAGE FIRST ATTEMPTS TO CALL THE API DIRECTLY, IF ANY ERROR OCCURS THEN  DATA IS READ FROM LOCAL DIRECTORY

namespace TradeSpace
{
    public partial class nigeria : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            await ReadNigeriaData();
        }

        async Task ReadNigeriaData()
        {
            //attempts to call Trading Economics API
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.trading---thisiswrongAPIEndPoint"))
                    {
                        request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
                        var response = await httpClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();

                            DataTable nigeriaDataTable = JsonConvert.DeserializeObject<DataTable>(content);
                            DataTable FilteredTable = nigeriaDataTable.DefaultView.ToTable(true, "Category", "LatestValue", "PreviousValue", "Frequency", "LatestValueDate", "PreviousValueDate", "Source", "Unit");

                            GridViewNigeria.DataSource = FilteredTable;
                            GridViewNigeria.AutoGenerateColumns = true;
                            GridViewNigeria.DataBind();
                        }
                    }
                }

            }

            //attempts to load data from local storage if API call fails
            catch (Exception ex)
            {
                try
                {
                    StreamReader readsNigeria = new StreamReader(Server.MapPath("~/countriesdata/country_data_3.json"));

                    DataTable nigeriaData = JsonConvert.DeserializeObject<DataTable>(readsNigeria.ReadToEnd());
                    DataTable FilteredTable = nigeriaData.DefaultView.ToTable(true, "Category", "LatestValue", "PreviousValue", "Frequency", "LatestValueDate", "PreviousValueDate", "Source", "Unit");

                    GridViewNigeria.DataSource = FilteredTable;
                    GridViewNigeria.AutoGenerateColumns = true;
                    GridViewNigeria.DataBind();
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