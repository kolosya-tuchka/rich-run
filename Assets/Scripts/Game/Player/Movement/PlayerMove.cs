using UnityEngine;

namespace Game.Player.Movement
{
    public abstract class PlayerMove : MonoBehaviour
    {
        public abstract void StartMove();
        public abstract void StopMove();
        public abstract void UpdateMove(float direction);
        public virtual void Init() {}
    }
}