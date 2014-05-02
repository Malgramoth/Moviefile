using System;
using System.Web.Mvc;
using Moviefile.web.Models;
using Moviefile.services.Interfaces;


namespace Moviefile.web.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IMoviefileService _moviefileService;

        public ActorsController(IMoviefileService moviefileService)
        {
            _moviefileService = moviefileService;
        }

        [HttpGet]
        [Route("Actor")]

        public ActionResult ActorDetails(Guid actorId)
        {

            var model = new ActorDetailsViewModel
            {
                Actor = _moviefileService.GetSingleActor(actorId),
                Movies = _moviefileService.GetMovieCollection(actorId)
            };

            return View(model);
        }



        [Route("Movie")]
        public ActionResult MovieDetails(Guid movieId)
        {
            var model = new MovieDetailsViewModel
            {
                Movie = _moviefileService.GetSingleMovie(movieId),
                Actors = _moviefileService.GetActorCollection(movieId)
            };

            return View("../Movie/MovieDetails",model);
        }
    }
}