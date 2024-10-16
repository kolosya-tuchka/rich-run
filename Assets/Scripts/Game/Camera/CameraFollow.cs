using System;
using UnityEngine;

namespace Game.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _followTarget;

        public void Init(Transform followTarget)
        {
            _followTarget = followTarget;
        }

        private void Update()
        {
            transform.position = _followTarget.position;
            transform.rotation = _followTarget.rotation;
        }
    }
}