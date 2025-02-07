using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.ComponentModel;

namespace Algoritmos_de_Busca;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Implementação de Algoritmos de Busca Linear!");


       // Console.WriteLine($"Elemento encontrado no indice {BuscaLinear(lista, valorBuscado)}, com lista de tamanho {lista.Count}");
        BenchmarkRunner.Run<Buscas>();
    }

    
}

public class Buscas
{
    private List<int> lista;
    private int valorBuscado = 1000;

    [GlobalSetup]
    public void Setup()
    {
        // Gera 100_000 números ordenados para teste
         lista = Enumerable.Range(1, 1000).ToList();
        
    }

    [Benchmark]
    public int? BuscaLinear()
    {
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i] == valorBuscado)
                return i;
        }
        return null;
    }

    [Benchmark]
    public  int? BuscaBinaria()
    {
        //lista = lista.Order().ToList();
        var IndiceInicioLista = 0;
        var indiceFimLista = lista.Count - 1;
        while (IndiceInicioLista <= indiceFimLista)
        {
            var indiceMeioLista = (IndiceInicioLista + indiceFimLista) / 2;

            if (lista[indiceMeioLista] == valorBuscado)
                return indiceMeioLista;

            if (lista[indiceMeioLista] < valorBuscado)
                IndiceInicioLista = indiceMeioLista + 1;
            else
                indiceFimLista = indiceMeioLista - 1;
        }
        return null;
    }
}
