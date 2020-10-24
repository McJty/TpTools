using System.Collections.Generic;
using Vintagestory.API.Common;

[assembly: ModInfo("tptools",
    Description = "Teleportation Tools",
    Authors = new[] { "McJty" })]


namespace TpTools
{

    public class TpTools : ModSystem {

        public static string MODID = "tptools";

        public override void Start(ICoreAPI api) {
            base.Start(api);
        }
    }
    
}