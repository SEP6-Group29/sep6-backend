using MovieApp.Repository.Interface;
using MovieApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieApp.Data;
using System.Text.Json;
using static MovieApp.Data.Entities.OMDBModel;
using MovieApp.Data.Entities;
using System.IO;
using System.Text;

namespace MovieApp.Repository
{
    public class OmdbService : IOmdbService
    {

        //public OmdbService(HttpClient client)
        //{
        //    client = this.client;
        //}


        ////{
        ////    private HttpClient client;
        ////    private readonly IConfiguration configuration;
        ////    private readonly string path;
        ////    private readonly string source;

        ////    public OmdbService(IConfiguration config, HttpClient client)
        ////    {
        ////        config = configuration;
        ////        this.client = client;
        //public async Task<IEnumerable<FilterMovie>> getMoviePoster(int id)
        //{

        //    //movie id 3896198
        //    var uri = "https://www.omdbapi.com/?apikey=97352ccd&i=tt" + id;
        //    var response = await client.GetAsync(uri);
        //    response.EnsureSuccessStatusCode();
        //    var responseStream = await response.Content.ReadAsStringAsync();
        //    MemoryStream mStrm = new MemoryStream(Encoding.UTF8.GetBytes(responseStream));
        //    var responseObject = await JsonSerializer.DeserializeAsync<OMDBModel>(mStrm);
        //    return (IEnumerable<FilterMovie>)responseObject;

        //    }
        public Task<IEnumerable<FilterMovie>> getMoviePoster(int id)
        {
            throw new NotImplementedException();
        }
    }
}
