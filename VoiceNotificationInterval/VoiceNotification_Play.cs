using HarmonyLib;
using System;

namespace VoiceNotificationInterval
{
	[HarmonyPatch(typeof(VoiceNotification), nameof(VoiceNotification.Play), new Type[] { typeof(object[]) })]
	internal class VoiceNotification_Play
	{
		[HarmonyPostfix]
		private static void Postfix(VoiceNotification __instance)
		{
			try
			{
				if (Plugin.ModOptions.masterEnable)
				{
					__instance.timeNextPlay = DayNightCycle.main.timePassedAsFloat + Plugin.ModOptions.minInterval;
					//Plugin.Logger.LogInfo($"DayNightCycle.main.timePassedAsFloat = {DayNightCycle.main.timePassedAsFloat}; __instance.timeNextPlay = {__instance.timeNextPlay}");
				}
			}
			catch (Exception ex)
			{
				Plugin.Logger.LogError($"An error occurred: {ex}");
			}
		}
	}
}
