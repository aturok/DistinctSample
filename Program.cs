using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctSample
{
    class MovieActor
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CharacterName { get; set; }

        public override string ToString()
        {
            return String.Format("{0} \"{1}\" {2}", FirstName, CharacterName, LastName);
        }

        public static List<MovieActor> CreateSome()
        {
            return new List<MovieActor>()
            {
                new MovieActor() { FirstName = "Brad", LastName = "Pitt", CharacterName = "Rusty"},
                new MovieActor() { FirstName = "Andy", LastName = "Garcia", CharacterName = "Terry"},
                new MovieActor() { FirstName = "George", LastName = "Clooney", CharacterName = "Dany"},
                new MovieActor() { FirstName = "Julia", LastName = "Roberts", CharacterName = "Tess"}
            };
        }
    }

    class ActorComparer : IEqualityComparer<MovieActor>
    {
        public bool Equals(MovieActor x, MovieActor y)
        {
            Console.WriteLine("Equals called on " + x.ToString() + " " + y.ToString());
            return
                x.LastName == y.LastName &&
                x.FirstName == y.FirstName &&
                x.CharacterName == y.CharacterName;
        }

        public int GetHashCode(MovieActor obj)
        {
            Console.WriteLine("Hash called on " + obj.ToString() + " (" + obj.GetHashCode() + ")");
            return obj.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var actors = MovieActor.CreateSome();
            actors.Add(new MovieActor() { FirstName = "George", LastName = "Clooney", CharacterName = "Dany"});

            Console.WriteLine(String.Format("{0} actors total.", actors.Count()));

            var distinct = actors.Distinct(new ActorComparer());
            Console.WriteLine(String.Format("\n{0} distinct actors.", distinct.Count()));

            foreach (var actor in distinct)
            {
                Console.WriteLine(actor);
            }
            
            Console.ReadLine();
        }
    }
}
