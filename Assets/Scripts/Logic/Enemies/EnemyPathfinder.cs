using UnityEngine;

namespace Assets.Scripts.Logic.Enemies
{
    public class EnemyPathfinder
    {
        private Transform _transform;
        private EnemyArea _area;

        public EnemyPathfinder(Transform transform, EnemyArea enemyArea)
        {
            _transform = transform;
            _area = enemyArea;
        }

        public Vector3 FindNewPoint(float distance)
        {
            float randomZ = Random.Range(_area.MinZ, _area.MaxZ);
            float randomX = Random.Range(_area.MinX, _area.MaxX);

            return new Vector3(randomX, _transform.position.y, randomZ);
        }

        //public void GenerateWalkPoint()
        //{

        //    Mathf.Min(Mathf.Abs(_area.MaxX - _transform.position.x),Mathf.Abs(_area.MinX - _transform.position.x));
        //    Mathf.Min(Mathf.Abs(_area.MaxZ - _transform.position.z),Mathf.Abs(_area.MinZ - _transform.position.z));

        //}

        //private void SearchWalkPoint()
        //{

            
        //}
    }
}
