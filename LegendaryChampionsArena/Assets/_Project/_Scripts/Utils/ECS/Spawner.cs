using Unity.Entities;
using Unity.Mathematics;

namespace GlassyCode.LCA.Utils.ECS
{
    public struct Spawner : IComponentData
    {
        public Entity PrefabToSpawn;
        public float3 SpawnPosition;
        public float SpawnRate;
        public float NextSpawnTime;
    }
}