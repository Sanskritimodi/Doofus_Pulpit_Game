using UnityEngine;

public class PulpitController : MonoBehaviour
{
    public float minLifespan = 2f;
    public float maxLifespan = 5f;
    public float lifespan;
    // Start is called before the first frame update
    void Start()
    {
        lifespan = Random.Range(minLifespan, maxLifespan);
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;

        if (lifespan <= 0)
        {
            Destroy(gameObject); // Destroy the pulpit when the timer runs out
        }

    }
}
