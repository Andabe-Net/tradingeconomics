using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeSpaceApi.models
{
    public class CountryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Country { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public double LatestValue { get; set; }
        public double PreviousValue { get; set; }
        public DateTime LatestValueDate { get; set; }
        public DateTime PreviousValueDate { get; set; }
        public string Source { get; set; }
        public string? SourceURL { get; set; }
        public string Unit { get; set; }
        public string URL { get; set; }
        public string CategoryGroup { get; set; }
        public string? Adjustment { get; set; }
        public string Frequency { get; set; }
        public string HistoricalDataSymbol { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FirstValueDate { get; set; }

    }
}
