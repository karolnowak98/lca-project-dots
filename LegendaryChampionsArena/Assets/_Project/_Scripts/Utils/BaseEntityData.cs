using UnityEngine;

namespace GlassyCode.LCA.Utils
{
    //Represents not abstract game object
    public abstract class BaseEntityData : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}