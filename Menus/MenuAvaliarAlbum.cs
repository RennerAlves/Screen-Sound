using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar um álbum");
        Console.Write("Insira o nome da banda que deseja avaliar: ");
        string banda = Console.ReadLine()!;

        if(bandasRegistradas.Keys.Contains(banda))
        {
            Console.Write("Qual álbum você deseja avaliar? ");
            string album = Console.ReadLine()!;

            if (bandasRegistradas[banda].Albuns.Any(a => a.Nome.Equals(album))) 
            {
                Console.WriteLine($"Qual a nota que o álbum {album} merece? ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);

                bandasRegistradas[banda].Albuns.First(a => a.Nome.Equals(album)).AdicionarNota(nota);

                Console.WriteLine($"A nota {nota.Nota} foi registrado com sucesso para o álbum {album}");
                Thread.Sleep( 2000 );
                Console.Clear();
            } else
            {
                Console.WriteLine($"O álbum {album} não existe para a banda {banda}");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}
