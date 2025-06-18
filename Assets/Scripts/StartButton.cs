using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject difficulty;
    public static bool first = true;
    public GameObject winScreen;
    public GameObject loseScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(first)
        {if(Input.anyKeyDown){
            difficulty.SetActive(true);
            first = false;
            gameObject.SetActive(false);
            PyramidPlacer.win = false;
        }}
        else{
            if(PyramidPlacer.win){
                winScreen.SetActive(true);
            }
            else{
                loseScreen.SetActive(true);
            }
        }
    }
}
