using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;


namespace FilmProject.WEBAPI.Models
{
    public class Films
    {

        [Key]
        public Guid FilmId { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }
       
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }      
       

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }


        [JsonProperty("id")]   
        public int Id { get; set; }


        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double? Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
     

        public class Genre
        {
            [Key]
            public Guid GenreId { get; set; }

            public int id { get; set; }

            public string name { get; set; }
        }

      
    }

    public class FilmList
    {
        [JsonProperty("results")]
        public List<Films> Films { get; set; }
    }


}

