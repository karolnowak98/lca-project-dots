using GlassyCode.LCA.Gameplay.Units.Data;
using UnityEngine;

namespace GlassyCode.LCA.Gameplay.Buildings.Data
{
    [CreateAssetMenu(fileName = "Main Building Entity", menuName = "Entities/Main Building")]
    public class TownEntityData : BuildingEntityData
    {
        [field: Header("Unit Spawning")]
        [field: SerializeField] public UnitEntityData UnitToSpawn { get; private set; }
        [field: SerializeField] public Vector3 StartingSpawnPosition { get; private set; }
        [field: SerializeField] public Vector3 StartingSpawningOffset { get; private set; }
        [field: SerializeField] public float StartingSpawnRate { get; private set; }
        [field: SerializeField] public int MaxSpawnedUnits { get; private set; }
    }
}