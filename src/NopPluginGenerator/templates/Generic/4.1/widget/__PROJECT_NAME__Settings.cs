using Nop.Core.Configuration;

namespace __NAMESPACE_PREFIX__.__PROJECT_NAME__
{
    public class __PROJECT_NAME__Settings : ISettings
    {
        public const string PluginName = "__PROJECT_NAME__";
        public static string PluginFolder = "__DESCRIPTION_SystemName__";
        public static string PluginPath = $"~/Plugins/{PluginFolder}";


        public enum WidgetZones
        {
            __WIDGET_ZONE__
        };

        public bool Display__PROJECT_NAME__Widget { get; set; }
    }
}