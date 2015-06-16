using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour
{
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves in meters/second
    public float speed = 1f;
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;
    // Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    public float[] dropTimes;

    void Start()
    {
        // Dropping apples every second
        //InvokeRepeating("DropApple", 2,dropTimes[Random.Range(0,6)]);
        //InvokeRepeating("DropApple", 2, secondsBetweenAppleDrops);
        StartCoroutine(dropApple());
    }

    IEnumerator dropApple()
    {
        while(true)
        {
        yield return new WaitForSeconds(dropTimes[Random.Range(0,6)]);
        DropApple();
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
        apple.GetComponent<Rigidbody>().AddRelativeForce(0, 5, 0, ForceMode.Impulse);
    }

    void Update()
    {
        // Basic Movement
        // Changing Direction
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

}