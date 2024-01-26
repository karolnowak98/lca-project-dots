using GlassyCode.LCA.Core.Grid.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace GlassyCode.LCA.Core.Grid.ECS.Authoring
{
    public class GridAuthoring : MonoBehaviour
    {
        [field: SerializeField] public GridConfig GridConfig { get; private set; }
        
        private class GridAuthoringBaker : Baker<GridAuthoring>
        {
            public override void Bake(GridAuthoring authoring)
            {
                var gridSize = authoring.GridConfig.GridSize;
                var fieldSize = authoring.GridConfig.FieldSize;
                var builder = new BlobBuilder(Allocator.Temp);

                ref var gridFields = ref builder.ConstructRoot<GridFields>();
                var gridFieldsArray = builder.Allocate(ref gridFields.GridFieldsArray, gridSize.x * gridSize.y);
            
                var xPos = (float)fieldSize / 2;
                var zPos = (float)fieldSize / 2;

                for (var x = 0; x < gridSize.x; x++)
                {
                    for (var y = 0; y < gridSize.y; y++)
                    {
                        var index = x + y * gridSize.x;
                    
                        gridFieldsArray[index] = new GridField
                        {
                            Index = new int2(x, y), 
                            CenterWorldPosition = new float3(xPos, 10000, zPos)
                        };
                    
                        zPos += fieldSize;
                    }

                    xPos += fieldSize;
                    zPos = (float)fieldSize / 2;
                }

                var blobReference = builder.CreateBlobAssetReference<GridFields>(Allocator.Persistent);
                builder.Dispose();
                
                AddBlobAsset(ref blobReference, out _);
                var entity = GetEntity(TransformUsageFlags.None);
                var gizmosManager = GizmosManager.Instance;
                
                AddComponent(entity, new GridData { GridFields = blobReference, FieldSize = fieldSize });
                AddComponent(entity, new GridGizmo 
                { 
                    DrawGridGizmo = gizmosManager.DrawGridGizmo, 
                    GridHeightOffset = gizmosManager.GridHeightOffset, 
                    GridFieldDivider = gizmosManager.GridFieldDivider
                });
            }
        }
    }
}