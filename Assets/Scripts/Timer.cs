using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI selfText;
    String text;

    public static float timer = 0;
    public static int timeLeft = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selfText = gameObject.GetComponent<TextMeshProUGUI>();
        text = "Time Left :\n";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((int)timer >= 1){
            timeLeft -= 1;
            timer = 0;
        }
        
        if(timeLeft <= 15){
            selfText.color = new Color(1f/timeLeft+0.5f, 0, 0);
        }
        selfText.text = text + timeLeft;

        if(timeLeft <= 0){
            Point.points = 0;
            SceneManager.LoadScene("StartUpScreen");
        }

    }
}
