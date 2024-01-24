using GlassyCode.LCA.Core.Cameras.ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace GlassyCode.LCA.Core.Cameras.ECS.Authoring
{
    public class CameraAuthoring : MonoBehaviour
    {
        [field: SerializeField] public CamerasConfig CamerasConfig { get; private set; }
        
        private class MainCameraAuthoringBaker : Baker<CameraAuthoring>
        {
            public override void Bake(CameraAuthoring authoring)
            {
                if (authoring.CamerasConfig == null)
                {
                    Debug.LogError("Make sure Cameras Config is not empty!");
                    return;
                }

                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new MainCamera
                {
                    MoveSpeed = authoring.CamerasConfig.MainCameraMoveSpeed
                });
            }
        }
    }
}