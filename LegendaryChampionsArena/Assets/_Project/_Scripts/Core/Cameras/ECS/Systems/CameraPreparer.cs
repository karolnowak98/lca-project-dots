using GlassyCode.LCA.Core.Cameras.ECS.Components;
using GlassyCode.LCA.Core.Input.ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace GlassyCode.LCA.Core.Cameras.ECS.Systems
{
    [UpdateInGroup(typeof(TransformSystemGroup))]
    public partial struct CameraPreparer : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MoveCameraInput>();
            state.RequireForUpdate<MainCamera>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var moveCameraInput = SystemAPI.GetSingleton<MoveCameraInput>();

            var job = new UpdateCameraTransformJob
            {
                DeltaTime = SystemAPI.Time.DeltaTime,
                MoveCameraInput = moveCameraInput.Value
            };

            state.Dependency = job.ScheduleParallel(state.Dependency);
            state.CompleteDependency();
        }
    }

    [BurstCompile]
    internal partial struct UpdateCameraTransformJob : IJobEntity
    {
        public float DeltaTime;
        public float2 MoveCameraInput;
        
        private void Execute(ref MainCamera camera)
        {
            camera.Position.xz +=  MoveCameraInput * DeltaTime * camera.MoveSpeed;
        }
    }
}