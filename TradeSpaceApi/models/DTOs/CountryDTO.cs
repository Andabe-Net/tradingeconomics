using System.ComponentModel.DataAnnotations;

namespace TradeSpaceApi.models.DTOs
{
    public class CountryDTO
    {
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
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
    }
}
