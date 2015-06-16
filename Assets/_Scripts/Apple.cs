using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour
{

    public static float bottomY = -8f;

    void Update()
    {
        transform.Rotate(Vector3.up * 2);

        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

        // Get a reference to the ApplePicker component of Main Camera
        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); // 1
        // Call the public AppleDestroyed() method of apScript
        apScript.AppleDestroyed();

        }
    }

}