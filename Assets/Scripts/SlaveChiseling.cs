using UnityEngine;

public class SlaveChiseling : MonoBehaviour
{
    public float positionX = 0;
    public float speed = 1.8f;

    float clickPerSecond = 1.5f;
    float timer = 0;
    public LogicKey logicKey;
    public InPlace place;
    bool first = true;

    void Update()
    {
        if (positionX > gameObject.transform.position.x)
        {
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
        else if (!LogicKey.chiseled)
        {
            if (place.stabalizedClay == null) return;
            if (place.stabalizedClay.activeInHierarchy == true)
            {
                if (first)
                {
                    first = false;
                    logicKey.NewKeys();
                }
                if (clickPerSecond < timer)
                {
                    timer = 0;

                    // Increment the step in LogicKey
                    if (logicKey.step < logicKey.steps.Length)
                    {
                        logicKey.steps[logicKey.step] = true; // Mark the current step as completed
                        logicKey.step++; // Move to the next step
                    }
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
    }
}