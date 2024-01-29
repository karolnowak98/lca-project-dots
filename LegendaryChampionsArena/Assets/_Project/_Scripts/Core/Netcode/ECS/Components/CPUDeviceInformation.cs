using Unity.Collections;
using Unity.Entities;

namespace GlassyCode.LCA.Core.Netcode.ECS.Components
{
    public struct CPUDeviceInformation : IComponentData
    {
        public FixedString64Bytes Type;
        public int Count;
        public FixedString64Bytes Frequency;

        public override string ToString()
        {
            const string separator = "\n-----------------------\n";
            var stats = string.Empty;
            stats += $"{separator}";
            stats += $"CPU{separator}";
            stats += $"Type: {Type}\n";
            stats += $"Cores: {Count}\n";
            stats += $"Frequency: {Frequency}\n";
            return stats;
        }
    }
}