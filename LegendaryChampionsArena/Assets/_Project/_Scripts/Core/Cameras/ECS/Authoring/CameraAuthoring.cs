using GlassyCode.LCA.Core.Cameras.ECS.Components;
using Unity.Entities;
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
                
                AddComponent(entity, new Camera
                {
                    Position = CameraManager.Instance.CameraPosition,
                    Rotation = CameraManager.Instance.CameraRotation,
                });
                AddComponent(entity, new CameraData
                {
                    MoveSpeed = CameraManager.Instance.CameraMoveSpeed
                });
            }
        }
    }
}