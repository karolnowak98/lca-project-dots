using GlassyCode.LCA.Core.Utils;
using UnityEngine;

namespace GlassyCode.LCA.Core.Cameras
{
    [CreateAssetMenu(fileName = "Camera Config", menuName = "Configs/Camera")]
    public class CamerasConfig : BaseConfig
    {
        [field: SerializeField] public float MainCameraMoveSpeed { get; set; }
        [field: SerializeField] public float CameraSmoothness { get; set; }
    }
}