using GlassyCode.LCA.Core.Netcode.ECS.Components;
using GlassyCode.LCA.Gameplay.Buildings.ECS.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;

namespace GlassyCode.LCA.Core.Netcode.ECS.Systems
{
    [BurstCompile]
    [WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation)]
    public partial struct GoInGameServerSystem : ISystem
    {
        private ComponentLookup<NetworkId> _networkIdFromEntity;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Town>();
            var builder = new EntityQueryBuilder(Allocator.Temp)
                .WithAll<GoInGameRequest>()
                .WithAll<ReceiveRpcCommandRequest>();
            state.RequireForUpdate(state.GetEntityQuery(builder));
            _networkIdFromEntity = state.GetComponentLookup<NetworkId>(true);
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var worldName = state.WorldUnmanaged.Name;
            var commandBuffer = new EntityCommandBuffer(Allocator.Temp);
            _networkIdFromEntity.Update(ref state);

            foreach (var (reqSrc, reqEntity) in SystemAPI.Query<RefRO<ReceiveRpcCommandRequest>>().WithAll<GoInGameRequest>().WithEntityAccess())
            {
                foreach (var town in SystemAPI.Query<TownAspect>())
                {
                    var elapsedTime = SystemAPI.Time.ElapsedTime;
                    if (town.NextSpawnTime >= elapsedTime) continue;
                    
                    commandBuffer.AddComponent<NetworkStreamInGame>(reqSrc.ValueRO.SourceConnection);
                    var networkId = _networkIdFromEntity[reqSrc.ValueRO.SourceConnection];

                    Debug.Log($"'{worldName}' setting connection '{networkId.Value}' to in game");
                        
                    var newUnit = commandBuffer.Instantiate(town.PrefabToSpawn);
                    commandBuffer.SetComponent(newUnit, LocalTransform.FromPosition(town.SpawnPosition));
                    town.NextSpawnTime = (float)elapsedTime + town.SpawnRate;
                    commandBuffer.SetComponent(newUnit, new GhostOwner { NetworkId = networkId.Value});
                    commandBuffer.AppendToBuffer(reqSrc.ValueRO.SourceConnection, new LinkedEntityGroup{Value = newUnit});
                    commandBuffer.DestroyEntity(reqEntity);
                }
            }
            
            commandBuffer.Playback(state.EntityManager);
        }
    }
}