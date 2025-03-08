using Microsoft.ML;

public class Predictor
{
    private readonly PredictionEngine<DiabetesData, DiabetesPrediction> _predictionEngine;

    public Predictor(MLContext mlContext, ITransformer model)
    {
        _predictionEngine = mlContext.Model.CreatePredictionEngine<DiabetesData, DiabetesPrediction>(model);
    }

    public DiabetesPrediction Predict(DiabetesData input)
    {
        return _predictionEngine.Predict(input);
    }
}
