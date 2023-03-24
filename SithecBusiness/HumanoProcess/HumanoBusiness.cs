using SithecData.Data;
using SithecModels.Interface;
using SithecModels.Models;

namespace SithecBusiness.HumanoProcess
{
    public class HumanoBusiness
    {
        private readonly HumanoContext _context;
        public HumanoBusiness(HumanoContext context)
        {
            _context = context;
        }

        public List<Humano> consultaHumanos()
        {
            var h = _context.Humanos.ToList();
            return h;
        }

        public Humano buscaHumano(int Id)
        {
            var h = _context.Humanos.FirstOrDefault(x => x.Id == Id);
            return h;
        }

        public IHumano agregarHumano(Humano humano)
        {
            _context.Humanos.Add(humano);
            _context.SaveChanges();
            return humano;
        }

        public IHumano modificarHumano(IHumano humano)
        {
            var h = _context.Humanos.FirstOrDefault(x => x.Id == humano.Id);
            if (h != null)
            {
                h.Nombre = humano.Nombre;
                h.Edad = humano.Edad;
                h.Altura = humano.Altura;
                h.Sexo = humano.Sexo;
                h.Peso = humano.Peso;
                _context.SaveChanges();
            }
            return humano;
        }
    }
}
