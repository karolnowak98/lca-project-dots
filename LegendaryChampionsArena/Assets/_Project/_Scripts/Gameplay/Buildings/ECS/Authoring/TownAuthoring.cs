using GlassyCode.LCA.Gameplay.Buildings.Data;
using GlassyCode.LCA.Gameplay.Buildings.ECS.Components;
using GlassyCode.LCA.Utils.ECS;
using Unity.Entities;
using UnityEngine;

namespace GlassyCode.LCA.Gameplay.Buildings.ECS.Authoring
{
    public class TownAuthoring : MonoBehaviour
    {
        [field: SerializeField] public TownEntityData TownEntityData { get; private set; }
        [field: SerializeField] public Transform SpawnPoint { get; private set; }
        
        private class TownAuthoringBaker : Baker<TownAuthoring>
        {
            public override void Bake(TownAuthoring authoring)
            {
                DependsOn(authoring.TownEntityData);
                DependsOn(authoring.SpawnPoint);
                
                if (authoring.TownEntityData == null)
                {
                    Debug.LogError("Make sure Town Entity Data is not empty at any Town Authoring!");
                    return;
                }
                
                if (authoring.SpawnPoint == null)
                {
                    Debug.LogError("Make sure Spawn Point of spawner is not empty at any Town Authoring!");
                    return;
                }

                var entity = GetEntity(TransformUsageFlags.Renderable);
                
                AddComponent(entity, new Town());
                AddComponent(entity, new Spawner
                {
                    PrefabToSpawn = GetEntity(authoring.TownEntityData.UnitToSpawn.Prefab, TransformUsageFlags.Dynamic),
                    SpawnRate = authoring.TownEntityData.StartingSpawnRate,
                    SpawnPosition = authoring.SpawnPoint.position,
                    NextSpawnTime = 0.0f
                });
            }
        }
    }
}