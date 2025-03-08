using Microsoft.ML.Data;

public class DiabetesData
{
    [LoadColumn(0)] public float Pregnancies { get; set; }
    [LoadColumn(1)] public float Glucose { get; set; }
    [LoadColumn(2)] public float BloodPressure { get; set; }
    [LoadColumn(3)] public float SkinThickness { get; set; }
    [LoadColumn(4)] public float Insulin { get; set; }
    [LoadColumn(5)] public float BMI { get; set; }
    [LoadColumn(6)] public float DiabetesPedigreeFunction { get; set; }
    [LoadColumn(7)] public float Age { get; set; }
    [LoadColumn(8)] public bool Label { get; set; } 
}

