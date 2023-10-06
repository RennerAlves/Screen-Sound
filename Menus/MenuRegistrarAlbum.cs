using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de álbuns");
        Console.Write("Digite a banda cujo álbum deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;
            Album album = new(tituloAlbum);
            bandasRegistradas[nomeDaBanda].AdicionarAlbum(album);
            Console.WriteLine($"O álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso!");
            Thread.Sleep(2000);
            Console.Clear();
            
        }
        else
        {
            Console.WriteLine("Banda não encontrada! Voltando ao menu principal.");
            Thread.Sleep(2000);
            Console.Clear();
           
        }
    }
}
