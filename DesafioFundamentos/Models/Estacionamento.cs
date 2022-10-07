using System.Text.RegularExpressions;

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

        public void ValidarPlaca(ref string placa)
        {
            //Pede ao usuário que digite a placa e verifica se a mesma é válida.
            placa = "";
            string padraoPlaca = "[A-Z]{3}-[0-9][0-9A-Z][0-9]{2}";
            Regex validaPlaca = new Regex(padraoPlaca, RegexOptions.IgnoreCase);

            while(true)
            {
                Console.WriteLine("Por favor, digite a placa do veículo:");
                Console.WriteLine("exemplo: AAA-0A00\n");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) == false && validaPlaca.IsMatch(input))
                {
                    placa = input.ToUpper();
                    break;
                }
    
                Console.Clear();
                Console.WriteLine("Placa inválida!\n");
            }
        }

        public void AdicionarVeiculo()
        {
            string placa = "";
            Console.Clear();
            Console.WriteLine("Adicionar veículo ao cadastro:\n");
            ValidarPlaca(ref placa);
            Console.Clear();
            veiculos.Add(placa);
            Console.WriteLine($"Veículo adicionado com sucesso!\nPlaca: {placa}");
        }

        public void RemoverVeiculo()
        {
            string placa = "";

            if (veiculos.Any())
            {   
                Console.WriteLine("\nRemover veículo cadastrado:\n");
                ValidarPlaca(ref placa);

                // Verifica se o veículo existe
                if (veiculos.Any(x => x == placa))
                {
                    int horas = 0;
                    decimal valorTotal = 0;

                    while (true)
                    {
                        Console.WriteLine("\nDigite por quantas horas o veículo permaneceu estacionado: ");
                        if (int.TryParse(Console.ReadLine(), out horas))
                        {
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine("Por favor insira um tempo válido!");
                    }

                    valorTotal = precoInicial + precoPorHora * horas;

                    veiculos.Remove(placa);

                    if(horas < 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"O veículo {placa} foi removido com sucesso!\n\nCusto total sem hora adicional: {valorTotal.ToString("C")}");
                        Console.WriteLine("____________________________________________\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"O veículo {placa} foi removido com sucesso!\n\nCusto total por {horas} horas adicionais: {valorTotal.ToString("C")}");
                        Console.WriteLine("____________________________________________\n");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Desculpe, o veículo inserido não foi encontrado no sistema.\n\nConfira se a placa foi digitada corretamente");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            Console.WriteLine("Veículos no estacionamento:\n");

            if (veiculos.Any())
            {
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {veiculos[i]}");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ContadorVeiculos()
        {
            int quantidadeVeiculos = veiculos.Count;

            if(quantidadeVeiculos == 1)
            {
                Console.WriteLine($"\n{quantidadeVeiculos} veículo estacionado.");
            }
            else
            {
                Console.WriteLine($"\n{quantidadeVeiculos} veículos estacionados.");
            }
        }
    }
}
