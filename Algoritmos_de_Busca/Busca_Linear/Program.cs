namespace Busca_Linear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementação de Algoritmos de Busca Linear!");

            var lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var valorBuscado = 8;

            BuscaLinear(lista, valorBuscado);
            Console.WriteLine($"Elemento encontrado no indice {BuscaLinear(lista, valorBuscado)}, com lista de tamanho {lista.Count}");

        }

        private static int? BuscaLinear(List<int> lista, int valorBuscado)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] == valorBuscado)
                    return i;
            }
            return null;
        }
    }
}
