using UnityEngine;
using GlassyCode.LCA.Gameplay.Enums;
using GlassyCode.LCA.Utils;

namespace GlassyCode.LCA.Gameplay.Units.Data
{
    [CreateAssetMenu(fileName = "Unit Entity Data", menuName = "Entities Data/Unit")]
    public class UnitEntityData : BaseEntityData
    {
        [field: SerializeField] public UnitName Name { get; private set; }
        [field: SerializeField] public int StartingHealth { get; private set; }
        [field: SerializeField] public ArmorType ArmorType { get; private set; }
        [field: SerializeField] public int StartingArmor { get; private set; }
        [field: SerializeField] public AttackType AttackType { get; private set; }
        [field: SerializeField] public Vector2Int AttackDamage { get; private set; }
        [field: SerializeField] public int AttackRange { get; private set; }
        [field: SerializeField] public int AttackRate { get; private set; }
        [field: SerializeField] public int MovementSpeed { get; private set; }
    }
}