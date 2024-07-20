using UnityEngine;

namespace SquareDinoTestTask.UI
{
    
    [CreateAssetMenu(menuName = "Square Dino Test Task/ Menu Prefabs Collection", fileName = "Menu Prefabs Collection")]
    public class MenuPrefabsCollection : ScriptableObject
    {
        public StartMenu startMenuPrefab;
        public ReloadMenu reloadMenuPrefab;
    }
}