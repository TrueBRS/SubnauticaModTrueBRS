using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;
using UnityEngine;

namespace PDA_Reboot
{
	[Menu("PDA_Reboot")]
	public class ModOptions : ConfigFile
	{
		[Keybind(LabelLanguageId = "masterKeybindLabel", TooltipLanguageId = "masterKeybindTT"), OnChange(nameof(masterKeybindValueChangedEvent))]
		public KeyCode masterKeybindKey = KeyCode.P;

		private void masterKeybindValueChangedEvent(KeybindChangedEventArgs e)
		{
			KeyCode keyCode = e.Value;
		}

		[Toggle(Label = "Random Reboot", Tooltip = "If enabled, the PDA will play the reboot animation base on the Random Reboot %Chance or just open the inventory as normal after the button is pressed."), OnChange(nameof(RandomRebootToggleEvent))]
		public bool randomRebootEnable = false;
		private void RandomRebootToggleEvent(ToggleChangedEventArgs e)
		{
			bool booleanValue = e.Value;
		}

		[Slider(Label = "Random Reboot %Chance", Tooltip = "The %chance to reboot the PDA.", Format = "{0:F0}", Max = 100f, Min = 1f, DefaultValue = 5f, Step = 1F), OnChange(nameof(RandomRebootChanceChangedEvent))]
		public float randomRebootChance = 5f;
		private void RandomRebootChanceChangedEvent(SliderChangedEventArgs e)
		{
			float floatValue = e.Value;
		}
	}
}