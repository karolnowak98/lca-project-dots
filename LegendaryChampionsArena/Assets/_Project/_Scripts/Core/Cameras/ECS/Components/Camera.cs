using Unity.Entities;
using Unity.Mathematics;

namespace GlassyCode.LCA.Core.Cameras.ECS.Components
{
    public struct Camera : IComponentData
    {
        public float3 Position;
        public quaternion Rotation;
    }
}