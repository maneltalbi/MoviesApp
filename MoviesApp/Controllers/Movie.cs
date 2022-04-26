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
    public class Movie : Controller
    {
        private readonly ApplicationDbContext _context;

        public Movie(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Movies
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
        public async Task<ActionResult> CreateAsync([Bind("Title,Released,Overview,Poster,imdbRating,imdbVotes,genres,id,backdrop_path,adult,original_language,original_title,popularity,videos")] Models.Movies movie)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var baseAddress = new Uri("http://api.themoviedb.org/3/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                using (var response = await httpClient.GetAsync("movie/" + movie.id + "?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                {

                    string responseData = await response.Content.ReadAsStringAsync();

                    var movie1 = JsonConvert.DeserializeObject<ListMovies>(responseData);
                    int idf = 0;
                    List<Movies> movies = new List<Movies>();
                    movies = _context.Movies.ToList();
                    foreach (var moviedb in movies)
                    {
                        if (movie1.id == moviedb.id)
                        {
                            idf = moviedb.idMovie;
                        }
                    }
                    int count = 0;
                    foreach (var movi in movies)
                    {
                        if (movie1.id == movi.id)
                        {
                            count = count + 1;



                        }

                    }
                    if (count == 0)
                    {
                        ViewData["errors"] = "";
                        Movies moviedb = new Movies();
                        moviedb.adult = movie1.adult;
                        moviedb.backdrop_path = movie1.backdrop_path;
                        moviedb.budget = movie1.budget;
                        moviedb.homepage = movie1.homepage;
                        moviedb.id = movie1.id;
                        moviedb.imdb_id = movie1.imdb_id;
                        moviedb.original_language = movie1.original_language;
                        moviedb.original_title = movie1.original_title;
                        moviedb.overview = movie1.overview;
                        moviedb.popularty = movie1.popularty;
                        moviedb.poster_path = movie1.poster_path;
                        moviedb.release_date = movie1.release_date;
                        moviedb.revenue = movie1.revenue;
                        moviedb.runtime = movie1.runtime;
                        moviedb.status = movie1.status;
                        moviedb.tagline = movie1.tagline;
                        moviedb.video = movie1.video;
                        moviedb.vote_average = movie1.vote_average;
                        moviedb.vote_count = movie1.vote_count;
                        _context.Movies.Add(moviedb);
                        _context.SaveChanges();
                        using (var responsev = await httpClient.GetAsync("movie/" + movie1.id + "/videos?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                        {
                            // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                            string responseDatav = await responsev.Content.ReadAsStringAsync();

                            var modelv = JsonConvert.DeserializeObject<listVideos>(responseDatav);
                            //  _context.Series.Add(serie);
                            //_context.SaveChanges();

                            foreach (var video in modelv.results)
                            {
                                VideosMovies vidmov = new VideosMovies();

                                video.id.ToString();
                                video.name.ToString();
                                video.published_at.ToString();
                                video.site.ToString();
                                video.size.ToString();
                                video.type.ToString();
                                video.key.ToString();
                                _context.videos.Add(video);
                                _context.SaveChanges();
                                vidmov.idMovie = movie1.id;
                                vidmov.idVideo = video.id.ToString();
                                _context.VideosMovies.Add(vidmov);
                                _context.SaveChanges();

                            }
                        }

                        List<Genres> Genres = new List<Genres>();
                        Genres = _context.Genres.ToList();
                        int countg = 0;
                        // foreach (var genre in modelG.genres)
                        //{
                        foreach (var genre in movie1.genres)
                        {
                            foreach (var genreb in Genres)
                            {
                                if (genreb.id == genre.id)
                                {
                                    countg = countg + 1;
                                }
                            }

                            if (countg == 0)
                            {
                                genre.id.ToString();
                                genre.name.ToString();
                                _context.Genres.Add(genre);
                                _context.SaveChanges();
                                GenresMovies genremovie = new GenresMovies();
                                genremovie.idGenre = genre.id;
                                genremovie.idMovie = movie1.id;
                                _context.GenresMovies.Add(genremovie);
                                _context.SaveChanges();
                            }
                            else
                            {
                                GenresMovies genremovie = new GenresMovies();
                                genremovie.idGenre = genre.id;
                                genremovie.idMovie = movie1.id;
                                _context.GenresMovies.Add(genremovie);
                                _context.SaveChanges();
                            }


                        }
                        using (var responseimg = await httpClient.GetAsync("movie/" + movie1.id + "/images?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                        {
                            // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                            string responseDataimg = await responseimg.Content.ReadAsStringAsync();
                            var modelimg = JsonConvert.DeserializeObject<ResultImg>(responseDataimg);

                            foreach (var poster in modelimg.posters)
                            {
                                MoviesImages movieimg = new MoviesImages();

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
                                movieimg.IdImg = modelimg.id;
                                movieimg.IdMovie = movie1.id;
                                _context.MoviesImages.Add(movieimg);
                                _context.SaveChanges();

                            }
                            foreach (var backdrop in modelimg.backdrops)
                            {
                                MoviesImages movieimg1 = new MoviesImages();

                                Images img1 = new Images();
                                img1.idImage = modelimg.id;
                                img1.aspect_ratio = backdrop.aspect_ratio;
                                img1.file_path = backdrop.file_path;
                                img1.height = backdrop.height;
                                img1.iso_639_1 = backdrop.iso_639_1;
                                img1.vote_average = backdrop.vote_average;
                                img1.vote_count = backdrop.vote_count;
                                img1.width = backdrop.width;
                                _context.Images.Add(img1);
                                _context.SaveChanges();
                                movieimg1.IdImg = modelimg.id;
                                movieimg1.IdMovie = movie1.id;
                                _context.MoviesImages.Add(movieimg1);
                                _context.SaveChanges();

                            }
                            foreach (var logo in modelimg.logos)
                            {
                                MoviesImages movieimg2 = new MoviesImages();

                                Images img2 = new Images();
                                img2.idImage = modelimg.id;
                                img2.aspect_ratio = logo.aspect_ratio;
                                img2.file_path = logo.file_path;
                                img2.height = logo.height;
                                img2.iso_639_1 = logo.iso_639_1;
                                img2.vote_average = logo.vote_average;
                                img2.vote_count = logo.vote_count;
                                img2.width = logo.width;
                                _context.Images.Add(img2);
                                _context.SaveChanges();
                                movieimg2.IdImg = modelimg.id;
                                movieimg2.IdMovie = movie1.id;
                                _context.MoviesImages.Add(movieimg2);
                                _context.SaveChanges();

                            }
                        }
                        foreach (var prodcountrie in movie1.production_countries)
                        {
                            ProdCountrieMovies prodcountmovie = new ProdCountrieMovies();
                            Productioncountries prodcount = new Productioncountries();
                            prodcount.iso_3166_1 = prodcountrie.iso_3166_1;
                            prodcount.name = prodcountrie.name;
                            _context.Productioncountries.Add(prodcount);
                            _context.SaveChanges();
                            prodcountmovie.idMovie = movie1.id;
                            prodcountmovie.ProdCountrie = prodcountrie.name;
                            _context.ProdCountrieMovies.Add(prodcountmovie);
                            _context.SaveChanges();
                        }
                        foreach (var prodcompany in movie1.production_companies)
                        {
                             ProCompMovies procompmovie = new ProCompMovies();
                            ProductionCompanies prodcomp = new ProductionCompanies();
                            prodcomp.logo_path = prodcompany.logo_path;
                            prodcomp.name = prodcompany.name;
                            prodcomp.origin_country = prodcompany.origin_country;
                            prodcomp.id = prodcompany.id;
                            _context.ProductionCompanies.Add(prodcomp);
                            _context.SaveChanges();
                            procompmovie.idMovie = movie1.id;
                            procompmovie.ProdCompanie = prodcompany.id;
                            _context.ProCompMovies.Add(procompmovie);
                            _context.SaveChanges();
                        }
                        int idmov = 0;
                        List<Movies> movv = new List<Movies>();
                        movv = _context.Movies.ToList();
                        foreach(var mov in movv)
                        {
                            if (mov.id == movie1.id)
                            {
                                idmov = mov.idMovie;
                            }
                        }
                        List<SpokenLanguages> splgge = new List<SpokenLanguages>();
                        splgge = _context.SpokenLanguages.ToList();
                        int countspllge = 0;
                        if (movie1.spoken_languages != null)
                        {
                            foreach (var spokenlgge in movie1.spoken_languages)
                            {
                                SpokenLggMovies slggem = new SpokenLggMovies();

                                foreach (var spkndb in splgge)
                                {
                                    if (spkndb.name == spokenlgge.name)
                                    {
                                        countspllge = countspllge + 1;
                                    }
                                }
                                if (countspllge == 0)
                                {
                                    SpokenLanguages spknlgge = new SpokenLanguages();
                                    spknlgge.name = spokenlgge.name;
                                    spknlgge.english_name = spokenlgge.english_name;
                                    spknlgge.iso_639_1 = spokenlgge.iso_639_1;
                                    _context.SpokenLanguages.Add(spknlgge);
                                    _context.SaveChanges();
                                    slggem.idMovie = movie1.id;
                                    slggem.Spokenlgg = spokenlgge.name;
                                    _context.SpokenLggMovies.Add(slggem);
                                    _context.SaveChanges();
                                }
                                else
                                {
                                    slggem.idMovie = movie1.id;
                                    slggem.Spokenlgg = spokenlgge.name;
                                    _context.SpokenLggMovies.Add(slggem);
                                    _context.SaveChanges();
                                }
                            }
                        }

                        if (movie1.belongs_to_collection != null)
                        {
                           
                           
                            using (var responsecol = await httpClient.GetAsync("collection/" + movie1.belongs_to_collection.id + "?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                            {
                                // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                string responseDatacol= await responsecol.Content.ReadAsStringAsync();
                                var modelcol = JsonConvert.DeserializeObject<ListCollections>(responseDatacol);

                                Collections col = new Collections();
                                col.id = modelcol.id;
                                col.name = modelcol.name;
                                col.poster_path = modelcol.poster_path;
                                col.idMovie = idmov;
                                col.backdrop_path = modelcol.backdrop_path;
                                col.overview = modelcol.overview;
                                _context.Collections.Add(col);
                                _context.SaveChanges();
                               List <Collections>  coll = new List <Collections>();
                                coll = _context.Collections.ToList();
                                int idco = 0;
                                foreach(var co in coll)
                                {
                                    if(co.id== modelcol.id)
                                    {
                                        idco = co.idCol;
                                    }
                                }
                                foreach(var part in modelcol.parts)
                                {
                                    parts par = new parts();
                                    par.adult = part.adult;
                                    par.backdrop_path = part.backdrop_path;
                                    par.original_language = part.original_language;
                                    par.original_title = part.original_title;
                                    par.overview = part.overview;
                                    par.release_date = part.release_date;
                                    par.poster_path = part.poster_path;
                                    par.popularity = part.popularity;
                                    par.title = part.title;
                                    par.video = part.video;
                                    par.vote_average = part.vote_average;
                                    par.vote_count = part.vote_count;
                                    par.idCol = idco;
                                    _context.parts.Add(par);
                                    _context.SaveChanges();



                                }
                            }
                        }

                    }
                    else
                    {
                        ViewData["errors"] = "Movie already exist";

                    }







                }
            }
                    return View(movie);
            
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
