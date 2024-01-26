using GlassyCode.LCA.Utils;
using UnityEngine;

namespace GlassyCode.LCA.Core.Cameras
{
    [CreateAssetMenu(fileName = "Camera Config", menuName = "Configs/Camera")]
    public class CameraConfig : BaseConfig
    {
        [field: SerializeField] public float CameraMoveSpeed { get; set; }
        [field: SerializeField] public float CameraSmoothness { get; set; }
    }
}