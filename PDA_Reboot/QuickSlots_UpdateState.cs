namespace PDA_Reboot
{
	using HarmonyLib;
	using UnityEngine;

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

			Player.main.GetPDA().Open(PDATab.Intro, null, null);
			//Player.main.playerAnimator.SetBool("using_tool_first", true);
			//Player.main.armsController.SetUsingPda(true);
		}
	}
}