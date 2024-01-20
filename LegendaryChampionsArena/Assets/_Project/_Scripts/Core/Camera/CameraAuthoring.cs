using GlassyCode.LCA.Core.Input.ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace GlassyCode.LCA.Core.Camera
{
    public class CameraAuthoring : MonoBehaviour
    {
        [field: SerializeField] public CameraConfig CameraConfig { get; private set; }
        
        private class CameraAuthoringBaker : Baker<CameraAuthoring>
        {
            public override void Bake(CameraAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity, new MoveCameraInput());
                AddComponent(entity, new Camera{MoveSpeed = authoring.CameraConfig.MoveSpeed});
            }
        }
    }
}