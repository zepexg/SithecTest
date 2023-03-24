namespace SithecBusiness.OperacionesProcess
{
    public class OperacionesBusiness
    {
        public string realizaOperacion(double PrimerValor, char Operador, double SegundoValor)
        {
            string operacion = $" {PrimerValor} {Operador} {SegundoValor} = ";
            double res = 0;
            switch (Operador)
            {
                case '+':
                    res = PrimerValor + SegundoValor;
                    break;
                case '-':
                    res = PrimerValor - SegundoValor;
                    break;
                case '*':
                case 'x':
                    res = PrimerValor * SegundoValor;
                    break;
                case '/':
                    res = PrimerValor / SegundoValor;
                    break;
            }
            return operacion + res.ToString();
        }
    }
}
