using UnityEngine;

namespace Assets.Scripts.Logic.Enemies.Walker
{
    public class WalkerMover : MonoBehaviour, IMovable
    {
        private void Awake()
        {
            SetStartPosition();
        }

        public bool IsMoving { get; set; }

        public void Move()
        {
            
        }

        private void SetStartPosition()
        {
            GameObject spawnArea = GameObject.FindGameObjectWithTag("SpawnArea");

            float maxX = spawnArea.transform.position.x + spawnArea.transform.localScale.x / 2;
            float minX = spawnArea.transform.position.x - spawnArea.transform.localScale.x / 2;
            float maxZ = spawnArea.transform.position.z + spawnArea.transform.localScale.z / 2;
            float minZ = spawnArea.transform.position.z - spawnArea.transform.localScale.z / 2;

            Vector3 startPosition = new Vector3(Random.Range(minX, maxX), 2, Random.Range(minZ, maxZ));
            transform.position = startPosition;
        }
    }
}
