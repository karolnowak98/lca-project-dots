using GlassyCode.LCA.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace GlassyCode.LCA.Gameplay.Grid.Data
{
    [CreateAssetMenu(fileName = "Grid Settings", menuName = "Settings/Grid")]
    public class GridSettings : BaseSettings
    {
        [field: SerializeField] public int2 GridSize { get; private set; }
        [field: SerializeField] public int FieldSize { get; private set; }
    }
}