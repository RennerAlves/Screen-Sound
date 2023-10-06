using ScreenSound.Modelos;
using OpenAI_API;
using System;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{

    public override void Executar(Dictionary<string, Banda> bandasRegistradas) 
    {

        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        var client = new OpenAIAPI("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");
        var chat = client.Chat.CreateConversation(); // Criamos uma conversa, retorna um objeto.
        chat.AppendSystemMessage($"Resuma a banda {bandasRegistradas[nomeDaBanda]} em um parágrafo."); //  Insira uma mensagem no chat, vai ser armazenada e usaremos um método para pegar a resposta.
        string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        // é uma função assíncrona, devemos usar o await para o c# esperar ele finalizar.

        banda.Resumo = resposta;

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        //Thread.Sleep(4000);
        Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
        Console.ReadKey();
        Console.Clear();

    }

}
