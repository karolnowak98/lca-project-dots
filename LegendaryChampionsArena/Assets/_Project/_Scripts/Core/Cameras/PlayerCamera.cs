using Unity.Mathematics;
using UnityEngine;

namespace GlassyCode.LCA.Core.Cameras
{
    public class PlayerCamera
    {
        private readonly float _cameraSmoothness; 
        
        public Transform Transform { get; private set; }
        public bool IsCameraReady { get; private set; }
        
        public PlayerCamera(Transform transform, float cameraSmoothness)
        {
            Transform = transform;
            _cameraSmoothness = cameraSmoothness;
            IsCameraReady = false;
        }

        public void Reset()
        {
            IsCameraReady = false;
        }

        public void Destroy()
        {
            Object.Destroy(Transform);
        }

        public void PlaceCamera(float3 position)
        {
            Transform.position = position;
            IsCameraReady = true;
        }

        public void SetPosition(float3 position)
        {
            Transform.position = math.lerp(Transform.position, position, _cameraSmoothness);
        }
        
        public void SetRotation(quaternion rotation)
        {
            Transform.rotation = math.slerp(Transform.rotation, rotation, _cameraSmoothness);
        }
    }
}