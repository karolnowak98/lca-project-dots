using UnityEngine;

namespace GlassyCode.LCA.MainMenu
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "Settings/Game")]
    public class MenuSettings : ScriptableObject
    {
        [field: SerializeField] public Color[] ColorsForPlayers { get; private set; }
    }
}