using Unity.NetCode;

namespace GlassyCode.LCA.Core.Netcode
{
    [UnityEngine.Scripting.Preserve]
    public class GameBootstrap : ClientServerBootstrap
    {
        public override bool Initialize(string defaultWorldName)
        {
            AutoConnectPort = 7979;
            
            if (AutoConnectPort != 0)
            {
                return base.Initialize(defaultWorldName);
            }

            AutoConnectPort = 0;
            CreateLocalWorld(defaultWorldName);
            return true;
        }
    }
}