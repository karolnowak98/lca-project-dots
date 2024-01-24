using GlassyCode.LCA.Core.Cameras.ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace GlassyCode.LCA.Core.Cameras.ECS.Systems
{
    [UpdateAfter(typeof(TransformSystemGroup))]
    [UpdateAfter(typeof(CameraPreparer))]
    public partial struct CameraUpdater : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Camera>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var mainCameraEntity = SystemAPI.GetSingleton<Camera>();

            if (!CameraManager.Instance.IsMainCameraReady)
            {
                CameraManager.Instance.PlaceMainCamera(mainCameraEntity.Position);
            }
            
            CameraManager.Instance.SetCameraPosition(mainCameraEntity.Position);
            CameraManager.Instance.SetCameraRotation(mainCameraEntity.Rotation);
        }
    }
}