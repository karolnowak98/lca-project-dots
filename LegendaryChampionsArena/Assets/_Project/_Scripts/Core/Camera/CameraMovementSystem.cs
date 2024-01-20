using GlassyCode.LCA.Core.Input.ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace GlassyCode.LCA.Core.Camera
{
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct CameraMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            new CameraMoveJob
            {
                DeltaTime = deltaTime
            }.Schedule();
        }
    }

    [BurstCompile]
    public partial struct CameraMoveJob : IJobEntity
    {
        public float DeltaTime;

        [BurstCompile]
        private void Execute(ref LocalTransform transform, in MoveCameraInput moveCameraInput, in Camera camera)
        {
            Debug.Log("s" + transform.Position);
            
            transform.Position.xz += moveCameraInput.Value * camera.MoveSpeed * DeltaTime;
        }
    }
}