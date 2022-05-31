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

                    var idserie = serie.id;
                    Series serieb = new Series {
                        idSerie = serie.id,
                        name = serie.name.ToString(),
                        original_name = serie.original_name.ToString(),
                        first_air_date = serie.first_air_date.ToString(),
                        backdrop_path = serie.backdrop_path,
                        homepage = serie.homepage.ToString(),
                        in_production = serie.in_production.ToString(),
                        languages = serie.languages.ToString(),
                        origin_country = serie.origin_country.ToString(),
                        last_air_date = serie.last_air_date.ToString(),
                        number_of_episodes = serie.number_of_episodes,
                        number_of_seasons = serie.number_of_seasons,
                        status = serie.status.ToString(),
                        type = serie.type.ToString(),
                        original_language = serie.original_language.ToString(),
                        overview = serie.overview.ToString(),
                        popularity = serie.popularity,
                        poster_path = serie.poster_path.ToString(),
                        tagline = serie.tagline.ToString(),
                        vote_average = serie.vote_average,
                        vote_count = serie.vote_count
                       
                                };
                    _client.Cypher
                        .Create("(serie:Series $serieb)")
                        .WithParam("serieb", serieb)
                        .ExecuteWithoutResultsAsync()
                        .Wait();
                    if (serie.Created_by != null)
                    {
                        foreach (var createur in serie.Created_by)
                        {

                            Createurs crea = new Createurs
                            {



                                id = createur.id,
                                credit_id = createur.credit_id.ToString(),
                                name = createur.name.ToString(),
                                gender = createur.gender.ToString(),
                                profile_path = createur.profile_path.ToString(),
                                Seriesid = createur.Seriesid = serie.id
                            };
                            _client.Cypher
                           .Create("(createur:Createurs $crea)")
                           .WithParam("crea", crea)
                           .ExecuteWithoutResultsAsync()
                           .Wait();

                        }
                        _client.Cypher
    .Match("(serie:Series)", "(createur:Createurs)")
    .Where((Series serie) => serie.idSerie == idserie)
    .AndWhere((Createurs createur) => createur.Seriesid == idserie)
    .Create("(serie)-[:CREATED_BY]->(createur)")
    .ExecuteWithoutResultsAsync()
    .Wait();
                    }
                    foreach (var network in serie.Networks)
                    {
                        Networks net = new Networks {
                            id=network.id,
                        name=network.name.ToString(),
                        origin_country=network.origin_country.ToString(),
                        idSerie=network.idSerie = idserie
                        
                            };
                        _client.Cypher
                       .Create("(network:Networks $net)")
                       .WithParam("net", net)
                       .ExecuteWithoutResultsAsync()
                       .Wait();
                    }
                    _client.Cypher
.Match("(serie:Series)", "(network:Networks)")
.Where((Series serie) => serie.idSerie == idserie)
.AndWhere((Networks network) => network.idSerie == idserie)
.Create("(serie)-[:BELONGS_TO_NET]->(network)")
.ExecuteWithoutResultsAsync()
.Wait();
                    using (var responsev = await httpClient.GetAsync("tv/" + serie1.id + "/videos?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                        {
                            // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                            string responseDatav = await responsev.Content.ReadAsStringAsync();

                            var modelv = JsonConvert.DeserializeObject<listVideos>(responseDatav);
                            //  _context.Series.Add(serie);
                            //_context.SaveChanges();

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
                                idMovie = serie.id
                            };
                            _client.Cypher
                      .Create("(video:Videos $video1)")
                      .WithParam("video1", video1)
                      .ExecuteWithoutResultsAsync()
                      .Wait();
                            
                            }
                        _client.Cypher
.Match("(serie:Series)", "(video:Videos)")
.Where((Series serie) => serie.idSerie == idserie)
.AndWhere((Videos video) => video.idMovie == idserie)
.Create("(serie)-[:HAS_VIDEO]->(video)")
.ExecuteWithoutResultsAsync()
.Wait();
                    }
                       
                       
                       
                     foreach (var genre in serie.genres)
                     {
                        var genre1 = new Genres
                        {
                            id = genre.id,
                            name = genre.name,
                            idgenre = serie.id
                        };
                        _client.Cypher
                      .Create("(genre:Genres $genre1)")
                      .WithParam("genre1", genre1)
                      .ExecuteWithoutResultsAsync()
                      .Wait();


                     }
                    _client.Cypher
.Match("(serie:Series)", "(genre:Genres)")
.Where((Series serie) => serie.idSerie == idserie)
.AndWhere((Genres genre) => genre.idgenre == idserie)
.Create("(serie)-[:BELONGS_ON_GENRE]->(genre)")
.ExecuteWithoutResultsAsync()
.Wait();



                    using (var responseimg = await httpClient.GetAsync("tv/" + serie.id + "/images?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                        {
                            // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                            string responseDataimg = await responseimg.Content.ReadAsStringAsync();
                            var modelimg = JsonConvert.DeserializeObject<ResultImg>(responseDataimg);

                        foreach (var poster in modelimg.posters)
                        {

                            Images img = new Images {
                             idImage = idserie,
                            aspect_ratio = poster.aspect_ratio,
                          file_path = poster.file_path,
                            height = poster.height,
                            iso_639_1 = poster.iso_639_1,
                            vote_average = poster.vote_average,
                            vote_count = poster.vote_count,
                            width = poster.width
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
                                idImage = serie.id,
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
                        _client.Cypher
    .Match("(serie:Series)", "(image:Images)")
    .Where((Series serie) => serie.idSerie == idserie)
    .AndWhere((Images image) => image.idImage == idserie)
    .Create("(serie)-[:HAS_IMAGE]->(image)")
    .ExecuteWithoutResultsAsync()
    .Wait();
                       

                               
                               
                    }
                    foreach (var prodcountrie in serie.production_countries)
                    {

                        Productioncountries prodcount = new Productioncountries
                        {

                            iso_3166_1 = prodcountrie.iso_3166_1,
                            name = prodcountrie.name,
                            idProdCountry = serie.id
                        };
                        _client.Cypher
                      .Create("(productioncountrie:Productioncountries $prodcount)")
                      .WithParam("prodcount", prodcount)
                      .ExecuteWithoutResultsAsync()
                      .Wait();

                    }
                    _client.Cypher
    .Match("(serie:Series)", "(productioncountrie:Productioncountries)")
    .Where((Series serie) => serie.idSerie == idserie)
    .AndWhere((Productioncountries productioncountrie) => productioncountrie.idProdCountry == idserie)
    .Create("(serie)-[:PRODUCTED_BY]->(productioncountrie)")
    .ExecuteWithoutResultsAsync()
    .Wait();
                    foreach (var prodcompany in serie.production_companies)
                    {

                        ProductionCompanies prodcomp = new ProductionCompanies
                        {

                            logo_path = prodcompany.logo_path,
                            name = prodcompany.name,
                            origin_country = prodcompany.origin_country,
                            id = prodcompany.id,
                            idProdCompany = idserie
                        };
                        _client.Cypher
                      .Create("(productioncompanie:ProductionCompanies $prodcomp)")
                      .WithParam("prodcomp", prodcomp)
                      .ExecuteWithoutResultsAsync()
                      .Wait();
                    }
                    _client.Cypher
   .Match("(serie:Series)", "(productioncompanie:ProductionCompanies)")
   .Where((Series serie) => serie.idSerie == idserie)
   .AndWhere((ProductionCompanies productioncompanie) => productioncompanie.idProdCompany == idserie)
   .Create("(serie)-[:PRODUCTED_IN]->(productioncompanie)")
   .ExecuteWithoutResultsAsync()
   .Wait();
                    foreach (var spokenlgge in serie.spoken_languages)
                    {

                        SpokenLanguages spknlgge = new SpokenLanguages
                        {
                            name = spokenlgge.name,
                            english_name = spokenlgge.english_name,
                            iso_639_1 = spokenlgge.iso_639_1,
                            idSpkenLgge = idserie
                        };
                        _client.Cypher
                      .Create("(spokenlanguages:SpokenLanguages $spknlgge)")
                      .WithParam("spknlgge", spknlgge)
                      .ExecuteWithoutResultsAsync()
                      .Wait();
                    }
                    _client.Cypher
   .Match("(serie:Series)", "(spokenlanguages:SpokenLanguages)")
   .Where((Series serie) => serie.idSerie == idserie)
   .AndWhere((SpokenLanguages spokenlanguages) => spokenlanguages.idSpkenLgge == idserie)
   .Create("(serie)-[:SPEAK]->(spokenlanguages)")
   .ExecuteWithoutResultsAsync()
   .Wait();
                    var idseason = 0;
                    foreach (var season in serie.Seasons)
                    {
                        idseason = season.id;
                        using (var responseSeason = await httpClient.GetAsync("tv/" + serie.id + "/season/" + season.season_number + "?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                        {
                            // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                            string responseDataSeason = await responseSeason.Content.ReadAsStringAsync();
                            var modelSeason = JsonConvert.DeserializeObject<Seasons>(responseDataSeason);
                            ViewBag.season = season;

                            Seasons seasonb = new Seasons()
                            {
                                idSeason = season.id,
                                name = season.name,
                                air_date = season.air_date,
                                overview = season.overview,
                                poster_path = season.poster_path,
                                season_number = season.season_number,
                                idSerie = idserie
                            };
                            _client.Cypher
                     .Create("(season:Seasons $seasonb)")
                     .WithParam("seasonb", seasonb)
                     .ExecuteWithoutResultsAsync()
                     .Wait();
                        
                       
                        using (var responseSeasonimg = await httpClient.GetAsync("tv/" + serie.id + "/season/" + season.season_number + "/images?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                            {
                                // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                string responseDataSeasonimg = await responseSeasonimg.Content.ReadAsStringAsync();
                                var modelSeasonimg = JsonConvert.DeserializeObject<ResultImg>(responseDataSeasonimg);
                                //ViewBag.season = season;

                                foreach (var poster in modelSeasonimg.posters)
                                {


                                    Images img = new Images
                                    {
                                        idImage = idseason,
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

                                _client.Cypher
   .Match("(season:Seasons)", "(image:Images)")
   .Where((Seasons season) => season.idSeason == idseason)
   .AndWhere((Images image) => image.idImage == idseason)
   .Create("(season)-[:HAS_IMAGE]->(image)")
   .ExecuteWithoutResultsAsync()
   .Wait();

                            }

                            using (var responsevs = await httpClient.GetAsync("tv/" + serie1.id + "/season/" + season.season_number + "/videos?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                            {
                                // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                string responseDatavs = await responsevs.Content.ReadAsStringAsync();

                                var modelvs = JsonConvert.DeserializeObject<listVideos>(responseDatavs);
                                foreach (var video in modelvs.results)
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
                                        idMovie = idseason
                                    };
                                    _client.Cypher
                              .Create("(video:Videos $video1)")
                              .WithParam("video1", video1)
                              .ExecuteWithoutResultsAsync()
                              .Wait();



                                }
                                _client.Cypher
        .Match("(season:Seasons)", "(video:Videos)")
        .Where((Seasons season) => season.idSeason == idseason)
        .AndWhere((Videos video) => video.idMovie == idseason)
        .Create("(season)-[:HAS_VIDEO]->(video)")
        .ExecuteWithoutResultsAsync()
        .Wait();
                                
                            }
                            foreach (var episode in modelSeason.episodes)
                            {
                                using (var responseEp = await httpClient.GetAsync("tv/" + serie1.id + "/season/" + season.season_number + "/episode/" + episode.episode_number + "?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                                {
                                    // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                    string responseDataEp = await responseEp.Content.ReadAsStringAsync();

                                    var modelEp = JsonConvert.DeserializeObject<Episodes>(responseDataEp);
                                    var idepisode = episode.id;
                                    Episodes ep = new Episodes {
                                        id = episode.id,
                                        name = episode.name,
                                        air_date = episode.air_date,
                                        overview = episode.overview,
                                        production_code = episode.production_code,
                                        season_number = episode.season_number,
                                    episode_number = episode.episode_number,
                                        still_path = episode.still_path,
                                    vote_count = episode.vote_count,
                                    vote_average = episode.vote_average,
                                    idSeason = idseason,
                                    idEpisode=episode.id
                                           
                                    };
                                    _client.Cypher
                                    .Create("(episode:Episodes $ep)")
                              .WithParam("ep", ep)
                              .ExecuteWithoutResultsAsync()
                              .Wait();


                                  


                                    using (var responseEpimg = await httpClient.GetAsync("tv/" + serie.id + "/season/" + season.season_number + "/episode/" + episode.episode_number + "/images?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                                    {
                                        // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                        string responseDataEpimg = await responseEpimg.Content.ReadAsStringAsync();
                                        var modelEpimg = JsonConvert.DeserializeObject<ResultImg>(responseDataEpimg);
                                        if (modelEpimg.posters != null)
                                        {
                                            foreach (var poster in modelEpimg.posters)
                                            {


                                                Images img = new Images
                                                {
                                                    idImage = idepisode,
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

                                            _client.Cypher
               .Match("(episode:Episodes)", "(image:Images)")
               .Where((Episodes episode) => episode.idEpisode == idepisode)
               .AndWhere((Images image) => image.idImage == idepisode)
               .Create("(episode)-[:HAS_IMAGE]->(image)")
               .ExecuteWithoutResultsAsync()
               .Wait();
                                        }
                                    }
                                    using (var responseEpvid = await httpClient.GetAsync("tv/" + serie.id + "/season/" + season.season_number + "/episode/" + episode.episode_number + "/videos?api_key=e713d6b21cffe24a1f790d41f6e8f4a3"))
                                    {
                                        // const API_URL = BASE_URL + '/discover/movie?sort_by=popularity.desc&' + API_KEY;

                                        string responseDataEpvid = await responseEpvid.Content.ReadAsStringAsync();
                                        var modelEpvid = JsonConvert.DeserializeObject<listVideos>(responseDataEpvid);
                                        foreach (var video in modelEpvid.results)
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
                                                idMovie = episode.id
                                            };
                                            _client.Cypher
                                      .Create("(video:Videos $video1)")
                                      .WithParam("video1", video1)
                                      .ExecuteWithoutResultsAsync()
                                      .Wait();



                                        }
                                        _client.Cypher
                .Match("(episode:Episodes)", "(video:Videos)")
                .Where((Episodes episode) => episode.idEpisode == idepisode)
                .AndWhere((Videos video) => video.idMovie == idepisode)
                .Create("(episode)-[:HAS_VIDEO]->(video)")
                .ExecuteWithoutResultsAsync()
                .Wait();
                                                }
                                    foreach (var star in modelEp.guest_stars)
                                    {
                                        GuestStars gs = new GuestStars {
                                          id = star.id,
                                          name = star.name,
                                          order = star.order,
                                          original_name = star.original_name,
                                          known_for_department = star.known_for_department,
                                          popularity = star.popularity,
                                          profile_path = star.profile_path,
                                          gender = star.gender,
                                          adult = star.adult,
                                          character = star.character,
                                          credit_id = star.credit_id,
                                          idEpisode = episode.id
                                                         };
                                        _client.Cypher
                                     .Create("(star:GuestStars $gs)")
                                     .WithParam("gs", gs)
                                     .ExecuteWithoutResultsAsync()
                                     .Wait();

                                    }
                                    _client.Cypher
               .Match("(episode:Episodes)", "(star:GuestStars)")
               .Where((Episodes episode) => episode.idEpisode == idepisode)
               .AndWhere((GuestStars star) => star.idEpisode == idepisode)
               .Create("(star)-[:PARTICIPATE_IN]->(episode)")
               .ExecuteWithoutResultsAsync()
               .Wait();
                                    foreach (var crew in modelEp.crew)
                                    {
                                        Crew crw = new Crew {
                                            id = crew.id,
                                        name = crew.name,
                                        credit_id = crew.credit_id,
                                        departement = crew.departement,
                                        job = crew.job,
                                        profile_path = crew.profile_path,
                                        idEp = idepisode
                                                  };
                                        _client.Cypher
                                     .Create("(crew:Crew $crw)")
                                     .WithParam("crw", crw)
                                     .ExecuteWithoutResultsAsync()
                                     .Wait();
                                    }
                                    _client.Cypher
              .Match("(episode:Episodes)", "(crew:Crew)")
              .Where((Episodes episode) => episode.idEpisode == idepisode)
              .AndWhere((Crew crew) => crew.idEp == idepisode)
              .Create("(crew)-[:PRESENT_IN]->(episode)")
              .ExecuteWithoutResultsAsync()
              .Wait();

                                }
                            }
                            _client.Cypher
      .Match("(season:Seasons)", "(episode:Episodes)")
      .Where((Seasons season) => season.idSeason == idseason)
      .AndWhere((Episodes episode) => episode.idSeason == idseason)
      .Create("(season)-[:HAS_EPISODE]->(episode)")
      .ExecuteWithoutResultsAsync()
      .Wait();

                        }
                    }
                    _client.Cypher
      .Match("(serie:Series)", "(season:Seasons)")
      .Where((Series serie) => serie.idSerie == idserie)
      .AndWhere((Seasons season) => season.idSerie == idserie)
      .Create("(serie)-[:HAS_SEASON]->(season)")
      .ExecuteWithoutResultsAsync()
      .Wait();
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
