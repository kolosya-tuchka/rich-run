using Configs;
using Game.Player;
using UnityEngine;

namespace Game.Pickups
{
    public class Alcohol : Pickup
    {
        public override void Init(LevelConfig levelConfig)
        {
            _points = levelConfig.AlcoholPoints;
        }

        protected override void Collect(PointsController pointsController)
        {
            pointsController.Take(_points);
        }
    }
}
