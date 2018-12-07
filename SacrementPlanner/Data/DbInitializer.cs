using SacrementPlanner.Models;
using System;
using System.Linq;

namespace SacrementPlanner.Models
{
    public class DbInitializer
    {
        public static void Initialize(BulletinContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any planners.
            if (context.Planner.Any())
            {
                return; // DB has been seeded
            }

            var bishopric = new Bishopric[]
            {
                new Bishopric{Name="Carson Alexander", Active=false},
                new Bishopric{Name="Arturo Anand", Active=false},
                new Bishopric{Name="Yan Li", Active=true},
                new Bishopric{Name="Nino Olivetto", Active=true},
                new Bishopric{Name="Peter Justice", Active=true}
            };
            foreach (Bishopric b in bishopric)
            {
                context.Bishoprics.Add(b);
            }
            context.SaveChanges();

            var planner = new Planner[]
            {
                new Planner{OpeningSong="",SacramentSong="",IntermediateSong="",ClosingSong="", Conductor=1, SacramentDate=DateTime.Parse("2009-05-06")},
                new Planner{OpeningSong="",SacramentSong="",IntermediateSong="",ClosingSong="", Conductor=2, SacramentDate=DateTime.Parse("2009-06-08")},
                new Planner{OpeningSong="",SacramentSong="",IntermediateSong="",ClosingSong="", Conductor=3, SacramentDate=DateTime.Parse("2009-11-25")},
                new Planner{OpeningSong="",SacramentSong="",IntermediateSong="",ClosingSong="", Conductor=4, SacramentDate=DateTime.Parse("2012-01-15")},
                new Planner{OpeningSong="",SacramentSong="",IntermediateSong="",ClosingSong="", Conductor=5, SacramentDate=DateTime.Parse("2018-07-12")},
                new Planner{OpeningSong="",SacramentSong="",IntermediateSong="",ClosingSong="", Conductor=1, SacramentDate=DateTime.Parse("2016-06-02")}
            };

            var speakers = new Speakers[]
            {
                new Speakers{Name="Meredith Alonso", Topic="Faith", PlannerId=1},
                new Speakers{Name="Gytis Barzdukas", Topic="Peace", PlannerId=1},
                new Speakers{Name="Peggy Justice", Topic="Justice", PlannerId=2},
                new Speakers{Name="Laura Norman", Topic="Mercy", PlannerId=2},
                new Speakers{Name="Marinette DupanChang", Topic="Love", PlannerId=2},
                new Speakers{Name="Adrian Agreste", Topic="Family", PlannerId=3},
                new Speakers{Name="Alya Cesaire", Topic="Persevering", PlannerId=3},
                new Speakers{Name="Briar Rose", Topic="Being active in the Faith", PlannerId=4},
                new Speakers{Name="Henry Charming", Topic="Pursing your Goals", PlannerId=4},
                new Speakers{Name="Steve Ancho", Topic="Spiritual Health", PlannerId=5},
                new Speakers{Name="Nathan Jimbob", Topic="Divine Nature", PlannerId=5},
            };

        }
    }
}
