using UnityEngine;

public class ClaySlaveCollector : MonoBehaviour
{
    public ClayCollector clayCollector;
    public float clickPerSecond = 0.5f;
    float timer = 0;
    public float positionX = 14.2f;
    public float speed = 1.8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(positionX > gameObject.transform.position.x)
        {
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
        else if(clickPerSecond < timer){
            timer = 0;
            clayCollector.Collecting(); 
        }
        else{
            timer += Time.deltaTime;
        }
    }
}
