using GlassyCode.LCA.Gameplay.Buildings.Data;
using Unity.Entities;
using Unity.Mathematics;
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
    
    public struct Town : IComponentData
    {
        public Entity UnitPrefab;
        public float3 SpawnPosition;
        public float SpawnRate;
        public float NextSpawnTime;
    }
}