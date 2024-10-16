using UnityEngine;

namespace Core.Services.Input {
    public interface IInputService
    {
        bool GetMouseButtonDown();
        bool GetMouseButton();
        float GetMouseMoveX();
    }
}