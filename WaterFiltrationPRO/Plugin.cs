using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
using System.Reflection;

namespace WaterFiltrationPRO
{
	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	[BepInDependency("com.snmodding.nautilus")]
	public class Plugin : BaseUnityPlugin
	{
		public new static ManualLogSource Logger { get; private set; }

		private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

		// declare static ModOptions for use elsewhere
		public static ModOptions ModOptions;

		private void Awake()
		{
			LanguageHandler.RegisterLocalizationFolder();

			// Set up Mod Options
			ModOptions = OptionsPanelHandler.RegisterModOptions<ModOptions>();


			// set project-scoped logger instance
			Logger = base.Logger;

			// register harmony patches, if there are any
			Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
			Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
		}
	}
}