using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.Clear();
Console.WriteLine("\nSeja bem vindo ao sistema\n" +
                  "\nde estacionamento digital");
Console.WriteLine("_________________________\n");

//Verifica se o input de precoInicial é válido e converte para decimal
while(true)
{
    Console.WriteLine("Digite o preço inicial:");
    string input = Console.ReadLine();
    if (string.IsNullOrEmpty(input) == false)
    {
        precoInicial = Convert.ToDecimal(input);
        break;
    }
    Console.Clear();
    Console.WriteLine("Valor inválido! Por favor insira um valor válido.\n");
}

//Verifica se o input de precoPorHora é válido e converte para decimal
while(true)
{
    Console.WriteLine("\nDigite o preço por hora adicional:");
    string input = Console.ReadLine();
    if (string.IsNullOrEmpty(input) == false)
    {
        precoPorHora = Convert.ToDecimal(input);
        break;
    }
    Console.Clear();
    Console.WriteLine("Valor inválido! Por favor insira um valor válido.\n");
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine($"Preço inicial = {precoInicial.ToString("C")} \nPreço por hora adicional = {precoPorHora.ToString("C")}");
    es.ContadorVeiculos();
    Console.WriteLine("__________________________________\n");
    Console.WriteLine("Digite a sua opção:\n");
    Console.WriteLine("1) - Cadastrar veículo.");
    Console.WriteLine("2) - Remover veículo.");
    Console.WriteLine("3) - Listar veículos.");
    Console.WriteLine("4) - Encerrar programa.\n");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.ListarVeiculos();
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            Console.Clear();
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar:");
    Console.ReadLine();
}

Console.Clear();
Console.WriteLine("Volte Sempre!\n\nObrigado pela preferência!\n");
