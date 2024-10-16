using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Services.Input {
    public sealed class MobileInputService : IInputService
    {
        public bool GetMouseButtonDown() {
            return UnityEngine.Input.touches.Length > 0 &&
                   UnityEngine.Input.touches[0].phase == TouchPhase.Began;
        }
        
        public bool GetMouseUp()
        {
            return UnityEngine.Input.touches.Length > 0 &&
                   UnityEngine.Input.touches[0].phase == TouchPhase.Ended;
        }

        public bool GetMouseButton()
        {
            return UnityEngine.Input.touches.Length > 0;
        }

        public float GetMouseMoveX()
        {
            if ( UnityEngine.Input.touchCount <= 0)
            {
                return 0;
            }
            
            var touch = UnityEngine.Input.GetTouch(0);
            if (touch.phase != TouchPhase.Moved)
            {
                return 0;
            }

            return (touch.deltaPosition.x / Screen.width - 0.5f) * 2;
        }
    }
}