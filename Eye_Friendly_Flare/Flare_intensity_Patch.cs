using HarmonyLib;
using UnityEngine;

namespace Eye_Friendly_Flare
{
	[HarmonyPatch(typeof(Flare))]
	[HarmonyPatch("UpdateLight")]
	internal class Flare_intensity_Patch
	{
		[HarmonyPostfix]
		public static void Postfix(Flare __instance)
		{
			float num = 2f;
			bool flag = __instance.energyLeft > 1790f;
			if (flag)
			{
				__instance.light.intensity = Mathf.Lerp(0.2f, num, (1790f - __instance.energyLeft + 10f) / 10f);
			}
			else
			{
				bool flag2 = __instance.energyLeft < 1000f;
				if (flag2)
				{
					__instance.light.intensity = Mathf.Lerp(1f, num, __instance.energyLeft / 1000f);
				}
				else
				{
					__instance.light.intensity = num;
				}
			}
		}
	}
}
