using HarmonyLib;
using UnityEngine;

namespace FastConstruction
{
	//internal static class Plugin.ModOptions
	//{
	//	//internal static float buildingSpeed = 1f;
	//	//internal static float maximumBuildTime = 6f;
	//	//internal static float minimumBuildTime = 2f;
	//	//internal static bool progressive = true;
	//}
	[HarmonyPatch(typeof(Constructable))]
	[HarmonyPatch(nameof(Constructable.GetConstructInterval))]
	internal class Constructable_GetConstructInterval_Patch
	{
		internal static int numberOfResources = 1;
		private static float calculateLogisticBuildingSpeed()
		{
			float buildDelta = Plugin.ModOptions.maximumBuildTime - Plugin.ModOptions.minimumBuildTime;
			float offset = buildDelta - Plugin.ModOptions.minimumBuildTime;
			return ((buildDelta * 2) / (1 + Mathf.Exp(-1 * Plugin.ModOptions.buildingSpeed * (numberOfResources - 1))) - offset);
		}
		static void Postfix(ref float __result)
		{
			if (__result == 1)
			{
				if (!Plugin.ModOptions.progressiveEnable)
				{
					float minimumBuildSpeed = Plugin.ModOptions.minimumBuildTime / numberOfResources;
					float maximumBuildSpeed = Plugin.ModOptions.maximumBuildTime / numberOfResources;
					__result = Mathf.Clamp(Plugin.ModOptions.buildingSpeed, minimumBuildSpeed, maximumBuildSpeed);
				}
				else
				{
					__result = Mathf.Max(calculateLogisticBuildingSpeed(), 0.1f) / numberOfResources;
				}
			}
		}
	}
	[HarmonyPatch(typeof(Constructable))]
	[HarmonyPatch(nameof(Constructable.Construct))]
	internal class Constructable_Construct_Patch
	{
		static void Prefix(Constructable __instance)
		{
			Constructable_GetConstructInterval_Patch.numberOfResources = __instance.resourceMap.Count;
		}
	}
	[HarmonyPatch(typeof(Constructable))]
	[HarmonyPatch(nameof(Constructable.DeconstructAsync))]
	internal class Constructable_Deconstruct_Patch
	{
		static void Prefix(Constructable __instance)
		{
			Constructable_GetConstructInterval_Patch.numberOfResources = __instance.resourceMap.Count;
		}
	}
}