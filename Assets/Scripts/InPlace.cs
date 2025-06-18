using System;
using UnityEngine;

public class InPlace : MonoBehaviour
{
    public LogicKey keyVandam;
    public bool enter = true;
    public GameObject moveableClay;
    public GameObject stabalizedClay;
    public GameObject stabalizedClayPrefab;
    public ClayCollector block;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (moveableClay != null) // Exit if no clay block is assigned
        {
            if (gameObject.GetComponent<Collider2D>().IsTouching(moveableClay.GetComponent<Collider2D>()))
            {
                stabalizedClay = Instantiate(stabalizedClayPrefab, new Vector3(-0.5f, 0.32f, -1), new Quaternion(0, 0, 0, 0)); // Instantiate the stabilized clay prefab
                Destroy(moveableClay); // Destroy the moveable clay
            }
        }
        if (stabalizedClay != null)
        {
            if (enter && stabalizedClay.activeInHierarchy)
            {
                if (playerInPlace())
                {
                    if (Input.GetKeyDown(KeyCode.D)) // Start the minigame when the player presses D
                    {
                        LogicKey.inPlace = true;
                        keyVandam.Initiate(stabalizedClay.GetComponent<CircleCollider2D>());
                        enter = false;
                    }
                }
            }
            else if (!playerInPlace())
            {
                LogicKey.inPlace = false;
                enter = true;
            }
        }
    }

    public static Boolean playerInPlace(){
        return GameObject.FindGameObjectWithTag("Place").GetComponent<Collider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
    }
    public void Assigning(GameObject block)
    {
        if (block != null)
        {
            moveableClay = block; // Assign the new clay block
        }
    }

    public void ResetInPlace()
    { // Log the reset action
        if (moveableClay != null)
        {
            Destroy(moveableClay); // Destroy the moveable clay if it exists
        }
        if (stabalizedClay != null)
        {
            Destroy(stabalizedClay); // Destroy the stabilized clay if it exists
        }
        moveableClay = null; // Reset the reference
        stabalizedClay = null; // Reset the reference
        enter = true; // Reset the state
    }
}
