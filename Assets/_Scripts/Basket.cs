using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Basket : MonoBehaviour
{

    public Text scoreText;
    public static int score = 0;
    public float gravity = 9.8f;
    public GameObject appleFX;
    public GameObject gappleFX;

    public bool go = false;

    // Use this for initialization
    void Start()
    {
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition; // 1
        // The Camera's z position sets the how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z; // 2
        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); // 3
        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

        scoreText.text = "SCORE: " + score;
    }

    public void gameOver()
    {
        score = 0;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.tag == "GApple")
        {
            score += 500;
            GameObject.Find("highScoreText").GetComponent<highScore>().score = score;
            var gFX = Instantiate(gappleFX, collidedWith.transform.position, collidedWith.transform.rotation) as GameObject;
            Destroy(gFX.gameObject, 1.35f);
            Destroy(collidedWith);
        }

        if (collidedWith.tag == "Apple")
        {
            var FX = Instantiate(appleFX, collidedWith.transform.position, collidedWith.transform.rotation) as GameObject;
            Destroy(FX.gameObject, 1.35f);

            if (GameObject.Find("AppleTree").GetComponent<AppleTree>().speed < 13)
                GameObject.Find("AppleTree").GetComponent<AppleTree>().speed *= 1.005f;

            if (gravity < 20)
                gravity += 0.25f;

            score += 100;



            GameObject.Find("highScoreText").GetComponent<highScore>().score = score;

            Destroy(collidedWith);
        }


    }

}