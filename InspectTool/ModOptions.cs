using Nautilus.Json;
using Nautilus.Options;
using Nautilus.Options.Attributes;
using UnityEngine;

namespace InspectTool
{
	[Menu("InspectTool")]
	public class ModOptions : ConfigFile
	{
		[Keybind(LabelLanguageId = "masterKeybindLabel", TooltipLanguageId = "masterKeybindTT"), OnChange(nameof(masterKeybindValueChangedEvent))]
		public KeyCode masterKeybindKey = KeyCode.I;

		private void masterKeybindValueChangedEvent(KeybindChangedEventArgs e)
		{
			KeyCode keyCode = e.Value;
		}
	}
}
