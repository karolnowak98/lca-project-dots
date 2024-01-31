using Unity.Collections;
using Unity.Entities;

namespace GlassyCode.LCA.Core.Netcode.ECS.Components
{
    public struct MemoryDeviceInformation : IComponentData
    {
        public FixedString64Bytes Size;
        public FixedString64Bytes Allocated;
        public FixedString64Bytes Free;

        public override string ToString()
        {
            const string separator = "\n-----------------------\n";
            var stats = string.Empty;
            stats += $"{separator}";
            stats += $"Memory{separator}";
            stats += $"Size: {Size}\n";
            stats += $"Allocated: {Allocated}\n";
            stats += $"Free: {Free}\n";
            return stats;
        }
    }
}