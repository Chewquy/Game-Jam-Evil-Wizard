using UnityEngine;

public class AnimationHandlerCollector : MonoBehaviour
{
    public Sprite[] mining;
    public float timer = 0f;
    private int currentPhase = 0;
    private int totalPhases;
    public float phaseDuration;
    public ClaySlaveCollector time;

    SpriteRenderer self;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        self = gameObject.GetComponent<SpriteRenderer>();

        totalPhases = mining.Length;
        phaseDuration = time.clickPerSecond / totalPhases;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= phaseDuration)
        {
            timer -= phaseDuration; // Keep leftover time for precision

            self.sprite = mining[currentPhase];
            self.flipX = false;

            currentPhase = (currentPhase + 1) % totalPhases;
        }
    }

}
