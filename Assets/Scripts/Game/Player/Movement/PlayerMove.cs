using UnityEngine;

namespace Game.Player.Movement
{
    public abstract class PlayerMove : MonoBehaviour
    {
        public abstract void StartMove();
        public abstract void UpdateMove(float direction);
    }
}