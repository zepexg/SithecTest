using SithecData.Data;
using SithecModels.Models;

namespace SithecData
{
    public static class DbInitializer
    {
        public static void Initialize(HumanoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Humanos.Any())
            {
                return;
            }

            var humanos = new Humano[]
            {
            new Humano{Nombre="Pablo", Edad=31, Sexo='h', Altura=1.70, Peso=85},
            new Humano{Nombre="Pedro", Edad=23, Sexo='h', Altura=1.50, Peso=70},
            new Humano{Nombre="Ana", Edad=28, Sexo='m', Altura=1.60, Peso=50},
            new Humano{Nombre="Lety", Edad=17, Sexo='m', Altura=1.67, Peso=55},
            };
            foreach (Humano s in humanos)
            {
                context.Humanos.Add(s);
            }
            context.SaveChanges();
        }
    }
}
