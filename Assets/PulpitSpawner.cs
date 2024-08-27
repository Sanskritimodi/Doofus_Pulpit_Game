using UnityEngine;

public class PulpitSpawner : MonoBehaviour
{
    public GameObject pulpitPrefab;
    public Transform doofusTransform;
    public float spawnThreshold = 1f; // Time left before spawning a new pulpit

    private GameObject lastPulpit;

    void Update()
    {
        if (lastPulpit == null || lastPulpit.GetComponent<PulpitController>().lifespan <= spawnThreshold)
        {
            SpawnNewPulpit();
        }
    }

    void SpawnNewPulpit()
    {
        Vector3 spawnPosition = doofusTransform.position + GetRandomAdjacentPosition();
        lastPulpit = Instantiate(pulpitPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomAdjacentPosition()
    {
        // Randomly select an adjacent position (but not the same position)
        int randomDirection = Random.Range(0, 4);
        switch (randomDirection)
        {
            case 0: return Vector3.forward * 9f;
            case 1: return Vector3.back * 9f;
            case 2: return Vector3.left * 9f;
            case 3: return Vector3.right * 9f;
            default: return Vector3.zero;
        }
    }
}