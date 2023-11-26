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
	}
}