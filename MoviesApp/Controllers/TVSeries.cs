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
                using (var response = await httpClient.GetAsync("tv/"+serie1.id+"?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                {
                    // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                    string responseData = await response.Content.ReadAsStringAsync();

                    var serie = JsonConvert.DeserializeObject<ListSeries>(responseData);

                    Series serieb = new Series();
                    serieb.id = serie.id;
                    serieb.name=serie.name.ToString();
                    serieb.original_name=serie.original_name.ToString();
                    serieb.first_air_date= serie.first_air_date.ToString();
                    serieb.backdrop_path= serie.backdrop_path.ToString();
                    serieb.homepage= serie.homepage.ToString();
                    serieb.in_production= serie.in_production.ToString();
                    serieb.languages= serie.languages.ToString();
                    serieb.origin_country=serie.origin_country.ToString();
                    serieb.last_air_date=serie.last_air_date.ToString();
                    serieb.number_of_episodes=serie.number_of_episodes;
                    serieb.number_of_seasons=serie.number_of_seasons;
                    serieb.status=serie.status.ToString();
                    serieb.type=serie.type.ToString();
                    serieb.original_language=serie.original_language.ToString();
                    serieb.overview=serie.overview.ToString();
                    serieb.popularity=serie.popularity;
                    serieb.poster_path=serie.poster_path.ToString();
                    serieb.tagline=serie.tagline.ToString();
                    serieb.vote_average=serie.vote_average;
                    serieb.vote_count=serie.vote_count;
                    _context.Series.Add(serieb);
                    _context.SaveChanges();
                    int idf = 0;
                    foreach(var seriedb in _context.Series) {
                        if (serie.id == seriedb.id)
                        {
                            idf = seriedb.idSerie;
                        }
                    }
                    foreach (var createur in serie.Created_by)
                     {
                         if (createur.profile_path == null)
                         {
                             createur.id.ToString();
                             createur.credit_id.ToString();
                             createur.name.ToString();
                             createur.gender.ToString();
                             createur.Seriesid = idf;
                             _context.Createurs.Add(createur);
                             _context.SaveChanges();
                         }
                         else
                         {
                             createur.id.ToString();
                             createur.credit_id.ToString();
                             createur.name.ToString();
                             createur.gender.ToString();
                             createur.profile_path.ToString();
                             createur.Seriesid =idf;
                             _context.Createurs.Add(createur);
                             _context.SaveChanges();
                         }
                     }
                    foreach(var network in serie.Networks)
                    {
                        network.id.ToString();
                        network.name.ToString();
                        network.logo_path.ToString();
                        network.origin_country.ToString();
                        network.idSerie = idf;
                        _context.Networks.Add(network);
                        _context.SaveChanges();
                    }
                    // var poster_path = "";

                    //var backdrop_path = "";
                    //ViewBag.results = serie;

                    //poster_path = String.Format("http://image.tmdb.org/t/p/w500/{0}", serie.poster_path);
                    // backdrop_path = String.Format("http://image.tmdb.org/t/p/w500/{0}", serie.backdrop_path);

                    // ViewBag.poster = poster_path;
                    // ViewBag.serie = serie;
                    /*  using (var responseep = await httpClient.GetAsync("tv/" + serie1.idSerie + "/episode_groups?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                      {
                          // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                          string responseDataep = await responseep.Content.ReadAsStringAsync();

                          var modelv = JsonConvert.DeserializeObject<listVideos>(responseDataep);
                          foreach(var video in modelv.results)
                          {
                              VideosSeries vidser = new VideosSeries();

                              video.id.ToString();
                              video.key.ToString();
                              video.name.ToString();
                              video.published_at.ToString();
                              video.site.ToString();
                              video.size.ToString();
                              video.type.ToString();
                              _context.Videos.Add(video);

                              _context.SaveChanges();

                              vidser.idSerie = serie1.idSerie;
                              vidser.idVideo = video.id.ToString();
                              _context.VideosSeries.Add(vidser);

                              _context.SaveChanges();

                          }

                      }*/
                    using (var responsev = await httpClient.GetAsync("tv/"+serie1.id+"/videos?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                            {
                                // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                string responseDatav = await responsev.Content.ReadAsStringAsync();

                                var modelv = JsonConvert.DeserializeObject<listVideos>(responseDatav);
                              //  _context.Series.Add(serie);
                                //_context.SaveChanges();
                              
                                foreach (var video in modelv.results)
                                {
                                    VideosSeries vidser = new VideosSeries();

                                    video.id.ToString();
                                    video.name.ToString();
                                    video.published_at.ToString();
                                    video.site.ToString();
                                    video.size.ToString();
                                    video.type.ToString();
                                    video.key.ToString();
                                    _context.Videos.Add(video);
                                    _context.SaveChanges();
                                    vidser.id = serie1.id;
                                    vidser.idVideo = video.id.ToString();
                                    _context.VideosSeries.Add(vidser);

                                    _context.SaveChanges();

                                }
                            }
                            using (var responseG = await httpClient.GetAsync("genre/tv/list?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                            {
                                // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                string responseDataG = await responseG.Content.ReadAsStringAsync();
                                var modelG = JsonConvert.DeserializeObject<listGenre>(responseDataG);

                                ViewBag.res = modelG;
                                foreach (var genre in modelG.genres)
                                {
                                    foreach(var genreid in serie.genres) {
                                        if (genre.id == genreid.id) { 
                                    GenresSeries genreserie = new GenresSeries();
                                        genre.id .ToString();
                                        genre.name.ToString();
                                    _context.Genres.Add(genre);
                                    _context.SaveChanges();
                                    genreserie.idGenre = genre.id;
                                    genreserie.idSerie = serie1.id;
                                    _context.GenresSeries.Add(genreserie);
                                    _context.SaveChanges();
                                        }

                                    }
                                }
                            }
                            using (var responseimg = await httpClient.GetAsync("tv/"+serie.id+"/images?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                            {
                                // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                string responseDataimg = await responseimg.Content.ReadAsStringAsync();
                                var modelimg = JsonConvert.DeserializeObject<ResultImg>(responseDataimg);

                                foreach (var poster in modelimg.posters)
                                {
                                    SeriesImages serieimg = new SeriesImages();

                                    Images img = new Images();
                                    img.idImage = modelimg.id;
                                    img.aspect_ratio = poster.aspect_ratio;
                                    img.file_path = poster.file_path;
                                    img.height = poster.height;
                                    img.iso_639_1 = poster.iso_639_1;
                                    img.vote_average = poster.vote_average;
                                    img.vote_count = poster.vote_count;
                                    img.width = poster.width;
                                   _context.Images.Add(img);
                                    _context.SaveChanges();
                                           serieimg.IdImg = modelimg.id;
                                            serieimg.IdSerie = serie1.id;
                                            _context.SeriesImages.Add(serieimg);
                                            _context.SaveChanges();
                                       
                                }
                            }

                           
                          //  _context.Series.Add(serie);
                            //_context.SaveChanges();


                }
            }
            return View();
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
