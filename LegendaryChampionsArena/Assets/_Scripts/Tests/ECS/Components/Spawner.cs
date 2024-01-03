using Unity.Entities;
using Unity.Mathematics;

namespace GlassyCode.LCA.Tests.ECS.Components
{
    public struct Spawner : IComponentData
    {
        public Entity Prefab;
        public float3 SpawnPosition;
        public float NextSpawnTime;
        public float SpawnRate;
    }
}