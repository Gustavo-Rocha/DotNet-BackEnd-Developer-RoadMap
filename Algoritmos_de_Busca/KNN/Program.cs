namespace KNN;

internal class Program
{
    static void Main(string[] args)
    {
        var knn = new K_NN(5);

        // Treinamento
        knn.TreinoDoAlgoritomo(1.0 ,"A");
        knn.TreinoDoAlgoritomo(2.0, "A");
        knn.TreinoDoAlgoritomo(3.0, "B");
        knn.TreinoDoAlgoritomo(5.0, "B");
        knn.TreinoDoAlgoritomo(6.0, "B");

        // Predição de uma nova amostra
        string result = knn.Previsao(2.5);

        Console.WriteLine($"Classe prevista: {result}");
    }
}
class K_NN
{
    private int k;
    private List<(double, string)> data;

    public K_NN(int k)
    {
        this.k = k;
        this.data = new List<(double, string)>();
    }

    public void TreinoDoAlgoritomo(double features, string label)
    {
        data.Add((features, label));
    }

    public string Previsao(double newPoint)
    {
        var distances = data.Select(entry =>
            (Distancia(entry.Item1, newPoint), entry.Item2))
            .OrderBy(entry => entry.Item1)
            .Take(k);

        return distances.GroupBy(entry => entry.Item2)
                        .OrderByDescending(group => group.Count())
                        .First().Key;
    }

    private double Distancia(double vizinhos, double novaAmostragem)
    {
        var somadasDIferencas = Math.Pow((vizinhos - novaAmostragem), 2);
        return Math.Sqrt(somadasDIferencas);
    }

    ////class Program
    ////{
    ////    static void Main()
    ////    {
    ////        KNN knn = new KNN(3);

    ////        // Treinamento
    ////        knn.Train(new double[] { 1.0, 2.0 }, "A");
    ////        knn.Train(new double[] { 2.0, 3.0 }, "A");
    ////        knn.Train(new double[] { 3.0, 3.0 }, "B");
    ////        knn.Train(new double[] { 5.0, 5.0 }, "B");

    ////        // Predição de uma nova amostra
    ////        string result = knn.Predict(new double[] { 2.5, 2.5 });

    ////        Console.WriteLine($"Classe prevista: {result}");
    ////    }
    ////}

    ////class KNN
    ////{
    ////    private int k;
    ////    private List<(double[], string)> data;

    ////    public KNN(int k)
    ////    {
    ////        this.k = k;
    ////        this.data = new List<(double[], string)>();
    ////    }

    ////    public void Train(double[] features, string label)
    ////    {
    ////        data.Add((features, label));
    ////    }

    ////    public string Predict(double[] newPoint)
    ////    {
    ////        var distances = data.Select(entry =>
    ////            (Distance(entry.Item1, newPoint), entry.Item2))
    ////            .OrderBy(entry => entry.Item1)
    ////            .Take(k);

    ////        return distances.GroupBy(entry => entry.Item2)
    ////                        .OrderByDescending(group => group.Count())
    ////                        .First().Key;
    ////    }

    ////    private double Distance(double[] p1, double[] p2)
    ////    {
    ////        return Math.Sqrt(p1.Zip(p2, (x, y) => Math.Pow(x - y, 2)).Sum());
    ////    }
    ////}

}
