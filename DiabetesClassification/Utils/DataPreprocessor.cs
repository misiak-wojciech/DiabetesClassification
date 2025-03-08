using Microsoft.ML.Transforms;
using Microsoft.ML;

namespace DiabetesClassification.Utils
{

    public static class DataPreprocessor
    {
        public static IDataView ImputeZeroValuesWithMedian(MLContext mlContext, IDataView dataView)
    {
            var data = mlContext.Data.CreateEnumerable<DiabetesData>(dataView, reuseRowObject: false).ToList();
            var properties = typeof(DiabetesData).GetProperties();

    
            var columnsToImpute = new[] {
                nameof(DiabetesData.Glucose),
                nameof(DiabetesData.BloodPressure),
                nameof(DiabetesData.Insulin),
                nameof(DiabetesData.BMI),
                nameof(DiabetesData.Age)
            };

            foreach (var property in properties)
            {
        
                if (columnsToImpute.Contains(property.Name))
                {
                    var nonZeroValues = data.Where(row => (float)property.GetValue(row) != 0)
                                             .Select(row => (float)property.GetValue(row))
                                             .ToList();

                    if (nonZeroValues.Any())
                    {
                
                        var sortedValues = nonZeroValues.OrderBy(x => x).ToList();
                        float median;
                        int count = sortedValues.Count;
                
                        if (count % 2 == 0)  
                        {
                            median = (sortedValues[count / 2 - 1] + sortedValues[count / 2]) / 2;
                        }
                        else  
                        {
                            median = sortedValues[count / 2];
                        }

                
                        foreach (var row in data)
                        {
                            if ((float)property.GetValue(row) == 0)
                            {
                                property.SetValue(row, median); 
                            }
                        }
                    }
                }
            }

            return mlContext.Data.LoadFromEnumerable(data);
        }







    }
}
