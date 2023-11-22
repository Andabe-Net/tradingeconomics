using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeSpace
{
    // A class that represents some info about the set of json files
    public class DataPathFinder
    {
        // property that stores the number of files
        public int Files_number { get; set; }

        // property that stores the common identifier of the json files
        public string File_Id { get; set; }

        // constructor takes the number of files and the common identifier
        public  DataPathFinder(int files_number, string file_Id)
        {
            this.Files_number = files_number;
            this.File_Id = file_Id;
        }
    }
}