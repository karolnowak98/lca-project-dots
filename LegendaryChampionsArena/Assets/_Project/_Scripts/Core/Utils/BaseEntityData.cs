using UnityEngine;

namespace GlassyCode.LCA.Core.Utils
{
    //Represents not abstract game object
    public abstract class BaseEntityData : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}