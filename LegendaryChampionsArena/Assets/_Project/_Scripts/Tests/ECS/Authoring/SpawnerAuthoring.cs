using GlassyCode.LCA.Tests.ECS.Components;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace GlassyCode.LCA.Tests.ECS.Authoring
{
    public class SpawnerAuthoring : MonoBehaviour
    {
        [FormerlySerializedAs("Prefab")] public GameObject _prefab;
        [FormerlySerializedAs("SpawnRate")] public float _spawnRate;

        private class SpawnerBaker : Baker<SpawnerAuthoring>
        {
            public override void Bake(SpawnerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Spawner
                {
                    // By default, each authoring GameObject turns into an Entity.
                    // Given a GameObject (or authoring component), GetEntity looks up the resulting Entity.
                    Prefab = GetEntity(authoring._prefab, TransformUsageFlags.Dynamic),
                    SpawnPosition = authoring.transform.position,
                    NextSpawnTime = 0.0f,
                    SpawnRate = authoring._spawnRate
                });
            }
        }
    }
}