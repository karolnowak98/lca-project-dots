using Unity.Entities;
using Unity.Mathematics;

namespace GlassyCode.LCA.Gameplay.Buildings.ECS.Components
{
    public struct Town : IComponentData
    {
        public Entity UnitPrefab;
        public float3 SpawnPosition;
        public float SpawnRate;
        public float NextSpawnTime;
    }
}