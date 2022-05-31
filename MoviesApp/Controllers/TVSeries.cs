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
using Neo4jClient;

namespace MoviesApp.Controllers
{
    public class TVSeries : Controller
    {
        private readonly IGraphClient _client;

        public TVSeries(IGraphClient client)
        {
            _client = client;
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("name,id,first_air_date,overview,poster_path,vote_average,vote_count")] Series serie1)
        {
           
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var baseAddress = new Uri("http://api.themoviedb.org/3/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                // api_key can be requestred on TMDB website
                using (var response = await httpClient.GetAsync("tv/" + serie1.id + "?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                {
                    // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                    string responseData = await response.Content.ReadAsStringAsync();

                    var serie = JsonConvert.DeserializeObject<ListSeries>(responseData);

                }
            }
            return View("SaveResult");
        }

        [HttpGet]
        public async Task<ActionResult> CreateAsync(int?id)
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


                        }
                    }


                }
            }
            return View();
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
