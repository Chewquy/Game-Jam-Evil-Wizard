using UnityEngine;
using UnityEngine.SceneManagement;

public class Conversation : MonoBehaviour
{
    public GameObject[] text;
    int counter = 0;
    float timer = 0;
    bool invoking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.anyKeyDown)
        {
            counter++;
        }

        switch (counter)
        {
            case 0:
                break;
            case 1:
                text[0].SetActive(true);
                break;
            case 2:
                text[0].SetActive(false);
                text[1].SetActive(true);
                break;
            case 3:
                text[1].SetActive(false);
                text[2].SetActive(true);
                break;
            case 4:
                text[2].SetActive(false);
                text[3].SetActive(true);
                break;
            case 5:
                text[3].SetActive(false);
                text[4].SetActive(true);
                break;
            default:
                text[4].SetActive(false);
                AnimationHandlerPlayer.isInvoking = true;
                if (!invoking)
                {
                    timer = 0;
                    invoking = true;
                }
                if (timer > 1)
                {
                    SceneManager.LoadScene("Workshop");
                }


                break;
        }
    }
}
