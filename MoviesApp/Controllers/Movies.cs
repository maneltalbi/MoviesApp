using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Models;
using Neo4jClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesApp.Controllers
{
    public class Movies : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IGraphClient _client;
       
        public Movies(IGraphClient client)
        {
            _client = client;
        }
         
       


        public async Task<ActionResult> IndexAsync(string SearchText="", int pg=1)
        {
            if (SearchText != "" && SearchText != null)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var baseAddress1 = new Uri("http://api.themoviedb.org/3/");

                using (var httpClient = new HttpClient { BaseAddress = baseAddress1 })
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                    // api_key can be requestred on TMDB website
                    using (var response = await httpClient.GetAsync("search/movie?api_key=e713d6b21cffe24a1f790d41f6e8f4a3&query=" + SearchText))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        var model = JsonConvert.DeserializeObject<RootObject>(responseData);

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
                    using (var response = await httpClient.GetAsync("discover/movie?sort_by=popularity.desc&api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                    {
                        // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                        string responseData = await response.Content.ReadAsStringAsync();

                        var model = JsonConvert.DeserializeObject<RootObject>(responseData);
                        //ViewBag.results = model.results;
                        

                     
                                ViewBag.results = model.results;
                           
                           
                    }
                }
            }
           
            return View();
        }
        public async Task<ActionResult> Genres(string YourProperty)
        {
            var id = 0;
            
            if (YourProperty != "" && YourProperty != null)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var baseAddress1 = new Uri("http://api.themoviedb.org/3/");

                using (var httpClient = new HttpClient { BaseAddress = baseAddress1 })
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                    // api_key can be requestred on TMDB website
                    using (var response = await httpClient.GetAsync("genre/movie/list?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                    {
                        // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                        string responseData = await response.Content.ReadAsStringAsync();
                        var model = JsonConvert.DeserializeObject<listGenre>(responseData);

                        ViewBag.res = model;
                        foreach (var genre in model.genres)
                        {
                            if (genre.name == YourProperty)
                            {
                                 id = genre.id;
                            }

                        }
                    }
                }



                //var selection = YourProperty;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var baseAddress = new Uri("http://api.themoviedb.org/3/");

                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                    // api_key can be requestred on TMDB website
                    using (var response = await httpClient.GetAsync("discover/movie?api_key=e713d6b21cffe24a1f790d41f6e8f4a3&with_genres=" + id))
                    {
                        // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                        string responseData = await response.Content.ReadAsStringAsync();

                        var model = JsonConvert.DeserializeObject<RootObject>(responseData);
                        ViewBag.movies = model.results;

                    }
                }

            } 
            return View();
        }


        // GET: Movies/Details/5
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
                using (var response = await httpClient.GetAsync("discover/movie?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                {
                    // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                    string responseData = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<RootObject>(responseData);
                    ViewBag.results = model.results;
                    foreach(var movie in model.results) {
                       
                        if (movie.id == id)
                    {
                            

                            var poster_Uri = String.Format("http://image.tmdb.org/t/p/w500/{0}", movie.poster_path);
                            ViewBag.poster = poster_Uri;
                            ViewBag.movie = movie;

                    }
                    }
                }
            }

            return View();
        }

        // GET: Movies/Create
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
                using (var response = await httpClient.GetAsync("discover/movie?sort_by=popularity.desc&api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                {
                    // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                    string responseData = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<RootObject>(responseData);
                    ViewBag.results = model.results;
                    var moviegenre = "";
                    var poster_Uri = "";
                   
                    var backdrop_path = "";
                    foreach (var movie in model.results)
                    {

                        if (movie.id == id)
                        {
                            using (var response2 = await httpClient.GetAsync("movie/" + id + "/videos?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                            {
                                // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                string responseData2 = await response2.Content.ReadAsStringAsync();
                                var model2 = JsonConvert.DeserializeObject<listVideos>(responseData2);
                                ViewBag.videos = model2.results;
                                foreach (var video in model2.results)
                                {
                                    var videolink = "https://www.youtube.com/embed/" + video.key;
                                    ViewBag.videolink = videolink;
                                }
                                }

                            poster_Uri = String.Format("http://image.tmdb.org/t/p/w500/{0}", movie.poster_path);
                            backdrop_path = String.Format("http://image.tmdb.org/t/p/w500/{0}", movie.backdrop_path);
                            foreach (var genreID in movie.genre_ids)
                            {

                                using (var response1 = await httpClient.GetAsync("genre/movie/list?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                                {
                                    // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                    string responseData1 = await response1.Content.ReadAsStringAsync();
                                    var model1 = JsonConvert.DeserializeObject<listGenre>(responseData1);

                                    ViewBag.res = model1;
                                    foreach (var genre in model1.genres)
                                    {
                                        if (genre.id == genreID)
                                        {
                                            if (moviegenre == "")
                                            {
                                                moviegenre = genre.name;
                                            }
                                            else
                                            {
                                                moviegenre = moviegenre + "," + genre.name;
                                            }
                                        }
                                    }
                                }
                            }






                            
                            ViewBag.poster = poster_Uri;
                            ViewBag.backdrop_path = backdrop_path;
                            ViewBag.movie = movie;
                            ViewBag.moviegenre = moviegenre;
                        }
                        }
                    }
                }
            

            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Title,Released,Overview,Poster,imdbRating,imdbVotes,genres,idMovie,backdrop_path,adult,original_language,original_title,popularity,videos")] Models.MyMovie movie)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var baseAddress = new Uri("http://api.themoviedb.org/3/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                using (var response = await httpClient.GetAsync("movie/" + movie.idMovie + "?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                {

                    string responseData = await response.Content.ReadAsStringAsync();

                    var movie1 = JsonConvert.DeserializeObject<ListMovies>(responseData);
                    var idmovie = movie1.id;

                    var moviee = new Models.MyMovie
                    {
                        idMovie = movie1.id,
                        imdb_id = movie1.imdb_id,
                        original_title = movie1.original_title,
                        original_language = movie1.original_language,
                        overview = movie1.overview,
                        popularty = movie1.popularty,
                        poster_path = movie1.poster_path,
                        release_date = movie1.release_date,
                        revenue = movie1.revenue,
                        runtime = movie1.runtime,
                        status = movie1.status,
                        tagline = movie1.tagline,
                        video = movie1.video,
                        vote_average = movie1.vote_average,
                        vote_count = movie1.vote_count
                    };
                    _client.Cypher
                        .Create("(movie:MyMovie $moviee)")
                        .WithParam("moviee", moviee)
                        .ExecuteWithoutResultsAsync()
                        .Wait();
                    using (var responsev = await httpClient.GetAsync("movie/" + movie.idMovie + "/videos?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                    {

                        string responseDatav = await responsev.Content.ReadAsStringAsync();

                        var modelv = JsonConvert.DeserializeObject<listVideos>(responseDatav);

                        foreach (var video in modelv.results)
                        {
                            var video1 = new Videos
                            {
                                id = video.id,
                                name = video.name.ToString(),
                                published_at = video.published_at.ToString(),
                                site = video.site.ToString(),
                                size = video.size,
                                type = video.type.ToString(),
                                key = video.key.ToString(),
                                idMovie = movie1.id
                            };
                            _client.Cypher
                      .Create("(video:Videos $video1)")
                      .WithParam("video1", video1)
                      .ExecuteWithoutResultsAsync()
                      .Wait();



                        }
                        _client.Cypher
.Match("(movie:MyMovie)", "(video:Videos)")
.Where((MyMovie movie) => movie.idMovie == idmovie)
.AndWhere((Videos video) => video.idMovie == idmovie)
.Create("(movie)-[:HAS_VIDEO]->(video)")
.ExecuteWithoutResultsAsync()
.Wait();
                    }

                    foreach (var genre in movie1.genres)
                    {
                        var genre1 = new Genres
                        {
                            id = genre.id,
                            name = genre.name,
                            idgenre = movie1.id
                        };
                        _client.Cypher
                      .Create("(genre:Genres $genre1)")
                      .WithParam("genre1", genre1)
                      .ExecuteWithoutResultsAsync()
                      .Wait();

                    }

                    _client.Cypher
.Match("(movie:MyMovie)", "(genre:Genres)")
.Where((MyMovie movie) => movie.idMovie == idmovie)
.AndWhere((Genres genre) => genre.idgenre == idmovie)
.Create("(movie)-[:BELONGS_ON_GENRE]->(genre)")
.ExecuteWithoutResultsAsync()
.Wait();
                    using (var responseimg = await httpClient.GetAsync("movie/" + movie1.id + "/images?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                    {
                        // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                        string responseDataimg = await responseimg.Content.ReadAsStringAsync();
                        var modelimg = JsonConvert.DeserializeObject<ResultImg>(responseDataimg);

                        foreach (var poster in modelimg.posters)
                        {


                            Images img = new Images
                            {
                                idImage = movie1.id,
                                aspect_ratio = poster.aspect_ratio,
                                file_path = poster.file_path,
                                height = poster.height,
                                iso_639_1 = poster.iso_639_1,
                                vote_average = poster.vote_average,
                                vote_count = poster.vote_count,
                                width = poster.width,
                            };

                            _client.Cypher
                        .Create("(image:Images $img)")
                        .WithParam("img", img)
                        .ExecuteWithoutResultsAsync()
                        .Wait();
                        }

                        foreach (var backdrop in modelimg.backdrops)
                        {

                            Images img = new Images
                            {
                                idImage = movie1.id,
                                aspect_ratio = backdrop.aspect_ratio,
                                file_path = backdrop.file_path,
                                height = backdrop.height,
                                iso_639_1 = backdrop.iso_639_1,
                                vote_average = backdrop.vote_average,
                                vote_count = backdrop.vote_count,
                                width = backdrop.width,
                            };
                            _client.Cypher
                       .Create("(image:Images $img)")
                       .WithParam("img", img)
                       .ExecuteWithoutResultsAsync()
                       .Wait();

                        }
                        foreach (var logo in modelimg.logos)
                        {

                            Images img = new Images
                            {
                                idImage = movie1.id,
                                aspect_ratio = logo.aspect_ratio,
                                file_path = logo.file_path,
                                height = logo.height,
                                iso_639_1 = logo.iso_639_1,
                                vote_average = logo.vote_average,
                                vote_count = logo.vote_count,
                                width = logo.width,
                            };
                            _client.Cypher
                       .Create("(image:Images $img)")
                       .WithParam("img", img)
                       .ExecuteWithoutResultsAsync()
                       .Wait();
                        }

                        _client.Cypher
    .Match("(movie:MyMovie)", "(image:Images)")
    .Where((MyMovie movie) => movie.idMovie == idmovie)
    .AndWhere((Images image) => image.idImage == idmovie)
    .Create("(movie)-[:HAS_IMAGE]->(image)")
    .ExecuteWithoutResultsAsync()
    .Wait();
                    }
                    foreach (var prodcompany in movie1.production_companies)
                    {

                        ProductionCompanies prodcomp = new ProductionCompanies
                        {

                            logo_path = prodcompany.logo_path,
                            name = prodcompany.name,
                            origin_country = prodcompany.origin_country,
                            id = prodcompany.id,
                            idProdCompany = idmovie
                        };
                        _client.Cypher
                      .Create("(productioncompanie:ProductionCompanies $prodcomp)")
                      .WithParam("prodcomp", prodcomp)
                      .ExecuteWithoutResultsAsync()
                      .Wait();
                    }
                    _client.Cypher
   .Match("(movie:MyMovie)", "(productioncompanie:ProductionCompanies)")
   .Where((MyMovie movie) => movie.idMovie == idmovie)
   .AndWhere((ProductionCompanies productioncompanie) => productioncompanie.idProdCompany == idmovie)
   .Create("(movie)-[:PRODUCTED_IN]->(productioncompanie)")
   .ExecuteWithoutResultsAsync()
   .Wait();

                    foreach (var prodcountrie in movie1.production_countries)
                    {

                        Productioncountries prodcount = new Productioncountries
                        {

                            iso_3166_1 = prodcountrie.iso_3166_1,
                            name = prodcountrie.name,
                            idProdCountry = movie1.id
                        };
                        _client.Cypher
                      .Create("(productioncountrie:Productioncountries $prodcount)")
                      .WithParam("prodcount", prodcount)
                      .ExecuteWithoutResultsAsync()
                      .Wait();

                    }
                    _client.Cypher
    .Match("(movie:MyMovie)", "(productioncountrie:Productioncountries)")
    .Where((MyMovie movie) => movie.idMovie == idmovie)
    .AndWhere((Productioncountries productioncountrie) => productioncountrie.idProdCountry == idmovie)
    .Create("(movie)-[:PRODUCTED_BY]->(productioncountrie)")
    .ExecuteWithoutResultsAsync()
    .Wait();
                    foreach (var spokenlgge in movie1.spoken_languages)
                    {

                        SpokenLanguages spknlgge = new SpokenLanguages { 
                        name = spokenlgge.name,
                        english_name = spokenlgge.english_name,
                        iso_639_1 = spokenlgge.iso_639_1,
                        idSpkenLgge=idmovie
                    };
                        _client.Cypher
                      .Create("(spokenlanguages:SpokenLanguages $spknlgge)")
                      .WithParam("spknlgge", spknlgge)
                      .ExecuteWithoutResultsAsync()
                      .Wait();
                    }
                    _client.Cypher
   .Match("(movie:MyMovie)", "(spokenlanguages:SpokenLanguages)")
   .Where((MyMovie movie) => movie.idMovie == idmovie)
   .AndWhere((SpokenLanguages spokenlanguages) => spokenlanguages.idSpkenLgge == idmovie)
   .Create("(movie)-[:SPEAK]->(spokenlanguages)")
   .ExecuteWithoutResultsAsync()
   .Wait();
                    if (movie1.belongs_to_collection != null)
                    {
                        using (var responsecol = await httpClient.GetAsync("collection/" + movie1.belongs_to_collection.id + "?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                        {
                            // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                            string responseDatacol = await responsecol.Content.ReadAsStringAsync();
                            var modelcol = JsonConvert.DeserializeObject<ListCollections>(responseDatacol);

                            Collections col = new Collections
                            {
                                id = modelcol.id,
                                name = modelcol.name,
                                poster_path = modelcol.poster_path,
                                idMovie = idmovie,
                                backdrop_path = modelcol.backdrop_path,
                                overview = modelcol.overview,
                                idCol = modelcol.id
                            };
                            _client.Cypher
                         .Create("(collection:Collections $col)")
                         .WithParam("col", col)
                         .ExecuteWithoutResultsAsync()
                         .Wait();

                            _client.Cypher
                        .Match("(movie:MyMovie)", "(collection:Collections)")
                        .Where((MyMovie movie) => movie.idMovie == idmovie)
                        .AndWhere((Collections collection) => collection.idMovie == idmovie)
                        .Create("(movie)-[:BELONGS_TO_COLLECTION]->(collection)")
                        .ExecuteWithoutResultsAsync()
                         .Wait();
                            foreach (var part in modelcol.parts)
                            {
                                parts par = new parts
                                 {
                                    adult = part.adult,
                                    backdrop_path = part.backdrop_path,
                                    original_language = part.original_language,
                                    original_title = part.original_title,
                                    overview = part.overview,
                                    release_date = part.release_date,
                                    poster_path = part.poster_path,
                                    popularity = part.popularity,
                                    title = part.title,
                                    video = part.video,
                                    vote_average = part.vote_average,
                                    vote_count = part.vote_count,
                                    idCol = modelcol.id
                                  };

                                _client.Cypher
                         .Create("(part:parts $par)")
                         .WithParam("par", par)
                         .ExecuteWithoutResultsAsync()
                         .Wait();

                            }
                            _client.Cypher
                       .Match("(collection:Collections)", "(part:parts)")
                       .Where((Collections collection) => collection.idCol == modelcol.id)
                       .AndWhere((parts part) => part.idCol == modelcol.id)
                       .Create("(collection)-[:BELONGS_TO_PART]->(part)")
                       .ExecuteWithoutResultsAsync()
                        .Wait();
                        }
                    }
                }
            }
                    return View("SaveResult");
            
        }
        // SearchMovie method

        public async Task MovieSearch(string search)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var baseAddress = new Uri("http://api.themoviedb.org/3/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                // api_key can be requestred on TMDB website
                using (var response = await httpClient.GetAsync("search/movie?api_key=941c...&query=" + search))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<RootObject>(responseData);

                    ViewBag.result = model.results;
                }
            }
           
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movies/Edit/5
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

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movies/Delete/5
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
