using BepInEx;
using System.Collections.Generic;

namespace DeleteCookedFish
{
	[BepInPlugin("GUID", "Name", "1.0")]
	internal class Main : BaseUnityPlugin
	{
		private const string
			MODNAME = "DeleteCookedFish",
			GUID = "True_BRS.subnautica.DeleteCookedFish",
			VERSION = "1.0.0";
		public static void Clean()
		{
			var cleanCount = 0;
			foreach (Pickupable p in EcoTarget_OnEnable_patch.cookedFish)
			{
				if (p != null && p.inventoryItem == null)
				{
					Destroy(p.gameObject);
					cleanCount++;
				}
			}
			Plugin.Logger.LogInfo($"Destroyed {cleanCount} cooked fish.");
			EcoTarget_OnEnable_patch.cookedFish = new HashSet<Pickupable>();
		}
	}
}