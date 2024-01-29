using Unity.Entities;

namespace GlassyCode.LCA.Core.Netcode.ECS.Components
{
    public readonly partial struct RequestPlayerInfoAspect : IAspect
    {
        public readonly Entity Self;
        
        private readonly RefRO<RequestPlayerInfo> _spawnRequest;
        private readonly RefRO<Unity.NetCode.ReceiveRpcCommandRequest> _receiveRpcRequest;
        
        public string Data => _spawnRequest.ValueRO.ToString();
        public string PlayerName => _spawnRequest.ValueRO.PlayerInfo.Name.ToString();
        public Entity SourceConnection => _receiveRpcRequest.ValueRO.SourceConnection;
    }
}