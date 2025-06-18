using UnityEngine;

public class WinConv : MonoBehaviour
{
    float timer = 0;
    public GameObject start;
    public GameObject title;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        start.SetActive(false);
        title.SetActive(false);

        if(timer >= 5){
            
            start.SetActive(true);
            title.SetActive(true);
            StartButton.first=true;
            gameObject.SetActive(false);
        }
    }
}
