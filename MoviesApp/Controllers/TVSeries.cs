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
        public async Task<ActionResult> IndexAsync()
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: TVSeries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
