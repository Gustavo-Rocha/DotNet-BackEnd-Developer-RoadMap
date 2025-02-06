
namespace Busca_Binaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementação de Algoritmos de Busca Binária!");

            var lista = new List<int> { 10, 2, 3, 4, 5, 6, 7, 8, 9, 1 };

            var valorBuscado = 8;

            Console.WriteLine($"Elemento encontrado no indice {BuscaBinaria(lista, valorBuscado)}, com lista de tamanho {lista.Count}");
        }

        private static int? BuscaBinaria(List<int> lista, int valorBuscado)
        {
            lista = lista.Order().ToList();
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
}
