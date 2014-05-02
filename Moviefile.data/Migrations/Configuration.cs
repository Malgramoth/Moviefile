using Moviefile.data.Model;

namespace Moviefile.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<Moviefile.data.MoviefileContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoviefileContext context)
        {
            // Actors
            var ginaDavis = new Actor
            {
                Name = "Gina Davis",
                Dob = DateTime.Now.AddYears(-34)
            };
            var tomCruise = new Actor
            {
                Name = "Tom Cruise",
                Dob = DateTime.Now.AddYears(-42)
            };
            var willFarrel = new Actor
            {
                Name = "Will Farrel",
                Dob = DateTime.Now.AddYears(-34)
            };
            var kevinSmith = new Actor
            {
                Name = "Kevin Smith",
                Dob = DateTime.Now.AddYears(-27)
            };
            var jasonMewes = new Actor
            {
                Name = "Jason Mewes",
                Dob = DateTime.Now.AddYears(-25)
            };
            var bruceWillis = new Actor
            {
                Name = "Bruce Willis",
                Dob = DateTime.Now.AddYears(-54)
            };
            var samuelLJackson = new Actor
            {
                Name = "Samuel L Jackson",
                Dob = DateTime.Now.AddYears(-50)
            };


            context.Actors.AddOrUpdate(
                a => a.Name,
                ginaDavis,
                tomCruise,
                willFarrel,
                kevinSmith,
                jasonMewes,
                bruceWillis,
                samuelLJackson
            );
            context.SaveChanges();

            // Movies
            var minorityReport = new Movie
            {
                Title = "Minority Report",
                Genre = "Sci-Fi",
                CoverImage = "minorityreport.jpg",
                Release = DateTime.Now.AddYears(-3),
            };
            minorityReport.Actors.Add(tomCruise);
            minorityReport.Actors.Add(ginaDavis);

            var theLongKissGoodnight = new Movie
            {
                Title = "The Long Kiss Goodnight",
                Genre = "Action",
                CoverImage = "thelongkissgoodnight.jpg",
                Release = DateTime.Now.AddYears(-10)
            };
            theLongKissGoodnight.Actors.Add(ginaDavis);
            theLongKissGoodnight.Actors.Add(samuelLJackson);

            var dieHard = new Movie
            {
                Title = "Die Hard",
                Genre = "Action",
                CoverImage = "diehard.jpg",
                Release = DateTime.Now.AddYears(-16)
            };
            dieHard.Actors.Add(bruceWillis);

            var cutThroatIsland = new Movie
            {
                Title = "Cut Thoroat Island",
                Genre = "Action",
                CoverImage = "cutthroatisland.jpg",
                Release = DateTime.Now.AddYears(-16)
            };
            cutThroatIsland.Actors.Add(ginaDavis);
            var jayAndSilentBobStrikeBack = new Movie
            {
                Title = "Jay And Silent Bob Strike Back",
                Genre = "Comedy",
                CoverImage = "jayandsilentbobstrikeback.jpg",
                Release = DateTime.Now.AddYears(-9)
            };
            jayAndSilentBobStrikeBack.Actors.Add(kevinSmith);
            jayAndSilentBobStrikeBack.Actors.Add(jasonMewes);
            jayAndSilentBobStrikeBack.Actors.Add(willFarrel);
            context.Movies.AddOrUpdate(
                m => m.Title,
                minorityReport,
                theLongKissGoodnight,
                cutThroatIsland,
                dieHard,
                jayAndSilentBobStrikeBack
            );
        }
    }
}
