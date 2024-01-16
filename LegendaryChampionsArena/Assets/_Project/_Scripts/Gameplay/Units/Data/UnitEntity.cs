using UnityEngine;

namespace GlassyCode.LCA.Gameplay.Units.Data
{
    [CreateAssetMenu(fileName = "Unit Entity", menuName = "Entities/Unit")]
    public class UnitEntity : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set;  }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}