



namespace Arvore_Binaria_Busca;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Implementando Busca De Arvore binaria");
        var node = new Node(20);
        var arvore = new ArvoreBinaria();

        int[] valores = { 50, 30, 70, 20, 40, 60, 80 };

        foreach (var valor in valores)
            arvore.Inserir(valor);

        arvore.EmOrdem(arvore.Raiz);
        Console.WriteLine();
        Console.WriteLine($"Valor retornado da Arvore Binaria {arvore.BuscaArvoreBinaria(arvore.Raiz, 10)}"); 

    }

}

class ArvoreBinaria
{
    public Node? Raiz;

    public void Inserir(int valor)
    {
        Raiz = InserirRecursivo(Raiz, valor);
    }

    private Node InserirRecursivo(Node? nodo, int valor)
    {
        if (nodo == null)
            return new Node(valor);

        if (valor < nodo.Valor)
            nodo.Esquerda = InserirRecursivo(nodo.Esquerda, valor);
        else if (valor > nodo.Valor)
            nodo.Direita = InserirRecursivo(nodo.Direita, valor);

        return nodo;
    }

    public void EmOrdem(Node? nodo)
    {
        if (nodo != null)
        {
            EmOrdem(nodo.Esquerda);
            Console.Write(nodo.Valor + " ");
            EmOrdem(nodo.Direita);
        }
    }

    public int? BuscaArvoreBinaria(Node no, int valor)
    {
        if (no is null)
            return null;
        else
        {
            if (no.Valor == valor)
                return valor;
            else if (valor < no.Valor)
            {
                return BuscaArvoreBinaria(no.Esquerda, valor);
            }
            else if (valor > no.Valor)
            {
                return BuscaArvoreBinaria(no.Direita, valor);
            }
        }
        return null;
    }

    public Node Remover(Node Raiz, int valor)
    {
        if(Raiz == null)
            return null;
        
        else if (valor < Raiz.Valor)
        {
            Raiz.Esquerda = Remover(Raiz.Esquerda, valor);
        }
        else if (valor > Raiz.Valor)
        {
            Raiz.Direita = Remover(Raiz.Direita, valor);
        }
        else if (Raiz.Valor == valor)
        {
            if (Raiz.Esquerda is null && Raiz.Direita is null)
                return null;

            if(Raiz.Esquerda ==  null)
                return Raiz.Direita;
            if (Raiz.Direita == null)
                return Raiz.Esquerda;

            var menorValor = MenorValor(Raiz.Direita);
            Raiz.Valor = menorValor.Valor;
            Raiz.Direita = Remover(Raiz.Direita, menorValor.Valor);
        }
        return Raiz;
    }

    private Node MenorValor(Node direita)
    {
       while (direita.Esquerda != null)
            direita = direita.Esquerda;
        
        return direita;
    }
}

public class Node
{
    public int Valor;
    public Node Esquerda;
    public Node Direita;
    public Node(int item)
    {
        Valor = item;
        Esquerda = Direita = null;
    }
}
