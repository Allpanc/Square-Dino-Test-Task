using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.UI
{
    public class MenuFactory
    {
        private readonly DiContainer container;
        private readonly MenuPrefabsCollection menuPrefabsCollection;

        [Inject]
        public MenuFactory(DiContainer container, MenuPrefabsCollection menuPrefabsCollection)
        {
            this.container = container;
            this.menuPrefabsCollection = menuPrefabsCollection;
        }

        public StartMenu CreateStartMenu(Transform parent)
        {
            StartMenu startMenu = container.InstantiatePrefabForComponent<StartMenu>(
                menuPrefabsCollection.startMenuPrefab, 
                parent.position, 
                Quaternion.identity, 
                parent);

            RectTransform rectTransform = startMenu.GetComponent<RectTransform>();
            StretchToFillParent(rectTransform);
            
            return startMenu;
        }

        public ReloadMenu CreateReloadMenu(Transform parent)
        {
            ReloadMenu reloadMenu = container.InstantiatePrefabForComponent<ReloadMenu>(
                menuPrefabsCollection.reloadMenuPrefab, 
                parent.position, 
                Quaternion.identity, 
                parent);
            
            RectTransform rectTransform = reloadMenu.GetComponent<RectTransform>();
            StretchToFillParent(rectTransform);

            return reloadMenu;
        }
        
        private void StretchToFillParent(RectTransform uiElement)
        {
            uiElement.anchorMin = new Vector2(0, 0);
            uiElement.anchorMax = new Vector2(1, 1);
            
            uiElement.offsetMin = new Vector2(0, 0);
            uiElement.offsetMax = new Vector2(0, 0);
            
            uiElement.anchoredPosition = new Vector2(0, 0);
            uiElement.sizeDelta = new Vector2(0, 0);
        }
    }
}