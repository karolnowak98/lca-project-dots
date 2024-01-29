using Unity.Burst;
using Unity.Entities;
using Unity.NetCode;

namespace GlassyCode.LCA.Core.Netcode.ECS.Systems
{
    /// <summary>
    /// This allows sending RPCs between a stand alone build and the editor for testing purposes in the event when you finish this example
    /// you want to connect a server-client stand alone build to a client configured editor instance. 
    /// </summary>
    [BurstCompile]
    [WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation 
                       | WorldSystemFilterFlags.ServerSimulation 
                       | WorldSystemFilterFlags.ThinClientSimulation)]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [CreateAfter(typeof(RpcSystem))]
    public partial struct SetRpcSystemDynamicAssemblyListSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            SystemAPI.GetSingletonRW<RpcCollection>().ValueRW.DynamicAssemblyList = true;
            state.Enabled = false;
        }
    }
}