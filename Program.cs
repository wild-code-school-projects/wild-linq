using System.Collections.Generic;

namespace ConsoleApp1
{

    internal class AnimalContext
    {
        public List<Animal> Animals { get; set; }
        public List<Species> Species { get; set; }

        public AnimalContext()
        {
            Animals = new List<Animal>();
            Species = new List<Species>();
        }
    }

    public class Animal
    {
        public Guid AnimalId { get; set; }
        public String Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Species Species { get; set; }

    }


    public class Species
    {
        public Guid SpeciesId { get; set; }
        public String Name { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AnimalContext();

            var whiteCougars = new Species { SpeciesId = Guid.NewGuid(), Name = "White Cougars" };
            var whiteTigers = new Species { SpeciesId = Guid.NewGuid(), Name = "White Tigers" };
            var albinoTurtles = new Species { SpeciesId = Guid.NewGuid(), Name = "Albino Turtles" };

            context.Species.Add(whiteCougars);
            context.Species.Add(whiteTigers);
            context.Species.Add(albinoTurtles);

            // Ajouter des animaux à la liste
            for (int i = 0; i < 3; i++)
            {
                context.Animals.Add(new Animal { AnimalId = Guid.NewGuid(), Name = $"White Cougar {i + 1}", DateOfBirth = DateTime.Today, Species = whiteCougars });
            }

            for (int i = 0; i < 100; i++)
            {
                context.Animals.Add(new Animal { AnimalId = Guid.NewGuid(), Name = $"White Tiger {i + 1}", DateOfBirth = DateTime.Today, Species = whiteTigers });
            }

            for (int i = 0; i < 15; i++)
            {
                context.Animals.Add(new Animal { AnimalId = Guid.NewGuid(), Name = $"Albino Turtle {i + 1}", DateOfBirth = DateTime.Today, Species = albinoTurtles });
            }

            DisplayProtectedSpeciesCount(context);
        }

        static void DisplayProtectedSpeciesCount(AnimalContext context)
        {
            var protectedSpecies = context.Species.Where(s => s.Name.ToLower() == "White Cougars".ToLower() || s.Name.ToLower() == "White Tigers".ToLower() || s.Name.ToLower() == "Albino Turtles".ToLower());

            foreach (var species in protectedSpecies)
            {
                var count = context.Animals.Count(a => a.Species.SpeciesId == species.SpeciesId);
                Console.WriteLine($"{species.Name}: {count}");
            }
        }
    }
}
