using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;

namespace FastConstruction
{
	[Menu("FastConstruction")]
	public class ModOptions : ConfigFile
	{
		[Toggle(Label = "Progressive", Tooltip = "*Disable = \"Linear\": The building speed is the time per used item. if you set it to 1 and the current building requires 2 resources, the building time will be 2, except if you set a lower maximum time or a higher minimum time.\n\n*Enable = \"Progressive\": The added time per used resource decreases the more resources are used. It uses the Logistic Function﻿. The maximum is the converging value. The minimum is the lowest value."), OnChange(nameof(ProgressiveToggleEvent))]
		public bool progressiveEnable = false;
		private void ProgressiveToggleEvent(ToggleChangedEventArgs e)
		{
			bool booleanValue = e.Value;
		}

		[Slider(Label = "Building Speed", Tooltip = "When the progressive mode is selected, this value is the \"growth rate\". Otherwise it is the time per used resource.", Format = "{0:F1}", Min = 0.1f, Max = 2f, DefaultValue = 1f, Step = 0.1F), OnChange(nameof(BuildingSpeedChangedEvent))]
		public float buildingSpeed = 1f;
		private void BuildingSpeedChangedEvent(SliderChangedEventArgs e)
		{
			float floatValue = e.Value;
		}

		[Slider(Label = "Maximum Build Time", Tooltip = "The total construction time will never surpass this value.", Format = "{0:F1}", Min = 0.1f, Max = 10f, DefaultValue = 10f, Step = 0.1F), OnChange(nameof(maximumBuildTimeChangedEvent))]
		public float maximumBuildTime = 10f;
		private void maximumBuildTimeChangedEvent(SliderChangedEventArgs e)
		{
			float floatValue = e.Value;
		}

		[Slider(Label = "Minimum Build Time", Tooltip = "The construction time will never fall below this value.", Format = "{0:F1}", Min = 0.1f, Max = 10f, DefaultValue = 1f, Step = 0.1F), OnChange(nameof(minimumBuildTimeChangedEvent))]
		public float minimumBuildTime = 1f;
		private void minimumBuildTimeChangedEvent(SliderChangedEventArgs e)
		{
			float floatValue = e.Value;
		}
	}
}