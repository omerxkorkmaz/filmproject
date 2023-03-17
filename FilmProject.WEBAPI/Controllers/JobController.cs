using Azure.Core;
using FilmProject.WEBAPI.EntityFramework;
using FilmProject.WEBAPI.Models;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

namespace FilmProject.WEBAPI.Controllers
{
    public class JobController : Controller
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private FilmDbContext _filmDbContext;
        public JobController(IConfiguration configuration, FilmDbContext filmDbContext)
        {
            _configuration = configuration;
            _filmDbContext = filmDbContext;

        }

        
        [HttpGet("FilmAllGet")]
        public async Task<IActionResult> Index()
        {
            string apikey = "2dea44ae74bac30900ed5a498c085bc3";
            int page = 500;
            _httpClient = new HttpClient();
            var api = _configuration.GetValue<string>("ConnectionStrings:WEBAPI");

            _httpClient.DefaultRequestHeaders.Add("apikey", apikey);

            _httpClient.BaseAddress = new Uri(api);


            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + apikey + "&page="+page);

            FilmList films = new FilmList();
            //Films films = new Films();

            if (response.IsSuccessStatusCode)
            {
                dynamic result = await response.Content.ReadAsStringAsync();
                films = JsonConvert.DeserializeObject<FilmList>(result);
            }

            RecurringJob.AddOrUpdate(() => AddFilm(films), Cron.Hourly);           

            return Ok(films);
        }

        public void AddFilm(FilmList films)
        {   
            foreach (var item in films.Films)
            {
                _filmDbContext.Add(item);             

            }
            _filmDbContext.SaveChanges();


        }
    }
}
