using UnityEngine;

public class SlaveTransporter : MonoBehaviour
{
    public bool goingRight = true;
    public bool goingLeft;
    public float speed = 1.8f;
    public GameObject ballTransporter;

    public float positionX = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ballTransporter.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if not in position go in position
        if(positionX > gameObject.transform.position.x)
        {
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
        else if (goingRight){
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0);
            ballTransporter.SetActive(false);
            if (gameObject.transform.position.x > 13)
            {
                goingRight = false;
                goingLeft = true;
            }
        }
        else if (goingLeft)
        {
            ballTransporter.SetActive(true);
            gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0);
            if (gameObject.transform.position.x < 0)
            {

                goingLeft = false;
                goingRight = true;
            }
        }
    }
}
