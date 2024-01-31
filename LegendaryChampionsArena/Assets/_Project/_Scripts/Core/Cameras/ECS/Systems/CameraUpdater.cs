using GlassyCode.LCA.Core.Cameras.ECS.Components;
using GlassyCode.LCA.Core.Input.ECS.Components;
using GlassyCode.LCA.Core.Netcode.ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace GlassyCode.LCA.Core.Cameras.ECS.Systems
{
    [UpdateAfter(typeof(TransformSystemGroup))]
    [UpdateAfter(typeof(CameraPreparer))]
    [WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation)]
    public partial struct CameraUpdater : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MoveCameraInput>();
            state.RequireForUpdate<PlayerInfo>();
            state.RequireForUpdate<Camera>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var cameraInstance = CameraManager.Instance;

            if (cameraInstance == null) return;
            
            var playerName = SystemAPI.GetSingleton<PlayerInfo>().Name;
            var camera = SystemAPI.GetSingleton<Camera>();
            
            if (!cameraInstance.DoCameraExist(playerName))
            {
                cameraInstance.CreateCameraForPlayer(playerName);
            }
            else
            {
                cameraInstance.SetCameraPosition(playerName, camera.Position);
                //cameraInstance.SetCameraRotation(playerName, camera.Rotation);
            }
        }
    }
}