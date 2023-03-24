using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Valcrest9000;

public class ConfigInterface : IDisposable
{
    private JObject Json { get; }

    public ConfigInterface()
    {
        Json = JObject.Parse(File.ReadAllText(LocalFileSystem.Config));
    }

    public string Prefix()
    {
        return Json["prefix"]!.Value<string>()!;
    }
    
    public void Flush()
    {
        Json.WriteTo(new JsonTextWriter(new StreamWriter(LocalFileSystem.Config)));
    }

    public void Dispose()
    {
        Flush();
    }
}