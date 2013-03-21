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
                new MovieActor() { FirstName = "Julia", LastName = "Roberts", CharacterName = "Tess"},
                new MovieActor() { FirstName = "Julia", LastName = "Roberts", CharacterName = "Julia Roberts"}
            };
        }
    }

    class ByKeyEqualityComparer<T> : IEqualityComparer<T>
    {
        public Func<T, object> KeySelector { get; set; }

        public bool Equals(T x, T y)
        {
            return KeySelector(x).Equals(KeySelector(y));
        }

        public int GetHashCode(T obj)
        {
            return KeySelector(obj).GetHashCode();
        }

        public ByKeyEqualityComparer(Func<T, object> keySelector)
        {
            KeySelector = keySelector;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var actors = MovieActor.CreateSome();
            actors.Add(new MovieActor() { FirstName = "George", LastName = "Clooney", CharacterName = "Dany"});
            
            Console.WriteLine(String.Format("{0} actors total.", actors.Count()));

            var distinct = actors.Distinct(new ByKeyEqualityComparer<MovieActor>(a => new { a.LastName, a.FirstName, a.CharacterName }));
            
            foreach (var actor in distinct)
            {
                Console.WriteLine(actor);
            }

            Console.WriteLine("\nGroup trick:");
            foreach (var actor in DistinctWithGroup(actors))
            {
                Console.WriteLine(actor);
            }
            
            Console.ReadLine();
        }

        static IEnumerable<MovieActor> DistinctWithGroup(IEnumerable<MovieActor> actors)
        {
            return actors.GroupBy(a => new { a.LastName, a.FirstName, a.CharacterName }).Select(g => g.First());
        }
    }
}
