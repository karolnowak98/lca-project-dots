using GlassyCode.LCA.Tests.ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace GlassyCode.LCA.Tests.ECS.Authoring
{
    public class SpawnerAuthoring : MonoBehaviour
    {
        public GameObject Prefab;
        public float SpawnRate;

        private class SpawnerBaker : Baker<SpawnerAuthoring>
        {
            public override void Bake(SpawnerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Spawner
                {
                    // By default, each authoring GameObject turns into an Entity.
                    // Given a GameObject (or authoring component), GetEntity looks up the resulting Entity.
                    Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                    SpawnPosition = authoring.transform.position,
                    NextSpawnTime = 0.0f,
                    SpawnRate = authoring.SpawnRate
                });
            }
        }
    }
}