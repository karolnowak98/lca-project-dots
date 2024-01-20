using GlassyCode.LCA.Core.Utils;
using UnityEngine;

namespace GlassyCode.LCA.Core.Camera
{
    [CreateAssetMenu(fileName = "Camera Config", menuName = "Configs/Camera")]
    public class CameraConfig : BaseConfig
    {
        [field: SerializeField] public float MoveSpeed { get; set; }
    }
}