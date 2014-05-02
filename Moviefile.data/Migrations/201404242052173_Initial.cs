namespace Moviefile.data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Dob = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .Index(a => a.Name, true);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Release = c.DateTime(nullable: false),
                        Genre = c.String(nullable: false, maxLength: 40),
                        CoverImage = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .Index(m => m.Title, true);
            
            CreateTable(
                "dbo.ActorMovies",
                c => new
                    {
                        Actor_Id = c.Guid(nullable: false),
                        Movie_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_Id, t.Movie_Id })
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Actor_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.ActorMovies", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.ActorMovies", new[] { "Movie_Id" });
            DropIndex("dbo.ActorMovies", new[] { "Actor_Id" });
            DropTable("dbo.ActorMovies");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
