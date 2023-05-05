using DataAccess;
using Microsoft.Extensions.Configuration;
using MTModels.DTOs;
using MTModels.Entities;
using MTServices.BL.Interfaces;
using System.Data;

namespace MTServices.BL.Implementations
{
    public class Artists : IArtists
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        private SQL _sql;

        public Artists(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public Response<Artist> GetArtistByName(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                return new Response<Artist>(false, "Please enter a valid name input", System.Net.HttpStatusCode.BadRequest);
            }

            name = name.Trim();

            try
            {
                if (_connectionString == null) throw new Exception("connection string not provided");

                _sql = new SQL(_connectionString, true);

                _sql.Parameters.Add("@SearchTerm", name);

                var artists = new List<Artist>();

                var reader = _sql.ExecuteStoredProcedureDataReader("GetArtistsByName");

                while (reader.Read())
                {
                    var artist = new Artist
                    {
                        ArtistID = reader.GetInt32("artistID"),
                        Title = reader.GetString("title"),  
                        Bography = reader.GetString("biography"),
                        ImageURL = reader.GetString("imageURL"),
                        HeroURL = reader.GetString("heroURL"),
                        DateCreation = reader.GetDateTime("dateCreation")
                    };
                    artists.Add(artist);
                }
                if (!artists.Any()) return new Response<Artist>(true, "No record found for this input", System.Net.HttpStatusCode.OK);
                
                return new Response<Artist>(true, "operation successful", artists, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new Response<Artist>(false, ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }

        }
    }
}
