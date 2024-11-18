namespace Fire_Emblem_Controller;
using System.Text.Json;
using System.Text.Json.Serialization;

public class StringToIntConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var stringValue = reader.GetString();
            if (int.TryParse(stringValue, out int value))
            {
                return value;
            }
            throw new JsonException($"Unable to convert \"{stringValue}\" to integer.");
        }
        return reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}