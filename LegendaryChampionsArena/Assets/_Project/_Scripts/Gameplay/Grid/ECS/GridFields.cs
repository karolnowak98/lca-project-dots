using Unity.Entities;
using Unity.Mathematics;

namespace GlassyCode.LCA.Gameplay.Grid.ECS
{
    public struct GridFields
    {
        public BlobArray<GridField> GridFieldsArray;
    }
    
    public struct GridField
    {
        public int2 Index;
        public float3 CenterWorldPosition;
        public bool IsWalkable;
    }
}