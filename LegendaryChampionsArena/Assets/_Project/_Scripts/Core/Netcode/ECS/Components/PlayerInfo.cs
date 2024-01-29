using Unity.Collections;
using Unity.Entities;

namespace GlassyCode.LCA.Core.Netcode.ECS.Components
{
    public struct PlayerInfo : IComponentData
    {
        public int NetworkId;
        public FixedString64Bytes Name;
    }
}