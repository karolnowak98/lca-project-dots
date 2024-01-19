using GlassyCode.LCA.Gameplay.Buildings.Authoring;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace GlassyCode.LCA.Gameplay.Buildings.Systems
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
            var ecb = GetEntityCommandBuffer(ref state);
            
            var job = new ProcessSpawningJob
            {
                Ecb = ecb,
                ElapsedTime = SystemAPI.Time.ElapsedTime
            };
                
            job.ScheduleParallel();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }
        
        private EntityCommandBuffer.ParallelWriter GetEntityCommandBuffer(ref SystemState state)
        {
            var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
            var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
            return ecb.AsParallelWriter();
        }
    }
    
    [BurstCompile]
    public partial struct ProcessSpawningJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter Ecb;
        public double ElapsedTime;
        
        public void Execute([ChunkIndexInQuery] int chunkIndex, ref MainBuilding building)
        {
            if (building.NextSpawnTime < ElapsedTime)
            {
                var newUnit = Ecb.Instantiate(chunkIndex, building.UnitPrefab);
                var newPosition = building.SpawnPosition;
                Ecb.SetComponent(chunkIndex, newUnit, LocalTransform.FromPosition(building.SpawnPosition));

                building.NextSpawnTime = (float)ElapsedTime + building.SpawnRate;
            }
        }
    }
}