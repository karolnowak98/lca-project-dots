using Unity.Entities;

namespace GlassyCode.LCA.Gameplay.Grid.ECS
{
    public struct Grid : IComponentData
    {
        public BlobAssetReference<GridFields> GridFields;
        public int FieldSize;
    }
}