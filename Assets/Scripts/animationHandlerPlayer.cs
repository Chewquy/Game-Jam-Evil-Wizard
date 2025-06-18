using Unity.VisualScripting;
using UnityEngine;

public class AnimationHandlerPlayer : MonoBehaviour
{
    public SpriteRenderer player;
    public Sprite[] idle;
    public Sprite[] mining;
    public Sprite[] invoking;

    public static bool isMining = false;
    public static bool isInvoking = false;

    public static float timer = 0f;
    private int currentPhase = 0;
    private int totalPhases;
    public float phaseDuration;

    public bool right = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = gameObject.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement.left){
            right = false;
        }
        timer += Time.deltaTime;

        if (isMining)
        {
            if (Input.GetKey(KeyCode.D) )
            {
                
                player.sprite = mining[1];
            }
            else
            {
                player.sprite = mining[0];
            }
        }
        else if (isInvoking)
        {
            totalPhases = invoking.Length;
            phaseDuration = 1f / totalPhases;
            if (timer >= phaseDuration)
            {
                timer -= phaseDuration; // Keep leftover time for precision

                if (movement.right || right)
                {
                    player.sprite = invoking[currentPhase];
                    player.flipX = false;
                }
                else
                {
                    player.sprite = invoking[currentPhase];
                    player.flipX = true;
                }
                if(currentPhase == totalPhases-1){
                    
                    isInvoking = false;
                }

                currentPhase = (currentPhase + 1) % totalPhases;
                
            }
        }
        else
        {
            totalPhases = idle.Length;
            phaseDuration = 1f / totalPhases;
            if (timer >= phaseDuration)
            {
                timer -= phaseDuration; // Keep leftover time for precision

                if (movement.right || right)
                {
                    player.sprite = idle[currentPhase];
                    player.flipX = false;
                }
                else
                {
                    player.sprite = idle[currentPhase];
                    player.flipX = true;
                }

                currentPhase = (currentPhase + 1) % totalPhases;
            }
        }
    }
}
