using System.IO;
using System.Reflection;
using EdBoxPremium.Data.InterchangeModels;

namespace EdBoxPremium.Local.Engines
{
    public class DeviceManager
    {
        private static DeviceSpec _deviceSpec;

        public static DeviceSpec DeviceSpec
        {
            get
            {
                if (_deviceSpec != null)
                    return _deviceSpec;

                var outputFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                var updateSpecFileLocation = Path.Combine(outputFolder, "LocalData\\DeviceSpec.json");
                _deviceSpec =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceSpec>(File.ReadAllText(updateSpecFileLocation));

                return _deviceSpec;
            }
            set
            {
                var outputFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                var updateSpecFileLocation = Path.Combine(outputFolder, "LocalData\\DeviceSpec.json");
                File.WriteAllText(updateSpecFileLocation, Newtonsoft.Json.JsonConvert.SerializeObject(value));
            }
        }
    }
}
