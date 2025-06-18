using UnityEngine;

public class SlavePlacer : MonoBehaviour
{
    public bool goingRight = true;
    public bool goingLeft;
    public float speed = 1.8f;

    public float positionX = 0;
    public float limitRight = 0;
    public float limitLeft = -14;
    public bool haveClay = false;

    public GameObject clayInHand;
    public PyramidPlacer pyramid;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clayInHand.SetActive(haveClay);

        if(positionX < gameObject.transform.position.x)
        {
            gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0);
        }
        else if (goingRight){
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0);
            if (gameObject.transform.position.x > limitRight)
            {
                if(GameObject.FindGameObjectWithTag("PickupClay") != null)
                {
                    GameObject.FindFirstObjectByType<picking>().GetComponent<picking>().PickUpClay(gameObject.tag);
                }
                goingRight = false;
                goingLeft = true;
            }
        }
        else if (goingLeft)
        {
            gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0);
            if (gameObject.transform.position.x < limitLeft)
            {
                if(haveClay){
                    pyramid.Placer((GameObject) gameObject);
                }
                goingLeft = false;
                goingRight = true;
            }
        }
    }
}
