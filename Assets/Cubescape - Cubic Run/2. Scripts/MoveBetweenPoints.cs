using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    // public float speed = 0.5f;
    public float speed;
    private Vector3 pointA;
    private Vector3 pointB;
    private float time;

    void Start()
    {
        time = 0.0f;
        speed = Random.Range(0.3f, 0.8f);
    }

    void Update()
    {
        time += Time.deltaTime * speed;

        pointA = new Vector3(transform.position.x, 1.00f, transform.position.z);
        pointB = new Vector3(transform.position.x, 1.50f, transform.position.z);

        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(time, 1));
    }
}
