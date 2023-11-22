using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TradeSpaceApi.data;
using TradeSpaceApi.models;
using TradeSpaceApi.models.DTOs;

//I EXPOSE DIFFERENT API ENDPOINTS FOR A COUNTRY MODEL IN THIS CODE
//GET, POST, DELETE, PUT , PATCH

namespace TradeSpaceApi.Controllers
{
    [Route("api/TradeSpaceApi")]
    [ApiController]
    public class TradespaceApiController:ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TradespaceApiController(ApplicationDbContext db)
        {
            _db = db; }

        //GETAllCountries
        [HttpGet("countries", Name = "GetCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CountryDTO>> GetCountries()
        {
           return Ok(_db.CountriesData);
        }

        //GETByCountry
        [HttpGet("country", Name ="GetCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        

        public ActionResult<CountryDTO> GetCountry(string country)
        {
            if (country == null)
            {
                return BadRequest();
            }

            var countryFound = _db.CountriesData.FirstOrDefault(c => c.Country.ToLower() == country.ToLower());
             if (countryFound == null)
            {
                return NotFound();
            }

            return Ok(countryFound);
        }

        //GETCountryByCategory
        [HttpGet("country/category", Name = "GetCountryCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public ActionResult<CountryDTO> GetCountryCategory(string country, string category)
        {
            if (country == null||category==string.Empty)
            {
                return BadRequest();
            }

            var countryFound = _db.CountriesData.FirstOrDefault(c => c.Country.ToLower() == country.ToLower() && c.Category.ToLower()==category.ToLower());
            if (countryFound == null)
            {
                return NotFound();
            }

            return Ok(countryFound);
        }


        //POSTNewCountryWithCategory
        [HttpPost(Name = "Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CountryDTO> CreateCountry([FromBody] CountryDTO dto)
        {
            if(_db.CountriesData.FirstOrDefault(c => c.Country.ToLower() == dto.Country.ToLower() && c.Category.ToLower()==dto.Category.ToLower()) !=null)
             {
                ModelState.AddModelError("Post Error", "Country Already Exists");
                return BadRequest(ModelState);
            }

            if (dto == null || dto.Country == string.Empty)
            {
                return BadRequest(dto);
            }

            //CountryDTO to CountryMOdel

            CountryModel countryModel = new()
            {
                Country=dto.Country,
                Title =dto.Title,
                Category =dto.Category,
                LatestValue =dto.LatestValue,
                PreviousValue=dto.PreviousValue,
                LatestValueDate=dto.LatestValueDate, 
                PreviousValueDate = dto.PreviousValueDate,
                Source =dto.Source,
                SourceURL =dto.SourceURL,
                Unit =dto.Unit,
                URL =dto.URL,
                CategoryGroup =dto.Category, 
                Adjustment=dto.Adjustment,
                Frequency =dto.Frequency,
                HistoricalDataSymbol =dto.HistoricalDataSymbol              
            };


            _db.CountriesData.Add(countryModel);
            _db.SaveChanges();
            
             return CreatedAtRoute("GetCountry", new {country=dto.Country, dto});
        }

        //DELETECountryByCategory
        [HttpDelete("country/category", Name = "DeleteCountry")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCountry(string country, string category)
        {
            if (country==string.Empty || category==string.Empty)
            {
                return BadRequest();
            }
            var countryFound = _db.CountriesData.FirstOrDefault(c => c.Country.ToLower() == country.ToLower() && c.Category.ToLower()==category.ToLower());

            if (countryFound == null)
                {
                return NotFound();
                }
          
            _db.CountriesData.Remove(countryFound);
            _db.SaveChanges();
            return NoContent();


        }

        //UPDATECountryByCategory
        [HttpPut("country", Name = "UpdateCountry")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateCountry(string country, [FromBody] CountryDTO dto)
        {
            if (country == null || country != dto.Country)
            {
                return BadRequest();
            }

            if (_db.CountriesData.FirstOrDefault(c => c.Country.ToLower() == dto.Country.ToLower() && c.Category.ToLower() == dto.Category.ToLower()) == null)
            {
                ModelState.AddModelError("Update Error", "Country with the Category Not Found");
                return BadRequest(ModelState);
            }

            CountryModel countryModel = new()
            {
                Country = dto.Country,
                Title = dto.Title,
                Category = dto.Category,
                LatestValue = dto.LatestValue,
                PreviousValue = dto.PreviousValue,
                LatestValueDate = dto.LatestValueDate,
                PreviousValueDate = dto.PreviousValueDate,
                Source = dto.Source,
                SourceURL = dto.SourceURL,
                Unit = dto.Unit,
                URL = dto.URL,
                CategoryGroup = dto.Category,
                Adjustment=dto.Adjustment,
                Frequency = dto.Frequency,
                HistoricalDataSymbol = dto.HistoricalDataSymbol
            };

            _db.CountriesData.Update(countryModel);
            _db.SaveChanges();
            return NoContent();
        }

        //UPDATECountryPart
        [HttpPatch("country", Name = "updateCountryPart")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult UpdateCountryPart(string country, string category, JsonPatchDocument<CountryDTO> patchDTO)
        {
            if (country == string.Empty ||category==string.Empty || patchDTO == null)
            { 
                return BadRequest(); 
            }

            var countryFound = _db.CountriesData.AsNoTracking().FirstOrDefault(c => c.Country.ToLower() == country.ToLower() && c.Category.ToLower() == category.ToLower());
            if (countryFound == null)
            {
                return NotFound();
            }

            //CountryModel to CountryDTo

            CountryDTO countryDTOModel = new()
            {
                Country = countryFound.Country,
                Title = countryFound.Title,
                Category = countryFound.Category,
                LatestValue =countryFound.LatestValue,
                PreviousValue = countryFound.PreviousValue,
                LatestValueDate =countryFound.LatestValueDate,
                PreviousValueDate = countryFound.PreviousValueDate,
                Source = countryFound.Source,
                SourceURL = countryFound.SourceURL,
                Unit = countryFound.Unit,
                URL = countryFound.URL, 
                Adjustment= countryFound.Adjustment,
                Frequency = countryFound.Frequency,
                HistoricalDataSymbol = countryFound.HistoricalDataSymbol
            };

            //Apply Patch to CountryDTO type
            patchDTO.ApplyTo(countryDTOModel, ModelState);

            //Update is only applied to CountryModel type

            CountryModel countryModel = new()
            {
                Country = countryDTOModel.Country,
                Title = countryDTOModel.Title,
                Category = countryDTOModel.Category,
                LatestValue = countryDTOModel.LatestValue,
                PreviousValue = countryDTOModel.PreviousValue,
                LatestValueDate = countryDTOModel.LatestValueDate,
                PreviousValueDate = countryDTOModel.PreviousValueDate,
                Source = countryDTOModel.Source,
                SourceURL = countryDTOModel.SourceURL,
                Unit = countryDTOModel.Unit,
                URL = countryDTOModel.URL,
                CategoryGroup = countryDTOModel.Category,
                Adjustment=countryDTOModel.Adjustment,
                Frequency = countryDTOModel.Frequency,
                HistoricalDataSymbol = countryDTOModel.HistoricalDataSymbol
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.CountriesData.Update(countryModel);
            _db.SaveChanges();

            return NoContent();
        }
    }
}

