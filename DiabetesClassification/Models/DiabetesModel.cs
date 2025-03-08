using Microsoft.ML.Data;

public class DiabetesPrediction
{
    [ColumnName("PredictedLabel")] public bool PredictedOutcome { get; set; }
    public float Probability { get; set; }
}
