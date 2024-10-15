using UnityEngine;

namespace Core.Services.Input {
    public interface IInputService
    {
        bool GetMouseDown();
        bool GetMouseUp();
        Vector2 GetMouseMove();
    }
}