using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Services.Input {
    public sealed class DesktopInputService : IInputService
    {
        public bool GetMouseDown()
        {
            return UnityEngine.Input.GetMouseButtonDown(0);
        }
        
        public bool GetMouseUp()
        {            
            return UnityEngine.Input.GetMouseButtonUp(0);
        }

        public Vector2 GetMouseMove()
        {
            var x = UnityEngine.Input.GetAxis("Mouse X");
            var y = UnityEngine.Input.GetAxis("Mouse Y");

            return new Vector2(x, y);
        }
    }
}