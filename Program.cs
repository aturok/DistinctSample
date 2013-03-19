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

        public static IEnumerable<MovieActor> CreateSome()
        {
            return new List<MovieActor>()
            {
                new MovieActor() { FirstName = "Brad", LastName = "Pitt", CharacterName = "Rusty"},
                new MovieActor() { FirstName = "Andy", LastName = "Garcia", CharacterName = "Terry"},
                new MovieActor() { FirstName = "George", LastName = "Clooney", CharacterName = "Dany"},
                new MovieActor() { FirstName = "Jullia", LastName = "Roberts", CharacterName = "Tess"}
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2, 3, 2, 5, 5, 3 };
            foreach (var n in numbers.Distinct())
            {
                Console.WriteLine(n);
            }
            
            Console.ReadLine();
        }
    }
}
