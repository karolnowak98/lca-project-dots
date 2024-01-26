using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using GlassyCode.LCA.Gameplay.Buildings.ECS.Components;

namespace GlassyCode.LCA.Gameplay.Buildings.ECS.Systems
{
    public partial struct UnitsSpawnerSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
            var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
            var ecbParallelWriter = ecb.AsParallelWriter();
            
            var job = new ProcessSpawningJob
            {
                Ecb = ecbParallelWriter,
                ElapsedTime = SystemAPI.Time.ElapsedTime
            };
                
            job.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct ProcessSpawningJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter Ecb;
        public double ElapsedTime;
        
        private void Execute([ChunkIndexInQuery] int chunkIndex, TownAspect townAspect)
        {
            if (townAspect.NextSpawnTime >= ElapsedTime)
                return;
            
            var newUnit = Ecb.Instantiate(chunkIndex, townAspect.PrefabToSpawn);
            Ecb.SetComponent(chunkIndex, newUnit, LocalTransform.FromPosition(townAspect.SpawnPosition));
            townAspect.NextSpawnTime = (float)ElapsedTime + townAspect.SpawnRate;
        }
    }
}