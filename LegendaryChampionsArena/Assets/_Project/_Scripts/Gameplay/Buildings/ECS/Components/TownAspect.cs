using GlassyCode.LCA.Utils.ECS;
using Unity.Entities;
using Unity.Mathematics;

namespace GlassyCode.LCA.Gameplay.Buildings.ECS.Components
{
    public readonly partial struct TownAspect : IAspect
    {
        public readonly Entity Self;
        
        private readonly RefRW<Town> _town;
        private readonly RefRW<Spawner> _spawner;

        public float NextSpawnTime
        {
            get => _spawner.ValueRO.NextSpawnTime;
            set => _spawner.ValueRW.NextSpawnTime = value;
        }

        public float SpawnRate
        {
            get => _spawner.ValueRO.SpawnRate;
            set => _spawner.ValueRW.SpawnRate = value;
        }

        public float3 SpawnPosition
        {
            get => _spawner.ValueRO.SpawnPosition;
            set => _spawner.ValueRW.SpawnPosition = value;
        }

        public Entity PrefabToSpawn
        {
            get => _spawner.ValueRO.PrefabToSpawn;
            set => _spawner.ValueRW.PrefabToSpawn = value;
        }
    }
}