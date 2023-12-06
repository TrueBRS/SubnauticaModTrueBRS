using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;

namespace VoiceNotificationInterval
{
	[Menu("Voice Notification Interval")]
	public class ModOptions : ConfigFile
	{
		[Toggle(LabelLanguageId = "masterEnableLabel", TooltipLanguageId = "masterEnableTT"), OnChange(nameof(MasterEnableToggleEvent))]
		public bool masterEnable = false;
		private void MasterEnableToggleEvent(ToggleChangedEventArgs e)
		{
			bool booleanValue = e.Value;
		}

		[Slider(LabelLanguageId = "minIntervalLabel", TooltipLanguageId = "minIntervalTT", Format = "{0:F0}", Min = 1f, Max = 60f, DefaultValue = 15f, Step = 1F), OnChange(nameof(minIntervalChangedEvent))]
		public float minInterval = 21f;
		private void minIntervalChangedEvent(SliderChangedEventArgs e)
		{
			float floatValue = e.Value;
		}
	}
}