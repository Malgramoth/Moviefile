using Moviefile.services.Interfaces;
using System;
using System.Web.Mvc;
using Moviefile.web.Models;

namespace Moviefile.web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMoviefileService _moviefileService;
        public MovieController(IMoviefileService moviefileService)
        {
            _moviefileService = moviefileService;
        }
        [HttpGet]
        [Route("")]
        public ActionResult MovieList()
        {
            return View(_moviefileService.GetMovieCollection());
        }

        [Route("Movie")]
        public ActionResult MovieDetails(Guid movieId)
        {

            var model = new MovieDetailsViewModel
            {
                Movie = _moviefileService.GetSingleMovie(movieId),
                Actors = _moviefileService.GetActorCollection(movieId)
            };

            return View(model);
        }


        [Route("Actor")]
        public ActionResult ActorDetails(Guid actorId)
        {
            var model = new ActorDetailsViewModel
            {
                Actor = _moviefileService.GetSingleActor(actorId),
                Movies = _moviefileService.GetMovieCollection(actorId)
            };


            return View("../Actors/ActorDetails", model);
        }
	}
}