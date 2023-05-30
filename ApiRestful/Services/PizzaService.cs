using ApiRestful.Models;
using System.Xml.Linq;

namespace ApiRestful.Services
{
    public static class SandwichService
    {
        static List<Sandwich> Sandwichs { get; }
        static int nextId = 3;
        static SandwichService()
        {
            Sandwichs = new List<Sandwich>
        {
            new Sandwich { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Sandwich { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
        }

        public static List<Sandwich> GetAll() => Sandwichs;

        public static Sandwich? Get(int id) => Sandwichs.FirstOrDefault(p => p.Id == id);

        public static void Add(Sandwich Sandwich)
        {
            Sandwich.Id = nextId++;
            Sandwichs.Add(Sandwich);
        }

        public static void Delete(int id)
        {
            var Sandwich = Get(id);
            if (Sandwich is null)
                return;

            Sandwichs.Remove(Sandwich);
        }

        public static void Update(Sandwich Sandwich)
        {
            var index = Sandwichs.FindIndex(p => p.Id == Sandwich.Id);
            if (index == -1)
                return;

            Sandwichs[index] = Sandwich;
        }
    }
}
