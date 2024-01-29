using Unity.Collections;
using Unity.Entities;

namespace GlassyCode.LCA.Core.Netcode.ECS.Components
{
    public struct GfxDeviceInformation : IComponentData
    {
        public int MemorySize;
        public FixedString64Bytes Name;
        public FixedString64Bytes Version;
        public FixedString64Bytes API;
        public FixedString64Bytes Vendor;

        public override string ToString()
        {
            const string separator = "\n-----------------------\n";
            var stats = string.Empty;
            stats += $"GPU{separator}";
            stats += $"Name: {Name}\n";
            stats += $"Version: {Version}\n";
            stats += $"GFX API: {API}\n";
            stats += $"Vendor: {Vendor}\n";
            stats += $"Memory Size: {MemorySize} MB\n";
            return stats;
        }
    }
}