namespace ScreenSound.Modelos;

internal class Avaliacao
{

    public int Nota{ get; }

    public Avaliacao(int nota)
    {
        if (nota > 10) Nota = 10;
        else if (nota < 0) Nota = 0;
        else Nota = nota;
    }

    public static Avaliacao Parse(string texto)
    {
        int nota = int.Parse(texto);
        return new Avaliacao(nota);
    }
}
