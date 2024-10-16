using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Services.Input {
    public sealed class DesktopInputService : IInputService
    {
        public bool GetMouseButtonDown()
        {
            return UnityEngine.Input.GetMouseButtonDown(0);
        }

        public bool GetMouseButton()
        {
            return UnityEngine.Input.GetMouseButton(0);
        }

        public float GetMouseMoveX()
        {
            return UnityEngine.Input.GetAxis("Mouse X");
        }
    }
}