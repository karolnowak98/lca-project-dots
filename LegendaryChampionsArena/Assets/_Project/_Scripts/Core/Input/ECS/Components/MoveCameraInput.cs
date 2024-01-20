using Unity.Entities;
using Unity.Mathematics;

namespace GlassyCode.LCA.Core.Input.ECS.Components
{
    public struct MoveCameraInput : IComponentData
    {
        public float2 Value;
    }
}