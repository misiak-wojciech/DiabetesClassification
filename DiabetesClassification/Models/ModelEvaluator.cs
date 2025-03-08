using Microsoft.ML;

public class ModelEvaluator
{
    public void Evaluate(MLContext mlContext, ITransformer model, IDataView testData)
    {
        var predictions = model.Transform(testData);
        var metrics = mlContext.BinaryClassification.Evaluate(predictions);
        var cm = metrics.ConfusionMatrix;

        Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
        Console.WriteLine($"F1-score: {metrics.F1Score:P2}");
        Console.WriteLine($"Recall: {metrics.PositiveRecall:P2}");
        Console.WriteLine($"Precision: {metrics.PositivePrecision:P2}");


        Console.WriteLine("\nConfusionMatrix");
        Console.WriteLine(cm.GetFormattedConfusionTable());
    }
}
