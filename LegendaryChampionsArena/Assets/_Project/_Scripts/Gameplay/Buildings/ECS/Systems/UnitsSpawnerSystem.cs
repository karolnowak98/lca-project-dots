using GlassyCode.LCA.Gameplay.Buildings.ECS.Authoring;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

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
        
        //Might be private, probably for testing purposes better is public
        public void Execute([ChunkIndexInQuery] int chunkIndex, ref Town town)
        {
            if (town.NextSpawnTime < ElapsedTime)
            {
                var newUnit = Ecb.Instantiate(chunkIndex, town.UnitPrefab);
                
                var newPosition = town.SpawnPosition;
                Ecb.SetComponent(chunkIndex, newUnit, LocalTransform.FromPosition(town.SpawnPosition));

                town.NextSpawnTime = (float) ElapsedTime + town.SpawnRate;
            }
        }
    }
}