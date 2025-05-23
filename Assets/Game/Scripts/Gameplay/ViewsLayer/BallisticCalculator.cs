using UnityEngine;

namespace Game.Scripts.Gameplay.ViewsLayer
{
    public static class BallisticCalculator
    {
        public static Vector3 CalculateTrajectoryVelocity(Vector3 origin, Vector3 target, float t)
        {
            var vx = (target.x - origin.x) / t;
            var vz = (target.z - origin.z) / t;
            var vy = ((target.y - origin.y) - 1.5f * Physics.gravity.y * t * t) / t;
            return new Vector3(vx, vy, vz);
        }
    }
}