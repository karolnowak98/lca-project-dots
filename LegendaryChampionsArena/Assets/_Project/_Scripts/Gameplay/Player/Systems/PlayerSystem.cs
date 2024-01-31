using GlassyCode.LCA.Core.Netcode.ECS.Components;
using Unity.Burst;
using Unity.Entities;

namespace GlassyCode.LCA.Gameplay.Player.Systems
{
    [WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation)]
    public partial struct PlayerSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.EntityManager.CreateSingleton<PlayerInfo>("dsa");

            SystemAPI.SetSingleton(new PlayerInfo
            {
                Name = "Unique",
                NetworkId = 1
            });
        }
    }
}