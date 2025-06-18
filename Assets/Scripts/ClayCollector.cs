using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClayCollector : MonoBehaviour
{
    public GameObject clayBlock;
    public GameObject clayBlockPrefab;
    public Collider2D myCollider;
    public GameObject textDonePrefab;
    public GameObject textDone;
    int counter = 0;
    public InPlace place;
    public int nbOfClick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCollider = gameObject.GetComponent<Collider2D>();

        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationHandlerPlayer.isMining = myCollider.IsTouching(GameObject.FindGameObjectsWithTag("Clay")[1].GetComponent<Collider2D>());
        if (AnimationHandlerPlayer.isMining)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Collecting();
            }
        }
    }

    public void Collecting()
    {
        if (counter == 0 && (clayBlock == null || !clayBlock.activeInHierarchy))
                {
                    clayBlock = Instantiate(clayBlockPrefab, new Vector3(12, 0, 0), Quaternion.identity);
                    clayBlock.transform.localScale = new Vector3(0.4f, 0.4f, 1);
                    clayBlock.SetActive(false);
                    clayBlock.layer = 6;

                    // Assign the new clay block to InPlace
                    if (place != null)
                    {
                        place.Assigning(clayBlock);
                    }
                }
                if (clayBlock.transform.localScale.x < 2)
                {
                    counter++;

                    //Change the size of the clay depending on the amount of clicks
                    switch ((int)(counter / nbOfClick))
                    {
                        case 1:
                            clayBlock.SetActive(true);
                            //Give to In place the GameObject of the clay so it can handle it later

                            break;
                        case 2:
                            clayBlock.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                            break;
                        case 3:
                            clayBlock.transform.localScale = new Vector3(1.2f, 1.2f, 1);
                            break;
                        case 4:
                            clayBlock.transform.localScale = new Vector3(1.6f, 1.6f, 1);
                            break;
                        case 5:
                            clayBlock.transform.localScale = new Vector3(2, 2, 1);
                            clayBlock.layer = 8;
                            place.enabled = true;
                            place.Assigning(clayBlock);
                            counter = 0;
                            break;
                        default:
                            clayBlock.SetActive(false);
                            break;
                    }
                }
                else
                {
                    if (textDone == null)
                    {
                        //Stop message
                        textDone = Instantiate(textDonePrefab, new Vector3(13.5f, 1.25f, 1), new Quaternion(0, 0, 0, 0));

                    }
                }
    }
    public void ResetClayCollector()
    {
        if (clayBlock != null)
        {
            Destroy(clayBlock); // Destroy the existing clay block
        }
        clayBlock = null; // Reset the reference
        counter = 0; // Reset the counter
        place.enabled = false; // Disable the InPlace component
            Destroy(textDone); // Destroy the textDone object if it exists
        textDone = null; // Reset the reference to textDone
    }
}
