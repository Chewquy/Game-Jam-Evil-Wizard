using System;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
    TextMeshProUGUI selfText;
    String text;

    public static int points = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selfText = gameObject.GetComponent<TextMeshProUGUI>();
        text = "Power Points :\n";
    }

    // Update is called once per frame
    void Update()
    {
        selfText.text = text + points;
    }
}
