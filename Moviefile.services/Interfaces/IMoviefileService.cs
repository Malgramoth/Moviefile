using System.Collections.Generic;
using Moviefile.services.Model;
using System;

namespace Moviefile.services.Interfaces
{
    public interface IMoviefileService
    {
        /// <summary>
        /// Get single movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Movie GetSingleMovie(Guid id);

        /// <summary>
        /// Get single actor by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Actor GetSingleActor(Guid id);

        /// <summary>
        /// Get collection of movies staring actor by actor ID
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        IList<Movie> GetMovieCollection(Guid actorId);

        /// <summary>
        /// Get collecton of actors in movie by movie ID
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        IList<Actor> GetActorCollection(Guid movieId);

        /// <summary>
        /// Get list of movies by search criteria
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        IList<Movie> SearchMovie(string searchTerm);

        /// <summary>
        /// Get list of actors by search criteria
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        IList<Actor> SearchActor(string searchTerm);

        /// <summary>
        /// Update single movie to database
        /// </summary>
        /// <param name="movie"></param>
        void UpdateSingleMovie(Movie movie);

        /// <summary>
        /// Update a collection of movies to the database
        /// </summary>
        /// <param name="movies"></param>
        void UpdateMovieCollection(IList<Movie> movies);

        /// <summary>
        /// Update single actor to the database
        /// </summary>
        /// <param name="actor"></param>
        void UpdateSingleActor(Actor actor);

        /// <summary>
        /// Update a collection of actors to the database
        /// </summary>
        /// <param name="actors"></param>
        void UpdateActorCollection(IList<Actor> actors);


        IList<Movie> GetMovieCollection();
    }
}
