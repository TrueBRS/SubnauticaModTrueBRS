using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;

namespace WaterFiltrationPRO
{
	[Menu("WaterFiltrationPRO")]
	public class ModOptions : ConfigFile
	{
		[Toggle(Label = "Show seconds when hover", Tooltip = "Show the exact seconds instead of the percentage when looking at the Water Filtration machine."), OnChange(nameof(HoverSecToggleEvent))]
		public bool hoverSecEnable = true;

		[Toggle(Label = "Filtering Time Multiplier", Tooltip = "Enable the Filtering Time Multiplier."), OnChange(nameof(FilteringMultiplierToggleEvent))]
		public bool FilteringMultiplierEnable = false;

		[Toggle(Label = "Consume more enengy", Tooltip = "While enable, the filtering process will cost more enengy base on the Filtering Time Multiplier."), OnChange(nameof(FilteringMultiplierPowerToggleEvent))]
		public bool FilteringMultiplierPowerEnable = true;

		[Slider(Label = "Filtering Time Multiplier", Tooltip = "Decrease the time to filter by dividing by the Multiplier. The grater the Multiplier, the lesser the time to filter.\nChange will apply when the next batch starts.\nVanilla: 1", Format = "{0:F0}", Max = 5f, Min = 1f, DefaultValue = 1f, Step = 1F), OnChange(nameof(FilteringMultiplierChangedEvent))]
		public float FilteringMultiplierSliderValue;

		[Slider(Label = "Max water", Tooltip = "Set how many Large Filtered Water will be produced in the machine inventory before it stops. It will keep filtring until there are this many products in the inventory.\nNote: \n1. You need to use the Storage Size Mod to extend the inventory size first.\n2. You need to take out some product to apply the change.\nVanilla: 2", Format = "{0:F0}", Max = 10f, Min = 2f, DefaultValue = 2f, Step = 1F), OnChange(nameof(MaxWaterChangedEvent))]
		public float MaxWaterSliderValue;

		[Slider(Label = "Max Salt", Tooltip = "Set how many Salt will be produced in the machine inventory before it stops. It will keep filtring until there are this many products in the inventory.\nNote: \n1. You need to use the Storage Size Mod to extend the inventory size first.\n2. You need to take out some product to apply the change.\nVanilla: 2", Format = "{0:F0}", Max = 10f, Min = 2f, DefaultValue = 2f, Step = 1F), OnChange(nameof(MaxSaltChangedEvent))]
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
