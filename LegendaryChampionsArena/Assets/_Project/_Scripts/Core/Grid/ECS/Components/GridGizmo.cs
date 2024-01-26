using Unity.Entities;

namespace GlassyCode.LCA.Core.Grid.ECS.Components
{
    public struct GridGizmo : IComponentData
    {
        public bool DrawGridGizmo;
        public float GridHeightOffset;
        public float GridFieldDivider;
    }
}