using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;

namespace DeleteCookedFish
{
	[Menu("Delete_Cooked_Fish")]
	public class ModOptions : ConfigFile
	{
		[Toggle(Label = "Monitor & Add", Tooltip = "Monitor nearby cooked fish and add them to the delete list.\nNote: You need to get near the cooked fish for them to render in."), OnChange(nameof(masterToggleEvent))]
		public bool masterEnable = false;
		private void masterToggleEvent(ToggleChangedEventArgs e)
		{
			bool booleanValue = e.Value;
		}

		[Toggle(Label = "Auto delete", Tooltip = "Warning: Will auto delete the cooked fish from the fabricator and the thermoblade if you not picking it up quick!\nDelete the cooked fish in the delete list automatically after the delay."), OnChange(nameof(masterToggleEvent))]
		public bool autoDeleteEnable = false;
		private void autoDeleteEvent(ToggleChangedEventArgs e)
		{
			bool booleanValue = e.Value;
		}

		[Slider(Label = "Auto delete delay", Tooltip = "The delay before each auto delete.", Format = "{0:F0}", Max = 30f, Min = 1f, DefaultValue = 5f, Step = 1F), OnChange(nameof(AutoDeleteDelayChangedEvent))]
		public float AutoDeleteDelay = 5f;
		private void AutoDeleteDelayChangedEvent(SliderChangedEventArgs e)
		{
			float floatValue = e.Value;
		}

		[Button(Label = "Delete", Tooltip = "Delete all cooked fish in the delete list.")]
		public void MyButtonClickEvent(ButtonClickedEventArgs e)
		{
			Main.Clean();
		}
	}
}