using Microsoft.ML;

public class ModelTrainer
{
    public ITransformer TrainModel(MLContext mlContext, IDataView trainData)
    {
        var pipeline = mlContext.Transforms.Concatenate("Features",
                nameof(DiabetesData.Pregnancies),
                nameof(DiabetesData.Glucose),
                nameof(DiabetesData.BloodPressure),
                nameof(DiabetesData.SkinThickness),
                nameof(DiabetesData.Insulin),
                nameof(DiabetesData.BMI),
                nameof(DiabetesData.DiabetesPedigreeFunction),
                nameof(DiabetesData.Age))
            .Append(mlContext.Transforms.NormalizeMeanVariance("Features", "Features"))
            .Append(mlContext.BinaryClassification.Trainers.FastTree());

        return pipeline.Fit(trainData);
    }
}
