using GlassyCode.LCA.Core.Cameras.ECS.Components;
using Unity.Burst;
using Unity.Entities;

namespace GlassyCode.LCA.Core.Cameras.ECS.Systems
{
    public partial struct CameraUpdater : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MainCamera>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var mainCameraEntity = SystemAPI.GetSingleton<MainCamera>();

            if (!CamerasManager.Instance.IsMainCameraReady)
            {
                CamerasManager.Instance.PlaceMainCamera(mainCameraEntity.Position);
            }
            
            CamerasManager.Instance.SetMainCameraPosition(mainCameraEntity.Position);
            CamerasManager.Instance.SetMainCameraRotation(mainCameraEntity.Rotation);
        }
    }
}