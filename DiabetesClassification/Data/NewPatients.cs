public class NewPatients
{
    public static List<DiabetesData> GetNewPatients()
    {
        return new List<DiabetesData>
        {
          
            new DiabetesData { Pregnancies = 1, Glucose = 130, BloodPressure = 72, SkinThickness = 35, Insulin = 0, BMI = 27.5f, DiabetesPedigreeFunction = 0.5f, Age = 45, Label = true },

            new DiabetesData { Pregnancies = 2, Glucose = 85, BloodPressure = 66, SkinThickness = 30, Insulin = 0, BMI = 24.3f, DiabetesPedigreeFunction = 0.3f, Age = 34,  Label = false },

            new DiabetesData { Pregnancies = 3, Glucose = 175, BloodPressure = 78, SkinThickness = 40, Insulin = 120, BMI = 29.0f, DiabetesPedigreeFunction = 0.7f, Age = 58,  Label = true },

            new DiabetesData { Pregnancies = 4, Glucose = 120, BloodPressure = 75, SkinThickness = 36, Insulin = 80, BMI = 30.1f, DiabetesPedigreeFunction = 0.6f, Age = 50,  Label= false },

            new DiabetesData { Pregnancies = 3, Glucose = 90, BloodPressure = 68, SkinThickness = 32, Insulin = 110, BMI = 23.0f, DiabetesPedigreeFunction = 0.4f, Age = 28,  Label = false },
      
            new DiabetesData { Pregnancies = 2, Glucose = 200, BloodPressure = 80, SkinThickness = 38, Insulin = 130, BMI = 35.5f, DiabetesPedigreeFunction = 0.9f, Age = 60,  Label = true },

            new DiabetesData { Pregnancies = 1, Glucose = 160, BloodPressure = 78, SkinThickness = 42, Insulin = 115, BMI = 27.0f, DiabetesPedigreeFunction = 0.8f, Age = 40,  Label = true },

            new DiabetesData { Pregnancies = 2, Glucose = 110, BloodPressure = 70, SkinThickness = 34, Insulin = 85, BMI = 28.2f, DiabetesPedigreeFunction = 0.5f, Age = 55,  Label = false },

            new DiabetesData { Pregnancies = 4, Glucose = 140, BloodPressure = 74, SkinThickness = 39, Insulin = 95, BMI = 32.1f, DiabetesPedigreeFunction = 0.6f, Age = 48,  Label = true },

            new DiabetesData { Pregnancies = 0, Glucose = 95, BloodPressure = 65, SkinThickness = 33, Insulin = 100, BMI = 22.5f, DiabetesPedigreeFunction = 0.4f, Age = 30,  Label = false }
        };
    }
}
