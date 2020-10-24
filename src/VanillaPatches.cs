using Vintagestory.API.Common;
using HarmonyLib;
using Vintagestory.API.Server;
using System.Text;
using Vintagestory.API.Client;

namespace TpTools
{
    class VanillaPatches : ModSystem
    {
        public const string patchCode = "McJty.ModSystem.TpToolsVanillaPatches";
        public const string clientPatchCode = "McJty.ModSystem.TpToolsClientVanillaPatches";
        public Harmony harmonyServerInstance = new Harmony(patchCode);
        public Harmony harmonyClientInstance = new Harmony(clientPatchCode);

        public override void StartServerSide(ICoreServerAPI api)
        {
            harmonyServerInstance.PatchAll();
            StringBuilder builder = new StringBuilder("Harmony Patched Server Methods: ");
            foreach (var val in harmonyServerInstance.GetPatchedMethods())
            {
                builder.Append(val.Name + ", ");
            }
            api.Logger.Notification(builder.ToString());
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            harmonyClientInstance.PatchAll();
            StringBuilder builder = new StringBuilder("Harmony Patched Client Methods: ");
            foreach (var val in harmonyClientInstance.GetPatchedMethods())
            {
                builder.Append(val.Name + ", ");
            }
            api.Logger.Notification(builder.ToString());
        }

        public override void Dispose()
        {
            harmonyServerInstance.UnpatchAll(patchCode);
            harmonyClientInstance.UnpatchAll(clientPatchCode);
        }
    }

}