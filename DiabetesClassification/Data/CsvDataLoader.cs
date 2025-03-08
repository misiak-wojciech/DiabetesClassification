using Microsoft.ML;

public class CsvDataLoader : IDataLoader
{
    public IDataView LoadData(MLContext mlContext, string filePath)
    {
        return mlContext.Data.LoadFromTextFile<DiabetesData>(
            filePath, separatorChar: ',', hasHeader: true);
    }
}
