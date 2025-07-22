using Newtonsoft.Json;

namespace Shared.Json;

public static class Json
{
    public static string Serialize(Object json)
    {
        var response = JsonConvert.SerializeObject(json);
        return response;
    }

    public static T? Deserialize<T>(string json)
    {
        var response = JsonConvert.DeserializeObject<T>(json);
        return response;
    }
}