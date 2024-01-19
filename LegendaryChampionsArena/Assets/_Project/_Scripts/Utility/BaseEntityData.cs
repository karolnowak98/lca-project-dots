using UnityEngine;

namespace GlassyCode.LCA.Utility
{
    //Represents not abstract game object
    public abstract class BaseEntityData : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}