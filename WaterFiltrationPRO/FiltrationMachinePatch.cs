using HarmonyLib;
using UnityEngine;

namespace WaterFiltrationPRO
{
	[HarmonyPatch(typeof(FiltrationMachine))]
	public class FiltrationMachinePatch
	{
		// Show the seconds when hovering
		[HarmonyPatch(nameof(FiltrationMachine.OnHover))]
		[HarmonyPostfix]
		public static void OnHoverPatch(FiltrationMachine __instance)
		{
			if (Plugin.ModOptions.hoverSecEnable)
			{
				// Basically vanilla conditions
				if (!(__instance.constructed < 1f) && !(GameModeUtils.RequiresPower() && __instance.powerRelay.GetPower() < 0.85f) && (__instance.timeRemainingWater >= 0f || __instance.timeRemainingSalt >= 0f))
				{
					string myText = Language.main.Get("water") + ": " + $"{Mathf.Ceil(__instance.timeRemainingWater)}" + Language.main.Get("s") + ", " + Language.main.Get("salt") + ": " + $"{Mathf.Ceil(__instance.timeRemainingSalt)}" + Language.main.Get("s");
					HandReticle.main.SetText(HandReticle.TextType.HandSubscript, myText, false, GameInput.Button.None);
				}
			}
		}

		// Consume more power based on FilteringScaleSliderValue, in total will consume vanilla + 0.85 * FilteringMultiplierSliderValue every second
		[HarmonyPatch(nameof(FiltrationMachine.UpdateFiltering))]
		[HarmonyPrefix]
		public static void UpdateFilteringPatch(FiltrationMachine __instance)
		{
			if (__instance._constructed < 1f)
			{
				return;
			}
			if (Plugin.ModOptions.FilteringMultiplierPowerEnable && Plugin.ModOptions.FilteringMultiplierEnable)
			{
				float num = 1f * DayNightCycle.main.dayNightSpeed;
				if ((__instance.timeRemainingWater > 0f || __instance.timeRemainingSalt > 0f) && (__instance.powerRelay != null && __instance.powerRelay.GetPower() >= 0.85f * num) && GameModeUtils.RequiresPower())
				{
					float num2;
					__instance.powerRelay.ConsumeEnergy((0.85f * Plugin.ModOptions.FilteringMultiplierSliderValue) * num, out num2);
				}
			}
		}

		// set the timeRemainingWater
		[HarmonyPatch(nameof(FiltrationMachine.TryFilterWater))]
		[HarmonyPrefix]
		public static void TryFilterWaterPatch(FiltrationMachine __instance)
		{
			if (__instance.timeRemainingWater > 0f)
			{
				return;
			}
			if (!__instance.IsUnderwater() && __instance.atmosphericWaterScalar == 0f)
			{
				return;
			}
			// This should takeover the vanilla code
			if (__instance.storageContainer.container.GetCount(TechType.BigFilteredWater) < (Plugin.ModOptions.MaxWaterSliderValue))
			{
				if (Plugin.ModOptions.FilteringMultiplierEnable)
				{
					__instance.timeRemainingWater = 840f / Plugin.ModOptions.FilteringMultiplierSliderValue;
				}
				else
				{
					__instance.timeRemainingWater = 840f;
				}
				return;
			}
		}

		// set the timeRemainingSalt
		[HarmonyPatch(nameof(FiltrationMachine.TryFilterSalt))]
		[HarmonyPrefix]
		public static void TryFilterSaltPatch(FiltrationMachine __instance)
		{
			if (__instance.timeRemainingSalt > 0f)
			{
				return;
			}
			if (!__instance.IsUnderwater() && __instance.atmosphericSaltScalar == 0f)
			{
				return;
			}
			if (__instance.storageContainer.container.GetCount(TechType.Salt) < Plugin.ModOptions.MaxSaltSliderValue)
			{
				if (Plugin.ModOptions.FilteringMultiplierEnable)
				{
					__instance.timeRemainingSalt = 420f / Plugin.ModOptions.FilteringMultiplierSliderValue;
				}
				else
				{
					__instance.timeRemainingSalt = 420f;
				}
				return;
			}
		}
	}
}