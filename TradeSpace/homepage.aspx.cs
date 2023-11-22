using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.DynamicData;

//BELOW ARE THE STEPS FOR MY SOLUTION...THAT OBTAINS AND DISPLAYS INFORMATION OF ALL 3 COUNTRIES SORTED BY CATEGORY IN THE HOMEPAGE
//THIS PAGE DOES NOT ATTEMPT TO CALL THE API DIRECTLY <LIKE OTHER PAGES DO>, DATA IS READ FROM LOCAL DIRECTORY ~/countriesdata/
//SORTING IS APPLIED USING JAVASCRIPT in HTML header


namespace TradeSpace
{
    public partial class homepage : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();          
        }


       //defined function
        void LoadData()
        {
       
            //country data are stored in respective Json files for each country, in the ~/countriesdata/ directory
            //Countries_count below should correspond to the Files_number property (and constructor parameter) of DataPathFinder class
            //Countries_data acts as the file_Id Property (and constructor parameter)
            //I defined DataPathFinder  class in DataPathFinder.cs class file

            int countries_count = 3;
            DataPathFinder JsonFinder = new DataPathFinder(countries_count, "country_data");

            //creates a list of streamreaders for each country Json file, add the readers to the list
            var readersList = new List<StreamReader>();
            
            for (int i = 1; i < JsonFinder.Files_number + 1; i++)
            {
                StreamReader readers = new StreamReader(Server.MapPath(@"~/countriesdata/" + JsonFinder.File_Id + "_" + i + ".json"));
                readersList.Add(readers);
            }

            //creates an array of pointers to dataTables of each Json file     
            DataTable[] countriesData = new DataTable[JsonFinder.Files_number];

            //deserializes each reader content into respective DataTable objects for the array
            for (int i = 0; i < JsonFinder.Files_number; i++)
            {
                countriesData[i] = JsonConvert.DeserializeObject<DataTable>(readersList[i].ReadToEnd());

            }

            //merges all other dataTables to the first table
            for (int i = 1; i < JsonFinder.Files_number; i++)
            {
                countriesData[0].Merge(countriesData[i]);

            }           
            
            //Filter out the columns to display from the first table containing the merge, and bind data to GridView
            DataTable FilteredTable = countriesData[0].DefaultView.ToTable(true, "Country", "Category", "LatestValue", "PreviousValue", "Frequency", "LatestValueDate", "PreviousValueDate", "Unit");         
            GridViewAllCountries.DataSource = FilteredTable;
            GridViewAllCountries.AutoGenerateColumns = true;
            GridViewAllCountries.DataBind();
         
        }



    }
}