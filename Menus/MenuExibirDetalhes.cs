using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhes : Menu
{

    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Exibir detalhes da banda");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeDaBanda = Console.ReadLine()!;


        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"{bandasRegistradas[nomeDaBanda].Resumo}\n");
            double media = bandasRegistradas[nomeDaBanda].Media;
            Console.WriteLine($"\nA nota média da banda {nomeDaBanda} é {media}.");
            Console.WriteLine("\nDiscografia:");

            foreach (Album album in bandasRegistradas[nomeDaBanda].Albuns)
            {
                Console.WriteLine($"{album.Nome} - Média: {album.Media}");
            }

            Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
            Console.ReadKey();
            Console.Clear();


        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            
        }
    }
}
