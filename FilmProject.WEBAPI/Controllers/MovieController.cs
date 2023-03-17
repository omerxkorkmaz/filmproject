using FilmProject.WEBAPI.EntityFramework;
using FilmProject.WEBAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmProject.WEBAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MovieController : Controller
    {
        private FilmDbContext _filmDbContext;
        public MovieController(FilmDbContext filmDbContext)
        {
            _filmDbContext = filmDbContext;
        }


    
        [HttpGet("FilmList")]
        public IActionResult FilmList(int skip, int page)
        {
            var film = _filmDbContext.Films.Include("Genres").Skip(skip).Take(page);

            return Ok(film);
        }

    
        [HttpGet("FilmGetById")]
        public IActionResult FilmGetById(int id)
        {
            var film = _filmDbContext.Films.Where(x => x.Id == id).FirstOrDefault();
            return Ok(film);
        }

       
        [HttpPost("FilmAddNoteOrPoint")]
        public IActionResult FilmAddNoteOrPoint(int id, string note, int point)
        {
            FilmNoteAndPoint filmNoteAndPoint = new FilmNoteAndPoint();

            filmNoteAndPoint.Note = note;
            filmNoteAndPoint.Point = point;
            filmNoteAndPoint.FilmsId = id;

            _filmDbContext.Add(filmNoteAndPoint);
            _filmDbContext.SaveChanges();


            return Ok(filmNoteAndPoint);
        }

      
        [HttpPost("FilmRecommend")]
        public IActionResult FilmRecommend(int id, string email)
        {
            var film = _filmDbContext.Films.Where(x => x.Id == id).FirstOrDefault();



            return Ok(film);
        }


       

    }
}
