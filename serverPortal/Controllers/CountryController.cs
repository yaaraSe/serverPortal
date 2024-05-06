using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository;
using Repository.Models;
using System.Diagnostics.Metrics;

namespace serverPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {

        public readonly MongoRepository repository;

        public CountryController(MongoRepository mongoRepository)
        {
            repository = mongoRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Country> countries = repository.countryService.GetAllCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Country> Get(string id)
        {
            Country country = repository.countryService.GetCountryById(id);
            return country;
        }

        [HttpPost]
        public ActionResult<Country> Create(Country country)
        {
            try
            {

                repository.countryService.CreateCountry(country);
                return Ok($"Success Create country: {country.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Country> Update(string id, Country country)
        {
            try
            {
                repository.countryService.UpdateCountry(id, country);
                return country;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}