using GlassyCode.LCA.Gameplay.Buildings.Data;
using GlassyCode.LCA.Gameplay.Buildings.ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace GlassyCode.LCA.Gameplay.Buildings.ECS.Authoring
{
    public class TownAuthoring : MonoBehaviour
    {
        [field: SerializeField] public TownEntityData TownEntityData { get; private set; }
        
        private class MainBuildingAuthoringBaker : Baker<TownAuthoring>
        {
            public override void Bake(TownAuthoring authoring)
            {
                DependsOn(authoring.TownEntityData);
                
                if (authoring.TownEntityData == null)
                {
                    Debug.LogError("Make sure Town Entity Data is not empty at any Town Authoring!");
                    return;
                }
                
                var entity = GetEntity(TransformUsageFlags.Renderable);
                
                AddComponent(entity, new Town
                {
                    UnitPrefab = GetEntity(authoring.TownEntityData.UnitToSpawn.Prefab, TransformUsageFlags.Dynamic),
                    SpawnRate = authoring.TownEntityData.StartingSpawnRate,
                    SpawnPosition = authoring.TownEntityData.StartingSpawnRate,
                    NextSpawnTime = 0.0f
                });
            }
        }
    }
}