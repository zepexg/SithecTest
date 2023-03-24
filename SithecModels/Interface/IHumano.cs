namespace SithecModels.Interface
{
    public interface IHumano
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public char Sexo { get; set; }
        public int Edad { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
    }
}
