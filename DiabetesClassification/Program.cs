using Microsoft.ML;
using DiabetesClassification.Utils;
using System.Data;
namespace DiabetesClassification
{
    class Program
    {
        static void Main()
        {
            var mlContext = new MLContext(seed: 0);
            var dataLoader = new CsvDataLoader();
            var modelTrainer = new ModelTrainer();
            var modelEvaluator = new ModelEvaluator();



            var dataView = dataLoader.LoadData(mlContext, @"..\..\..\diabetes.csv");

            var preview = dataView.Preview(maxRows: 5);

            foreach (var row in preview.RowView)
            {
                foreach (var column in row.Values)
                {
                    Console.Write($"{column.Key}: {column.Value}\n");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            long rowCount = dataView.GetRowCount() ?? dataView.Preview(1000).RowView.Length;
            Console.WriteLine($"Number of observations: {rowCount}\n");

            DataAnalyzer.CheckForZeroValues(mlContext, dataView);


            var dataWithImputation = DataPreprocessor.ImputeZeroValuesWithMedian(mlContext, dataView);

            DataAnalyzer.CheckForZeroValues(mlContext, dataWithImputation);

            var split = mlContext.Data.TrainTestSplit(dataWithImputation, testFraction: 0.2);
            var trainData = split.TrainSet;
            var testData = split.TestSet;


            var model = modelTrainer.TrainModel(mlContext, trainData);

            modelEvaluator.Evaluate(mlContext, model, testData);

            var predictor = new Predictor(mlContext, model);
            var newPatients = NewPatients.GetNewPatients();

           
            foreach (var patient in newPatients)
            {
                var prediction = predictor.Predict(patient);

                Console.WriteLine($"Prediction: {(prediction.PredictedOutcome ? "Diabetic." : "Non-diabetic.")}");
                Console.WriteLine($"Probability: {prediction.Probability:P2}\n");
            }


        }
    }

}