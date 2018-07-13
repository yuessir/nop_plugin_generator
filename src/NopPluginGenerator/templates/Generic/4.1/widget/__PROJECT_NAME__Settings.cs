using Nop.Core.Configuration;

namespace __NAMESPACE_PREFIX__.__PROJECT_NAME__
{
    public class __PROJECT_NAME__Settings : ISettings
    {
       public const string PluginPath = "~/Plugins/Widgets.__PROJECT_NAME__";

        public enum WidgetZones
        {
            __WIDGET_ZONE__
        };

        public bool Display__PROJECT_NAME__Widget { get; set; }
    }
}