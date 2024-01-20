using GlassyCode.LCA.Core.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace GlassyCode.LCA.Gameplay.Grid.Data
{
    [CreateAssetMenu(fileName = "Grid Config", menuName = "Configs/Grid")]
    public class GridConfig : BaseConfig
    {
        [field: SerializeField] public int2 GridSize { get; private set; }
        [field: SerializeField] public int FieldSize { get; private set; }
    }
}