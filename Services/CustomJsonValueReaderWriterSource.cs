using System.Text.Json;

namespace be_adminsisters.Services;

public abstract class CustomJsonValueReaderWriterSource : IJsonValueReaderWriterSource
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = false
    };

    public object GetReader(Type type)
    {
        return new CustomJsonReader(JsonOptions);
    }

    public object GetWriter(Type type)
    {
        return new CustomJsonWriter(JsonOptions);
    }
}

public class CustomJsonReader(JsonSerializerOptions options)
{
    public T Read<T>(string json) => JsonSerializer.Deserialize<T>(json, options)!;
}

public class CustomJsonWriter(JsonSerializerOptions options)
{
    public string Write<T>(T value) => JsonSerializer.Serialize(value, options);
}

public interface IJsonValueReaderWriterSource
{
    object GetReader(Type type);

    object GetWriter(Type type);
}