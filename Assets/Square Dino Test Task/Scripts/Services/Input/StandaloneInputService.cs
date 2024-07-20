using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SquareDinoTestTask.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        public event Action OnTapped;
        public Vector3 TapPosition { get; private set; }
        public bool IsListening { get; set; }

        public void Tick()
        {
            if (!IsListening)
            {
                return;
            }
            
            Vector3 mousePosition = UnityEngine.Input.mousePosition;
            
            if (!IsMouseClick() || IsPointerOverUI(mousePosition))
            {
                return;
            }

            TapPosition = mousePosition;
            OnTapped?.Invoke();
        }
        
        private bool IsMouseClick() => 
            UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);

        private bool IsPointerOverUI(Vector3 mousePosition)
        {
            return IsPointerOverUIObject(new Vector2(mousePosition.x, mousePosition.y));
        }

        private bool IsPointerOverUIObject(Vector2 clickPosition) 
        {
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(GetEventDataCurrentPosition(clickPosition), results);
            
            return results.Count > 0;
        }

        private PointerEventData GetEventDataCurrentPosition(Vector2 clickPosition)
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = clickPosition;

            return eventDataCurrentPosition;
        }
    }
}