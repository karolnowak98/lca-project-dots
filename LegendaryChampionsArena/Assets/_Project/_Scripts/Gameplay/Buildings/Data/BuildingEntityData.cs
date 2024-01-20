using GlassyCode.LCA.Core.Utils;
using GlassyCode.LCA.Gameplay.Enums;
using UnityEngine;

namespace GlassyCode.LCA.Gameplay.Buildings.Data
{
    public abstract class BuildingEntityData : BaseEntityData
    {
        [field: Header("Base statistics")]
        [field: SerializeField] public BuildingName Name { get; private set; }
        [field: SerializeField] public BuildingType Type { get; private set; }
        [field: SerializeField] public int StartingHealth { get; private set; }
        [field: SerializeField] public ArmorType ArmorType { get; private set; }
        [field: SerializeField] public int StartingArmor { get; private set; }
    }
}