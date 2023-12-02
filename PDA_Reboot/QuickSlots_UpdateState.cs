using HarmonyLib;
using UnityEngine;

namespace PDA_Reboot
{

	[HarmonyPatch(typeof(QuickSlots), nameof(QuickSlots.UpdateState))]
	internal class QuickSlots_UpdateState
	{
		[HarmonyPrefix]
		private static void Prefix(QuickSlots __instance)
		{
			if (!Input.GetKeyDown(Plugin.ModOptions.masterKeybindKey) || GameOptions.GetVrAnimationMode() || (DevConsole.instance?.state ?? true) || uGUI_PDA.main.tabOpen != PDATab.None)
			{
				return;
			}

			if (Plugin.ModOptions.randomRebootEnable && (Random.value <= Plugin.ModOptions.randomRebootChance / 100f))
			{
				Player.main.GetPDA().Open(PDATab.Intro, null, null);
			}
			else if (!Plugin.ModOptions.randomRebootEnable)
			{
				Player.main.GetPDA().Open(PDATab.Intro, null, null);
			}
			else
			{
				//Player.main.GetPDA().Open(PDATab.Inventory, null, null);
				Player.main.GetPDA().Open();
			}
		}
	}
}