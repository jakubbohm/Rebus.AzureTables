using System;
using System.Text.Json;
using Rebus.Sagas;

namespace Rebus.AzureTables.Sagas.Serialization;
public class SystemTextJsonSagaSerializer : ISagaSerializer {
  private readonly JsonSerializerOptions _jsonSerializerOptions;

  public SystemTextJsonSagaSerializer(JsonSerializerOptions jsonSerializerOptions = null) => _jsonSerializerOptions = jsonSerializerOptions;

  public string SerializeToString(ISagaData obj) => JsonSerializer.Serialize(obj, obj.GetType(), _jsonSerializerOptions);

  public ISagaData DeserializeFromString(Type type, string str) {
    var data = JsonSerializer.Deserialize(str, type, _jsonSerializerOptions) as ISagaData;
    return type.IsInstanceOfType(data) ? data : null;
  }
}
