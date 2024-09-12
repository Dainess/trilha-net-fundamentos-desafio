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
            string veiculo = FormataPlaca(Console.ReadLine());
            if (veiculo != null) veiculos.Add(veiculo);
            else Console.WriteLine("Formato de placa inválido, tente novamente");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (FormataPlaca(placa) == null) 
            {
                Console.WriteLine("Formato de placa inválido");
                return;
            }

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (Int32.TryParse(Console.ReadLine(), out int horas) == false)
                {
                    Console.WriteLine("Input de hora inválido");
                    return;
                }
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                veiculos.Remove(veiculos.First(x => x.ToUpper() == placa.ToUpper()));
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:f2}");
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
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo.ToString());
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private string FormataPlaca(string placa) 
        {
            if (placa.Length != 7) return null;
            for (int i = 0; i < placa.Length; i++)
            {
                if (i == 3 || i == 5 || i == 6)
                {
                    if (Char.IsDigit(placa[i]) == false) return null;
                } 
                else if (Char.IsLetter(placa[i]) == false) return null;
            }
            return placa;
        }
    }
}
