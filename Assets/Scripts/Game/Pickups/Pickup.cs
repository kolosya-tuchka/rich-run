using System;
using Configs;
using Game.Player;
using UnityEngine;

namespace Game.Pickups
{
    public abstract class Pickup : MonoBehaviour
    {
        protected int _points;

        public abstract void Init(LevelConfig levelConfig);

        protected void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PointsController pointsController))
            {
                Collect(pointsController);
                Destroy(gameObject);
            }
        }

        protected abstract void Collect(PointsController pointsController);
    }
}
