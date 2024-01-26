using Unity.Entities;

namespace GlassyCode.LCA.Core.Grid.ECS.Components
{
    public struct GridData : IComponentData
    {
        public BlobAssetReference<GridFields> GridFields;
        public int FieldSize;
    }
}