using BepInEx;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UWE;

namespace DeleteCookedFish
{
	[HarmonyPatch(typeof(EcoTarget), "OnEnable")]
	[BepInPlugin("GUID", "Name", "1.0")]
	class EcoTarget_OnEnable_patch : BaseUnityPlugin
	{
		public static HashSet<Pickupable> cookedFish = new HashSet<Pickupable>();

		public static void Postfix(EcoTarget __instance)
		{
			if (Plugin.ModOptions.masterEnable && __instance.type == EcoTargetType.DeadMeat)
			{
				Pickupable p = __instance.GetComponent<Pickupable>();
				if (p)
				{
					cookedFish.Add(p);
					Plugin.Logger.LogInfo($"There are {cookedFish.Count} cooked fish.");

					// auto delete: Start waiting coroutine
					if (Plugin.ModOptions.autoDeleteEnable)
					{
						CoroutineHost.StartCoroutine(DestroyAfterDelay(p, Plugin.ModOptions.AutoDeleteDelay));
					}
				}
			}
		}

		private static IEnumerator DestroyAfterDelay(Pickupable p, float delay)
		{
			yield return new WaitForSeconds(delay);

			try
			{

				if (p != null && p.inventoryItem == null)
				{
					Destroy(p.gameObject);
					Plugin.Logger.LogInfo($"{p.gameObject} destroyed.");
				}
				cookedFish.Remove(p);
			}
			catch (System.Exception ex)
			{
				Plugin.Logger.LogError($"[DestroyAfterDelay] Exception occurred: {ex}");
			}
		}
	}
}
