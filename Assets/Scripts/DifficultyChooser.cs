using UnityEngine;

public class DifficultyChooser : MonoBehaviour
{
    public GameObject conv;
    public GameObject back;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            PyramidPlacer.pyramidSize = 6;
            Timer.timeLeft = 180;
            conv.SetActive(true);
            back.SetActive(false);
            gameObject.SetActive(false);

        }
        if(Input.GetKeyDown(KeyCode.D)){
            PyramidPlacer.pyramidSize = 10;
            Timer.timeLeft = 240;
            conv.SetActive(true);
            back.SetActive(false);
            gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.H)){
            PyramidPlacer.pyramidSize = 15;
            Timer.timeLeft = 300;
            conv.SetActive(true);
            back.SetActive(false);
            gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.L)){
            PyramidPlacer.pyramidSize = 21;
            Timer.timeLeft = 360;
            conv.SetActive(true);
            back.SetActive(false);
            gameObject.SetActive(false);
        }

        
    }
}
