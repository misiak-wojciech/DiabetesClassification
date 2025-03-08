using Microsoft.ML;

public interface IDataLoader
{
    IDataView LoadData(MLContext mlContext, string filePath);
}
