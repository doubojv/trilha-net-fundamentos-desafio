namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if(ValidaPlaca(placa)){
                veiculos.Add(placa);
            }
            else{
                throw new FormatException("A placa não está no formato correto (LLL-NNNN).");
            }
        }
        private bool ValidaPlaca(string placa){

            string pattern = @"^[A-Z]{3}-\d{4}$";
            return System.Text.RegularExpressions.Regex.IsMatch(placa, pattern);

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placaR = Console.ReadLine();
            
            if (veiculos.Any(x => x.ToUpper() == placaR.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = 0; 
                valorTotal = (horas * precoPorHora) + precoInicial;
                veiculos.Remove(placaR);
                Console.WriteLine($"O veículo {placaR} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var veiculo in veiculos){
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
