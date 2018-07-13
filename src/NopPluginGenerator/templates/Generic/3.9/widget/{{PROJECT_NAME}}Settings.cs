using Nop.Core.Configuration;

namespace {{NAMESPACE_PREFIX}}.{{PROJECT_NAME}}
{
    public class {{PROJECT_NAME}}Settings : ISettings
    {
        public const string PluginPath = "~/Plugins/Widgets.{{PROJECT_NAME}}";

        public enum WidgetZones
        {
            {{WIDGET_ZONE}}
        };

        public bool Display{{PROJECT_NAME}}Widget { get; set; }
    }
}
