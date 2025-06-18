using System;
using UnityEngine;

public class picking : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InPlace.playerInPlace() && GameObject.FindGameObjectWithTag("PickupClay") != null)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                PickUpClay("Player"); // Call the PickUpClay method when the player presses D
            }
        }
    }
    public void PickUpClay(String tag){
        if(tag.Equals("Player")){
            movement.haveClay = true; // Set the haveClay variable to true when the player presses D
            Destroy(GameObject.FindGameObjectWithTag("PickupClay"));
        }
        else{
            GameObject slave = GameObject.FindGameObjectWithTag(tag);
            slave.GetComponent<SlavePlacer>().haveClay = true;
            Destroy(GameObject.FindGameObjectWithTag("PickupClay"));
        }
    }

    public static void Chiseled(GameObject finishedBlock)
    {
        finishedBlock.tag = "PickupClay"; // Destroy the finished clay block


        var bigSmush = GameObject.FindGameObjectWithTag("BigSmush");
        if (bigSmush != null)
        {
            Destroy(bigSmush); // Change the tag to indicate it can be picked up
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<ClayCollector>().ResetClayCollector(); // Reset the clay collector

    }
}
