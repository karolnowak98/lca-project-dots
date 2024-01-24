using Unity.Entities;
using Unity.Mathematics;

namespace GlassyCode.LCA.Core.Cameras.ECS.Components
{
    public readonly partial struct CameraAspect : IAspect
    {
        public readonly Entity Self;
        
        private readonly RefRO<CameraData> CameraData;
        private readonly RefRW<Camera> Camera;
        
        public float MoveSpeed => CameraData.ValueRO.MoveSpeed;
        
        public quaternion Rotation
        {
            get => Camera.ValueRO.Rotation;
            set => Camera.ValueRW.Rotation = value;
        }

        public float3 Position
        {
            get => Camera.ValueRO.Position;
            set => Camera.ValueRW.Position = value;
        }
    }
}