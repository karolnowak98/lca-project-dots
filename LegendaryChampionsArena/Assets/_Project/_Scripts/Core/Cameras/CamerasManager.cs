using Unity.Mathematics;
using UnityEngine;

namespace GlassyCode.LCA.Core.Cameras
{
    public class CamerasManager : MonoBehaviour
    {
        [SerializeField] private CamerasConfig _config;
        [SerializeField] private Transform _mainCameraTarget;
        
        public static CamerasManager Instance { get; private set; }
        public bool IsMainCameraReady { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                IsMainCameraReady = false;
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        
        public void PlaceMainCamera(float3 position)
        {
            _mainCameraTarget.position = position;
            IsMainCameraReady = true;
        }

        public void ResetMainCamera()
        {
            IsMainCameraReady = false;
        }

        public void SetMainCameraPosition(float3 position)
        {
            _mainCameraTarget.position = math.lerp(_mainCameraTarget.position, position, _config.CameraSmoothness);
        }
        
        public void SetMainCameraRotation(quaternion rotation)
        {
            _mainCameraTarget.rotation = math.slerp(_mainCameraTarget.rotation, rotation, _config.CameraSmoothness);
        }
    }
}