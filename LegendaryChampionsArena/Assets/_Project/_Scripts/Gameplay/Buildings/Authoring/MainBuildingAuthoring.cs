using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace GlassyCode.LCA.Gameplay.Buildings.Authoring
{
    public class MainBuildingAuthoring : MonoBehaviour
    {
        public GameObject UnitPrefab;
        public float SpawnRate;
        public Vector3 SpawnPosition;
        
        private class MainBuildingAuthoringBaker : Baker<MainBuildingAuthoring>
        {
            public override void Bake(MainBuildingAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new MainBuilding
                {
                    UnitPrefab = GetEntity(authoring.UnitPrefab, TransformUsageFlags.Dynamic),
                    SpawnRate = authoring.SpawnRate,
                    SpawnPosition = authoring.SpawnPosition,
                    NextSpawnTime = 0.0f
                });
            }
        }
    }
    
    public struct MainBuilding : IComponentData
    {
        public Entity UnitPrefab;
        public float3 SpawnPosition;
        public float SpawnRate;
        public float NextSpawnTime;
    }
}