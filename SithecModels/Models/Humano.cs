using SithecModels.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SithecModels.Models
{
    public class Humano : IHumano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public char Sexo { get; set; }
        public int Edad { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }

    }
}
