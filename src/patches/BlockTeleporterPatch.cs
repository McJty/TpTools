using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace TpTools
{

    [HarmonyPatch(typeof(BlockTeleporter), "OnBlockInteractStart")]
    class BlockTeleporterPatch
    {
        static bool Prefix(BlockTeleporter __instance, IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel, ref bool __result)
        {
            if (byPlayer.WorldData.CurrentGameMode == EnumGameMode.Survival)
            {
                ItemStack heldItem = byPlayer.InventoryManager.ActiveHotbarSlot.Itemstack;
                if (heldItem != null && heldItem.Item is ItemPadlock)
                {
                    world.BlockAccessor.BreakBlock(blockSel.Position, byPlayer);
                    __result = true;
                    return false;
                }
                TreeAttribute tree = new TreeAttribute();
                tree.SetInt("posX", blockSel.Position.X);
                tree.SetInt("posY", blockSel.Position.Y);
                tree.SetInt("posZ", blockSel.Position.Z);
                tree.SetString("playerUid", byPlayer.PlayerUID);

                world.Api.Event.PushEvent("configTeleporter", tree);
                __result = true;
            }
            return false;
        }
    }

}