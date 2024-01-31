using GlassyCode.LCA.Core.Cameras.ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Camera = GlassyCode.LCA.Core.Cameras.ECS.Components.Camera;

namespace GlassyCode.LCA.Core.Cameras.ECS.Authoring
{
    public class CameraAuthoring : MonoBehaviour
    {
        private class MainCameraAuthoringBaker : Baker<CameraAuthoring>
        {
            public override void Bake(CameraAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                if (CameraManager.Instance == null) return;
                
                AddComponent(entity, new Camera
                {
                    Position = new float3(5,20,5),
                    Rotation = new quaternion(60, 0, 0 , 0)
                });
                AddComponent(entity, new CameraData
                {
                    MoveSpeed = CameraManager.Instance.CameraMoveSpeed
                });
            }
        }
    }
}