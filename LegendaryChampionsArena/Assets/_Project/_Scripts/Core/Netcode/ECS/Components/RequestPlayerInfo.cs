using Unity.NetCode;

namespace GlassyCode.LCA.Core.Netcode.ECS.Components
{
    public struct RequestPlayerInfo : IRpcCommand
    {
        public PlayerInfo PlayerInfo;
        public GfxDeviceInformation GfxDeviceInfo;
        public CPUDeviceInformation CPUDeviceInfo;
        public MemoryDeviceInformation MemoryDeviceInfo;
        
        public override string ToString()
        {
            return PlayerInfo + GfxDeviceInfo.ToString() + CPUDeviceInfo + MemoryDeviceInfo;
        }
    }
}