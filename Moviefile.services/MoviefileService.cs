using Moviefile.services.Interfaces;
using Moviefile.services.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moviefile.services
{
    public class MoviefileService : IMoviefileService
    {
        private readonly data.Interfaces.IMovieRepository _movieRepository;
        private readonly data.Interfaces.IActorRepository _actorRepository;
        private readonly IMapping<Movie, data.Model.Movie> _movieMapper;
        private readonly IMapping<Actor, data.Model.Actor> _actorMapper;

        public MoviefileService(data.Interfaces.IMovieRepository movieRepository, data.Interfaces.IActorRepository actorRepository)
        {
            // TODO: Complete member initialization
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _movieMapper = new Model.Mapping.MovieMapping();
            _actorMapper = new Model.Mapping.ActorMapping();
        }


        public Movie GetSingleMovie(Guid id)
        {
            return _movieMapper.ToDTO( _movieRepository.Get(id));
        }

        public Actor GetSingleActor(Guid id)
        {
            return _actorMapper.ToDTO( _actorRepository.Get(id));
        }

        IList<Movie> IMoviefileService.GetMovieCollection(Guid actorId)
        {
            return GetMovieCollection(actorId);
        }

        IList<Actor> IMoviefileService.GetActorCollection(Guid movieId)
        {
            return GetActorCollection(movieId);
        }

        IList<Movie> IMoviefileService.SearchMovie(string searchTerm)
        {
            return SearchMovie(searchTerm);
        }

        IList<Actor> IMoviefileService.SearchActor(string searchTerm)
        {
            return SearchActor(searchTerm);
        }

        public IList<Movie> GetMovieCollection(Guid actorId)
        {
            var actor = _actorRepository.Get(actorId);
            return actor.Movies.Select(movie => _movieMapper.ToDTO(movie)).ToList();
        }

        public IList<Actor> GetActorCollection(Guid movieId)
        {
            var movie = _movieRepository.Get(movieId);
            var actors = new List<Actor>();
            foreach (var actor in movie.Actors)
            {
                actors.Add(_actorMapper.ToDTO(actor));
            }
            return actors;
           
        }

        public void UpdateActorCollection(IList<Actor> actors)
        {
            throw new NotImplementedException();
        }

        IList<Movie> IMoviefileService.GetMovieCollection()
        {
            return GetMovieCollection();
        }

        public IList<Movie> GetMovieCollection()
        {
            var movies = _movieRepository.Get().ToList();
            return movies.Select(movie => _movieMapper.ToDTO(movie)).ToList();
        }

        public IList<Movie> SearchMovie(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public IList<Actor> SearchActor(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovieCollection(IList<Movie> movies)
        {
            throw new NotImplementedException();
        }

        public void UpdateSingleActor(Actor actor)
        {
            throw new NotImplementedException();
        }

    }
}

/* todo controller, view, action */
