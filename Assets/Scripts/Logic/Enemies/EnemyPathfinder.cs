using UnityEngine;

namespace Assets.Scripts.Logic.Enemies
{
    public class EnemyPathfinder
    {
        private Transform _transform;
        private Vector3 _startPosition;
        private EnemyArea _area;

        public EnemyPathfinder(Transform transform, EnemyArea enemyArea)
        {
            _startPosition = transform.position;
            _transform = transform;
            _area = enemyArea;
        }

        public Vector3 FindNewPoint(float distance)
        {
            Vector3 position = GetRoamingPosition(distance);
            float newX = Mathf.Clamp(position.x, _area.MinX, _area.MaxX);
            float newZ = Mathf.Clamp(position.z, _area.MinZ, _area.MaxZ);
            return new Vector3(newX,position.y,newZ);
        }

        private Vector3 GetRoamingPosition(float distance)
        {
           return _transform.position + (GetRandomDirection() * distance);
        }
        private Vector3 GetRandomDirection()
        {
            return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        }
    }
}
