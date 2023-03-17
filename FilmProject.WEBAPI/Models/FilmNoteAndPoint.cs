using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmProject.WEBAPI.Models
{
    public class FilmNoteAndPoint
    {
        public Guid Id { get; set; }

        public string Note { get; set; }

        [Range(1, 10, ErrorMessage = "Lütfen 1-10 arasında bir sayı giriniz.")]
        public int Point { get; set; }
    
        public int FilmsId { get; set; }

    


    }
}
