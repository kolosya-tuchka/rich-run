using Configs;
using Game.Player;
using UnityEngine;

namespace Game.Pickups
{
    public class Money : Pickup
    {
        public override void Init(LevelConfig levelConfig)
        {
            _points = levelConfig.MoneyPoints;
        }

        protected override void Collect(PointsController pointsController)
        {
            pointsController.Add(_points);
        }
    }
}
