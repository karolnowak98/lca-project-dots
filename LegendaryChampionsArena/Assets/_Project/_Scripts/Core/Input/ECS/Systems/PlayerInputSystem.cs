using GlassyCode.LCA.Core.Input.ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace GlassyCode.LCA.Core.Input.ECS.Systems
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class PlayerInputSystem : SystemBase
    {
        private Entity _cameraEntity;
        private GameInput _gameInput;
        
        protected override void OnCreate()
        {
            RequireForUpdate<MoveCameraInput>();
            
            _gameInput = new GameInput();
        }

        protected override void OnStartRunning()
        {
            _gameInput.Enable();
        }

        protected override void OnUpdate()
        {
            var moveInput = _gameInput.GamePlay.MoveCamera.ReadValue<Vector2>();
            
            SystemAPI.SetSingleton(new MoveCameraInput {Value = moveInput});
        }

        protected override void OnStopRunning()
        {
            _gameInput.Disable();
        }
    }
}