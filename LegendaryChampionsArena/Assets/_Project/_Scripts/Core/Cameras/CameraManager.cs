using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace GlassyCode.LCA.Core.Cameras
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CameraConfig _config;
        [SerializeField] private GameObject _cameraPrefab;

        private readonly Dictionary<FixedString64Bytes, PlayerCamera> _cameras = new();
        
        public static CameraManager Instance { get; private set; }
        public float CameraMoveSpeed => _config.CameraMoveSpeed;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public bool DoCameraExist(FixedString64Bytes playerName)
        {
            return _cameras.ContainsKey(playerName);
        }

        //TODO Add position/rotation
        public void CreateCameraForPlayer(FixedString64Bytes playerName)
        {
            if (_cameras.ContainsKey(playerName)) return;
            
            var trans = _cameraPrefab.transform;
            var newCamera = Instantiate(_cameraPrefab, trans.position, trans.rotation, transform);
            _cameras.TryAdd(playerName, new PlayerCamera(newCamera.transform, _config.CameraSmoothness));
        }

        public void DestroyCamera(FixedString64Bytes playerName)
        {
            if (!_cameras.TryGetValue(playerName, out var playerCamera)) return;
            playerCamera.Destroy();
            _cameras.Remove(playerName);
        }
        
        public void PlaceCamera(FixedString64Bytes playerName, float3 position)
        {
            if (!_cameras.TryGetValue(playerName, out var playerCamera)) return;
            playerCamera.PlaceCamera(position);
        }

        public void ResetCamera(FixedString64Bytes playerName)
        {
            if (!_cameras.TryGetValue(playerName, out var playerCamera)) return;
            playerCamera.Reset();
        }

        public void SetCameraPosition(FixedString64Bytes playerName, float3 position)
        {
            if (!_cameras.TryGetValue(playerName, out var playerCamera)) return;
            playerCamera.SetPosition(position);
        }
        
        public void SetCameraRotation(FixedString64Bytes playerName, quaternion rotation)
        {
            if (!_cameras.TryGetValue(playerName, out var playerCamera)) return;
            playerCamera.SetRotation(rotation);
        }
    }
}