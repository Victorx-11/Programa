using System.Text.RegularExpressions;

string mensagemDeBoasVindas = "Boas vindas aos arsenal Targaryen";
//List<string> ListaDeDragoes = new List<string> {"Meleys", "caraxes", "Vermithor"};

Dictionary<string, List <int>> dragoesRegistrados = new Dictionary<string, List <int>>();
dragoesRegistrados.Add("Meleys", new List<int> { 10,9,7});
dragoesRegistrados.Add("Sunfire", new List<int> { 8,9,3});
void ExibirLogo()
{
    Console.WriteLine(@"

████████╗ █████╗ ██████╗  ██████╗  █████╗ ██████╗ ██╗   ██╗███████╗███╗  ██╗
╚══██╔══╝██╔══██╗██╔══██╗██╔════╝ ██╔══██╗██╔══██╗╚██╗ ██╔╝██╔════╝████╗ ██║
   ██║   ███████║██████╔╝██║  ██╗ ███████║██████╔╝ ╚████╔╝ █████╗  ██╔██╗██║
   ██║   ██╔══██║██╔══██╗██║  ╚██╗██╔══██║██╔══██╗  ╚██╔╝  ██╔══╝  ██║╚████║
   ██║   ██║  ██║██║  ██║╚██████╔╝██║  ██║██║  ██║   ██║   ███████╗██║ ╚███║
   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚══╝

██████╗ ██████╗  █████╗  ██████╗  █████╗ ███╗  ██╗ ██████╗
██╔══██╗██╔══██╗██╔══██╗██╔════╝ ██╔══██╗████╗ ██║██╔════╝
██║  ██║██████╔╝███████║██║  ██╗ ██║  ██║██╔██╗██║╚█████╗
██║  ██║██╔══██╗██╔══██║██║  ╚██╗██║  ██║██║╚████║ ╚═══██╗
██████╔╝██║  ██║██║  ██║╚██████╔╝╚█████╔╝██║ ╚███║██████╔╝
╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝  ╚════╝ ╚═╝  ╚══╝╚═════╝
");//verbatim literal
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um dragão");
    Console.WriteLine("Digite 2 para mostrar todas os dragões");
    Console.WriteLine("Digite 3 para avaliar um dragão");
    Console.WriteLine("Digite 4 para exibir a média de um dragão");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!; //! não volta nulo
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida); //parse converte texto em int

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarDragao();
            break;
        case 2: MostrarDragoesRegistrados();
            break;
        case 3: AvaliarUmDragao();
            break;
        case 4: MediaDragao();
            break;
        case -1: Console.WriteLine("Valar Dohaeris");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    };
};

void RegistrarDragao()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro dos dragões");
    Console.Write("Digite o nome do dragão que deseja registrar: ");
    string nomeDoDragao = Console.ReadLine()!;
    dragoesRegistrados.Add(nomeDoDragao,new List<int>());
    Console.WriteLine($"\nO dragão {nomeDoDragao} foi registrado com sucesso");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
};

void MostrarDragoesRegistrados()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todos os dragões registrados");
    foreach(string dragao in dragoesRegistrados.Keys)
    {
        Console.WriteLine($"Dragão: {dragao}");
    }

    Console.WriteLine("\nAperte qualquer tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras,'*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmDragao()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar dragão");
    Console.Write("Digite o nome do dragão que deseja avaliar: ");
    string nomeDoDragao = Console.ReadLine()!;
    if (dragoesRegistrados.ContainsKey(nomeDoDragao))
    {
        Console.Write($"\nQual a nota que o {nomeDoDragao} merece: ");
        int nota = int.Parse(Console.ReadLine()!); //Parse converte o console
        dragoesRegistrados[nomeDoDragao].Add(nota);
        Console.WriteLine($"\nA {nota} foi registrada com sucesso para o dragão {nomeDoDragao}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }else
    {
        Console.WriteLine($"\nO dragão {nomeDoDragao} não foi encontrado");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void MediaDragao()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média do Dragão");
    Console.Write("Digite o nome do dragão que deseja exibir a média: ");
    string nomeDoDragao = Console.ReadLine()!;
    if (dragoesRegistrados.ContainsKey(nomeDoDragao))
    {
        List<int> notasDoDragao = dragoesRegistrados[nomeDoDragao];
        Console.WriteLine($"\nA média de {nomeDoDragao} é {notasDoDragao.Average()}.");
        Console.WriteLine("Digite uma tecla para votar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"\nO dragão {nomeDoDragao} não foi encontrado!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}


ExibirOpcoesDoMenu();