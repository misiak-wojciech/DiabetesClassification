using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesClassification.Utils
{
    public static class DataAnalyzer
    {
        public static void CheckForZeroValues(MLContext mlContext, IDataView dataView)
        {
            var data = mlContext.Data.CreateEnumerable<DiabetesData>(dataView, reuseRowObject: false).ToList();

            var properties = typeof(DiabetesData).GetProperties();
            var lastPropertyIndex = properties.Length - 1;

            bool hasZeroValues = false;

            
            var columnsToCheck = new[] {
                nameof(DiabetesData.Glucose),
                nameof(DiabetesData.BloodPressure),
                nameof(DiabetesData.Insulin),
                nameof(DiabetesData.BMI),
                nameof(DiabetesData.Age)
            };

            foreach (var property in properties)
            {
                
                if (columnsToCheck.Contains(property.Name))
                {
                    int zeroCount = data.Count(row =>
                    {
                        if (property.GetValue(row) is float value)
                        {
                            return value == 0;
                        }
                        return false;
                    });

                    Console.WriteLine($"Number of zeros in the column '{property.Name}': {zeroCount}");

                    if (zeroCount > 0)
                    {
                        hasZeroValues = true;
                    }
                }
            }

            Console.WriteLine($"Are there zeros in the specified columns? {hasZeroValues}\n");
        }

    }
}
