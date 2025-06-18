using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public Collider2D myCollider2D;
    public Collider2D sand;
    public float speed = 2;
    public static bool haveClay;
    public GameObject clay;
    public Camera cam;

    public static bool left;
    public static bool right;

    public GameObject ballTransporter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0);
            left = true;
            right = false;
            ballTransporter.SetActive(true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0);
            right = true;
            left = false;
            ballTransporter.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && myCollider2D.IsTouching(sand))
        {
            myRigidBody.linearVelocityY = 2.5f;
        }
        clay.SetActive(haveClay);

        if (gameObject.transform.position.x > 5)
        {
            cam.transform.position = new Vector3(13, 1.5f, -10);
        }
        else if (gameObject.transform.position.x < -22)
        {
            cam.transform.position = new Vector3(-29, 1.5f, -10);
        }
        else if (gameObject.transform.position.x < -7.2)
        {
            cam.transform.position = new Vector3(-15, 1.5f, -10);
        }
        else
        {
            cam.transform.position = new Vector3(-1, 1.5f, -10);
        }
    }
}
