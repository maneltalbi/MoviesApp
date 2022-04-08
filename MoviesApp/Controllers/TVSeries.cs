using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace MoviesApp.Controllers
{
    public class TVSeries : Controller
    {
        private readonly ApplicationDbContext _context;

        public TVSeries(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: TVSeries
        public async Task<ActionResult> IndexAsync(string SearchText="")
        {

            if (SearchText != "" && SearchText != null)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var baseAddress1 = new Uri("http://api.themoviedb.org/3/");

                using (var httpClient = new HttpClient { BaseAddress = baseAddress1 })
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                    // api_key can be requestred on TMDB website
                    using (var response = await httpClient.GetAsync("search/tv?api_key=e713d6b21cffe24a1f790d41f6e8f4a3&query=" + SearchText))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        var model = JsonConvert.DeserializeObject<RootObject1>(responseData);

                        ViewBag.results = model.results;
                    }
                }

            }
            else
            {

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var baseAddress = new Uri("http://api.themoviedb.org/3/");

                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                    // api_key can be requestred on TMDB website
                    using (var response = await httpClient.GetAsync("discover/tv?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                    {
                        // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                        string responseData = await response.Content.ReadAsStringAsync();

                        var model = JsonConvert.DeserializeObject<RootObject1>(responseData);
                        ViewBag.results = model.results;

                    }
                }
            }
            return View();
        }

        // GET: TVSeries/Details/5
        public async Task<ActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var baseAddress = new Uri("http://api.themoviedb.org/3/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                // api_key can be requestred on TMDB website
                using (var response = await httpClient.GetAsync("discover/tv?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                {
                    // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                    string responseData = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<RootObject1>(responseData);
                    ViewBag.results = model.results;
                    foreach (var serie in model.results)
                    {

                        if (serie.id == id)
                        {
                            var poster_Uri = String.Format("http://image.tmdb.org/t/p/w500/{0}", serie.poster_path);
                            ViewBag.poster = poster_Uri;
                            ViewBag.serie = serie;

                        }
                    }

                }
            }
            return View();
        }



        // GET: TVSeries/Create
        public async Task<ActionResult> CreateAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var baseAddress = new Uri("http://api.themoviedb.org/3/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                // api_key can be requestred on TMDB website
                using (var response = await httpClient.GetAsync("discover/tv?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                {
                    // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                    string responseData = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<RootObject1>(responseData);
                    var poster_path = "";

                    var backdrop_path = "";
                    ViewBag.results = model.results;
                    foreach (var serie in model.results)
                    {

                        if (serie.id == id)
                        {
                             poster_path = String.Format("http://image.tmdb.org/t/p/w500/{0}", serie.poster_path);
                            backdrop_path = String.Format("http://image.tmdb.org/t/p/w500/{0}", serie.backdrop_path);

                            ViewBag.poster = poster_path;
                            ViewBag.serie = serie;
                            InsertSerie(serie.name, serie.poster_path, serie.first_air_date, serie.vote_average, serie.vote_count, serie.overview, serie.backdrop_path, serie.homepage, serie.id, serie.in_production,
            serie.languages, serie.last_air_date, serie.number_of_episodes, serie.number_of_seasons, serie.origin_country, serie.origin_language,
             serie.origin_name, serie.popularity, serie.status, serie.tagline, serie.type);



                        }
                    }

                }
            }
            return View();
        }
        private void InsertGenre(string name,int Seriesid)
        {
            SqlConnection con = new SqlConnection("Server=.;Database=MoviesApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            using (con)
            {
                string query = "INSERT INTO Genres VALUES(@name,@Seriesid)";


                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@Seriesid", Seriesid);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private void InsertSeasons(int idSeason, string air_date, string episode_count, string name, string overview, string poster_path, int season_number)
        {
            SqlConnection con = new SqlConnection("Server=.;Database=MoviesApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            using (con)
            {
                string query = "INSERT INTO Series VALUES(@idSeason,@air_date,@episode_count,@name,@overview,@poster_path,@season_number)";


                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@idSeason", idSeason);
                    cmd.Parameters.AddWithValue("@air_date", air_date);
                    cmd.Parameters.AddWithValue("@episode_count", episode_count);
                    cmd.Parameters.AddWithValue("@overview", overview);
                    cmd.Parameters.AddWithValue("@poster_path", poster_path);
                    cmd.Parameters.AddWithValue("@season_number", season_number);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private void InsertSerie(string name, string poster_path,string first_air_date,double vote_average,int vote_count,string overview,string backdrop_path, string homepage, int idSerie, string in_production, 
            string languages, string last_air_date,int number_of_episodes,int number_of_seasons,string origin_country,string origin_language,
            string origin_name,double popularity,string status,string tagline,string type)
        {
            SqlConnection con = new SqlConnection("Server=.;Database=MoviesApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            using (con)
            {
                string query = "INSERT INTO Series VALUES(@name,@poster_path,@first_air_date,@vote_average,@vote_count," +
                    "@overview,@backdrop_path,@homepage,@idSerie,@in_production,@languages,@last_air_date," +
                    "@number_of_episodes,@number_of_seasons,@origin_country,@origin_language,@origin_name,@popularity,@status,@tagline,@type)";
                
      
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@poster_path", poster_path);
                    cmd.Parameters.AddWithValue("@first_air_date", first_air_date);
                    cmd.Parameters.AddWithValue("@vote_average", vote_average);
                    cmd.Parameters.AddWithValue("@vote_count", vote_count);
                    cmd.Parameters.AddWithValue("@overview", overview);
                    cmd.Parameters.AddWithValue("@backdrop_path", backdrop_path);
                    cmd.Parameters.AddWithValue("@homepage", homepage);
                    cmd.Parameters.AddWithValue("@idSerie", idSerie);
                    cmd.Parameters.AddWithValue("@in_production", in_production);
                    cmd.Parameters.AddWithValue("@languages", languages);
                    cmd.Parameters.AddWithValue("@last_air_date", last_air_date);
                    cmd.Parameters.AddWithValue("@number_of_episodes", number_of_episodes);
                    cmd.Parameters.AddWithValue("@number_of_seasons", number_of_seasons);
                    cmd.Parameters.AddWithValue("@origin_country", origin_country);
                    cmd.Parameters.AddWithValue("@origin_language", origin_language);
                    cmd.Parameters.AddWithValue("@origin_name", origin_name);
                    cmd.Parameters.AddWithValue("@popularity", popularity);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@tagline", tagline);
                    cmd.Parameters.AddWithValue("@type", type);
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        // POST: TVSeries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("name,first_air_date,overview,poster_path,vote_average,vote_count")] Series serie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serie);
        }

        // GET: TVSeries/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TVSeries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: TVSeries/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TVSeries/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
