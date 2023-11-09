using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;

namespace WaterFiltrationPRO
{
	[Menu("WaterFiltrationPRO")]
	public class ModOptions : ConfigFile
	{
		[Toggle(LabelLanguageId = "hoverSecToggleLabel", TooltipLanguageId = "hoverSecToggleTT"), OnChange(nameof(HoverSecToggleEvent))]
		public bool hoverSecEnable = true;

		[Toggle(LabelLanguageId = "FilteringMultiplierToggleLabel", TooltipLanguageId = "FilteringMultiplierToggleTT"), OnChange(nameof(FilteringMultiplierToggleEvent))]
		public bool FilteringMultiplierEnable = false;

		[Toggle(LabelLanguageId = "FilteringMultiplierPowerToggleLabel", TooltipLanguageId = "FilteringMultiplierPowerToggleTT"), OnChange(nameof(FilteringMultiplierPowerToggleEvent))]
		public bool FilteringMultiplierPowerEnable = true;

		[Slider(LabelLanguageId = "FilteringMultiplierSliderLabel", TooltipLanguageId = "FilteringMultiplierSliderTT", Format = "{0:F0}", Max = 5f, Min = 1f, DefaultValue = 1f, Step = 1F), OnChange(nameof(FilteringMultiplierChangedEvent))]
		public float FilteringMultiplierSliderValue;

		[Slider(LabelLanguageId = "MaxWaterSliderLabel", TooltipLanguageId = "MaxWaterSliderTT", Format = "{0:F0}", Max = 10f, Min = 2f, DefaultValue = 2f, Step = 1F), OnChange(nameof(MaxWaterChangedEvent))]
		public float MaxWaterSliderValue;

		[Slider(LabelLanguageId = "MaxSaltSliderLabel", TooltipLanguageId = "MaxSaltSliderTT", Format = "{0:F0}", Max = 10f, Min = 2f, DefaultValue = 2f, Step = 1F), OnChange(nameof(MaxSaltChangedEvent))]
		public float MaxSaltSliderValue;

		private void HoverSecToggleEvent(ToggleChangedEventArgs e)
		{
			bool booleanValue = e.Value;
		}

		private void FilteringMultiplierToggleEvent(ToggleChangedEventArgs e)
		{
			bool booleanValue = e.Value;
		}

		private void FilteringMultiplierChangedEvent(SliderChangedEventArgs e)
		{
			float floatValue = e.Value;
		}

		private void FilteringMultiplierPowerToggleEvent(ToggleChangedEventArgs e)
		{
			bool booleanValue = e.Value;
		}
		private void MaxWaterChangedEvent(SliderChangedEventArgs e)
		{
			float floatValue = e.Value;
		}
		private void MaxSaltChangedEvent(SliderChangedEventArgs e)
		{
			float floatValue = e.Value;
		}
	}
}
