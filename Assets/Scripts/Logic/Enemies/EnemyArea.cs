using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    public Transform SpawnArea { get; private set; }
    public float MaxX { get; private set; }
    public float MinX { get; private set; }
    public float MaxZ { get; private set; }
    public float MinZ { get; private set; }
    
    private void Awake()
    {
        SetStartPosition();
    }

    private void SetStartPosition()
    {
        SpawnArea = GameObject.FindGameObjectWithTag("SpawnArea").transform;
        MaxX = SpawnArea.transform.position.x + SpawnArea.transform.localScale.x / 2;
        MinX = SpawnArea.transform.position.x - SpawnArea.transform.localScale.x / 2;
        MaxZ = SpawnArea.transform.position.z + SpawnArea.transform.localScale.z / 2;
        MinZ = SpawnArea.transform.position.z - SpawnArea.transform.localScale.z / 2;
        Vector3 startPosition = new Vector3(Random.Range(MinX, MaxX), 2, Random.Range(MinZ, MaxZ));
        transform.position = startPosition;
    }
}
