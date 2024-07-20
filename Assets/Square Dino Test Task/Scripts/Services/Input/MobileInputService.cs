using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SquareDinoTestTask.Services.Input
{
    public class MobileInputService : IInputService
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
            
            Touch touch = GetFirstTouch();
            
            if (!IsTap(touch) || IsPointerOverUI(touch))
            {
                return;
            }

            TapPosition = touch.position;
            OnTapped?.Invoke();
        }

        private bool IsTap(Touch touch)
        {
            return UnityEngine.Input.touchCount == 1 && 
                   touch.phase == TouchPhase.Began;
        }

        private bool IsPointerOverUI(Touch touch)
        {
            return IsPointerOverUIObject(new Vector2(touch.position.x, touch.position.y));
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

        private Touch GetFirstTouch()
        {
            return UnityEngine.Input.GetTouch(0);
        }
    }
}