using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using modul10_103022300116;

namespace modul10_103022300116.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movieList = new List<Movie>
        {

            new Movie {title="The Shawshank Redemption" ,director = "Frank Darabont", stars = ["Tim Robbins", "Morgan Freeman", "Bob Gunton"], description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."},
            new Movie {title = "The Godfather", director = "Francis Ford Coppola", stars = ["Marlon Brando", "Al Pacino", "James Caan"], description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."},
            new Movie {title = "The Dark Knight", director = "Christopher Nolan", stars =["Christian Bale", "Heath Ledger", "Aaron Eckhart" ], description =  "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."}
        };

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return movieList;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            if (id < 0 || id >= movieList.Count)
            {
                return NotFound();
            }
            return movieList[id];
        }

        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            movieList.Add(movie);
            return CreatedAtAction(nameof(Get), new { id = movieList.Count - 1 }, movie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= movieList.Count)
            {
                return NotFound();
            }
            movieList.RemoveAt(id);
            return NoContent();

        }

    }
}
