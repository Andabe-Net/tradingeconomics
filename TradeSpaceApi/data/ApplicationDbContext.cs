using Microsoft.EntityFrameworkCore;
using TradeSpaceApi.models;

namespace TradeSpaceApi.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<CountryModel> CountriesData { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryModel>().HasData(

                new CountryModel()
                {

                    Country = "Mexico",
                    Title = "Mexico Employment Rate",
                    Category = "Employment Rate",
                    LatestValue = 97.12,
                    PreviousValue = 97.04,
                    LatestValueDate = DateTime.Parse("2023-09-30T00:00:00"),
                    PreviousValueDate = DateTime.Parse("2023-08-31T00:00:00"),
                    Source = "Instituto Nacional de Estadística y Geografía (INEGI)",
                    SourceURL = "https://www.inegi.org.mx/",
                    Unit = "percent",
                    URL = "/mexico/employment-rate",
                    CategoryGroup = "Labour",
                    Adjustment = "NSA",
                    Frequency = "Monthly",
                    HistoricalDataSymbol = "MEXICOEMPRAT",
                    CreateDate = DateTime.Parse("2015-09-30T00:00:00"),
                    FirstValueDate = DateTime.Parse("2005-01-31T00:00:00"),
                 
                  
                },

                   new CountryModel()
                   {

                       Country = "Nigeria",
                       Title = "Nigeria Employment Rate",
                       Category = "Employment Rate",
                       LatestValue = 76.7,
                       PreviousValue = 73.6,
                       LatestValueDate = DateTime.Parse("2023-09-30T00:00:00"),
                       PreviousValueDate = DateTime.Parse("2023-08-31T00:00:00"),
                       Source = "Central Bank of Nigeria",
                       SourceURL = "https://www.cbn./blahblah/",
                       Unit = "percent",
                       URL = "/nigeria/employment-rate",
                       CategoryGroup = "Labour",
                       Adjustment = "NSA",
                       Frequency = "Monthly",
                       HistoricalDataSymbol = "NGN",
                       CreateDate = DateTime.Parse("2015-09-30T00:00:00"),
                       FirstValueDate = DateTime.Parse("2015-01-31T00:00:00"),


                   },

                      new CountryModel()
                      {

                          Country = "United States",
                          Title = "United States Employment Rate",
                          Category = "Employment Rate",
                          LatestValue = 60.2,
                          PreviousValue = 60.4,
                          LatestValueDate = DateTime.Parse("2023-09-30T00:00:00"),
                          PreviousValueDate = DateTime.Parse("2023-08-31T00:00:00"),
                          Source = "World Bank",
                          SourceURL = "https://www.worldbank.org/",
                          Unit = "percent",
                          URL = "/United-States/employment-rate",
                          CategoryGroup = "Labour",
                          Adjustment = "NSA",
                          Frequency = "Monthly",
                          HistoricalDataSymbol = "United-StatesUSD",
                          CreateDate = DateTime.Parse("2015-09-30T00:00:00"),
                          FirstValueDate = DateTime.Parse("2005-01-31T00:00:00"),


                      }





                );

        }
    }
}

