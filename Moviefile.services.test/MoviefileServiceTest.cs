using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moviefile.data.Interfaces;
using Moq;
using System.Collections.ObjectModel;
using Moviefile.services.Interfaces;
using System.Collections.Generic;
using System.Collections;
using System.Linq.Expressions;
using MovieEntity = Moviefile.data.Model.Movie;
using MovieDto = Moviefile.services.Model.Movie;
using ActorEntity = Moviefile.data.Model.Actor;
using ActorDto = Moviefile.services.Model.Actor;
using System.Linq;

namespace Moviefile.services.test
{
    [TestClass]
    public class MoviefileServiceTest
    {

        private Mock<IMovieRepository> _movieRepository;
        private Mock<IActorRepository> _actorRepository;
        private DateTime _dateTime = DateTime.Now;

        [TestCleanup]
        public void CleanUp()
        {
            _movieRepository = null;
            _actorRepository = null;
        }



        [TestInitialize]
        public void init()
        {
            _actorRepository = new Mock<IActorRepository>();
            _movieRepository = new Mock<IMovieRepository>();

            var _actor1 = new Moviefile.data.Model.Actor {
                Id = new Guid("b94eabaa-e4d2-4665-994b-a2b4a539c416"),
                Dob = _dateTime,
                Name = "John Smith"
            };
            var _actor2 = new Moviefile.data.Model.Actor {
                Id = new Guid("137e53d2-f8ad-4bae-a980-2f487d3a8d97"),
                Dob = _dateTime,
                Name = "kiefer sutherland"
            };
            var _movie1 = new MovieEntity 
            {
                CoverImage = "Image1",
                Genre = "Horror",
                Id = new Guid("1f3ea22d-79ca-4a1f-a115-d2d79c39efb2"),
                Release = _dateTime,
                Title = "Shining"
            };
            var _movie2 = new MovieEntity 
            {
                CoverImage = "Image2",
                Genre = "Horror",
                Id = new Guid("e0004d64-6cd8-46ff-9a4f-569849bd702e"),
                Release = _dateTime,
                Title = "Event Horizon"                
            };
            _actor1.Movies = new List<MovieEntity> { _movie1, _movie2 };
            _actor2.Movies = new List<MovieEntity> { _movie2 };
            _movie1.Actors = new List<Moviefile.data.Model.Actor> { _actor1};
            _movie2.Actors = new List<Moviefile.data.Model.Actor> { _actor1, _actor2 };
             
            _movieRepository.Setup(m => m.Get(It.IsAny<Expression<Func<MovieEntity, bool>>>()))
                .Returns(new Collection<MovieEntity> 
            {
                _movie1, _movie2
            }.AsQueryable());


            _actorRepository.Setup(a => a.Get(It.IsAny<Guid>())).Returns(_actor1);

            _movieRepository.Setup(m => m.Get(It.IsAny<Guid>())).Returns(_movie1);

            }

        [TestMethod]
        public void TestGetSingleMovie()
        {
            IMoviefileService MoviefileService = new MoviefileService(_movieRepository.Object, _actorRepository.Object);
            var Movie = MoviefileService.GetSingleMovie(Guid.NewGuid());
            Assert.IsInstanceOfType(Movie, typeof(Moviefile.services.Model.Movie));
            Assert.AreEqual("Image1", Movie.CoverImage);
        }

        [TestMethod]
        public void TestGetSingleActor()
        {
            IMoviefileService MoviefileService = new MoviefileService(_movieRepository.Object, _actorRepository.Object);
            var Actor = MoviefileService.GetSingleActor(Guid.NewGuid());
            Assert.IsInstanceOfType(Actor, typeof(Moviefile.services.Model.Actor));
            Assert.AreEqual("John Smith",Actor.Name);

        }

        [TestMethod]
        public void TestGetMovieCollection()
        {
            IMoviefileService MoviefileService = new MoviefileService(_movieRepository.Object, _actorRepository.Object);
            var Movies = MoviefileService.GetMovieCollection(Guid.NewGuid());
            Assert.IsInstanceOfType(Movies, typeof(IList<MovieDto>));
            Assert.AreEqual(2, Movies.Count);
        }

        [TestMethod]
        public void TestGetActorCollection()
        {
            IMoviefileService MoviefileService = new MoviefileService(_movieRepository.Object, _actorRepository.Object);
            var Actors = MoviefileService.GetActorCollection(Guid.NewGuid());
            Assert.IsInstanceOfType(Actors, typeof(IList<ActorDto>));
            Assert.AreEqual(1, Actors.Count);

        }

   }

}
