using GlassyCode.LCA.Core.Grid.ECS.Components;
using Unity.Entities;
using Unity.Mathematics;

namespace GlassyCode.LCA.Core.Grid.ECS.Systems
{
    public partial struct GridGizmoDrawingSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<GridGizmo>();
        }
        
        public void OnUpdate(ref SystemState state)
        {
            var entity = SystemAPI.GetSingletonEntity<GridGizmo>();
            var gridAspect = SystemAPI.GetAspect<GridAspect>(entity);

            if (!gridAspect.DrawGridGizmo)
                return;
            
            ref var gridFields = ref gridAspect.GridFields.Value;
            ref var gridFieldsArray  = ref gridFields.GridFieldsArray;
            var fieldSize = gridAspect.FieldSize;
            var divider = gridAspect.GridFieldDivider;
            var offset = gridAspect.GridHeightOffset;
            
            var squareSide = new float2(fieldSize / divider, fieldSize / divider);
            var sizeOfSquare = new float3(squareSide.x, 0, squareSide.y);
            
            for (var x = 0; x < gridFieldsArray.Length; x++)
            {
                var gridField = gridFieldsArray[x];
                var calculatedFieldPosition = new float3(gridField.CenterWorldPosition.x, 
                    offset, gridField.CenterWorldPosition.z);

                GizmosManager.Instance.EnqueueGizmo(calculatedFieldPosition, sizeOfSquare);
            }
        }
    }
}