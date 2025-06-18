using UnityEngine;

public class Flickering : MonoBehaviour
{
    float flickeringTimer = 0;
    public float flickeringTime = 0.5f;
    bool appear = false;

    public float timer = 0;
    public float disapearring = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flickeringTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if (flickeringTimer > flickeringTime){
            flickeringTimer = 0;
            appear = !appear;
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = appear;
        if(timer *disapearring >= 255){
            Destroy(gameObject);
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1/(timer/disapearring));
    }
}
