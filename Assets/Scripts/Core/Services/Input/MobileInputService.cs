using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Services.Input {
    public sealed class MobileInputService : IInputService
    {
        public bool GetMouseDown() {
            return UnityEngine.Input.touches.Length > 0 &&
                   UnityEngine.Input.touches[0].phase == TouchPhase.Began;
        }
        
        public bool GetMouseUp()
        {
            return UnityEngine.Input.touches.Length > 0 &&
                   UnityEngine.Input.touches[0].phase == TouchPhase.Ended;
        }

        public Vector2 GetMouseMove()
        {
            if ( UnityEngine.Input.touchCount <= 0)
            {
                return Vector2.zero;
            }
            
            var touch = UnityEngine.Input.GetTouch(0);
            return touch.phase == TouchPhase.Moved ? -touch.deltaPosition : Vector2.zero;
        }
    }
}