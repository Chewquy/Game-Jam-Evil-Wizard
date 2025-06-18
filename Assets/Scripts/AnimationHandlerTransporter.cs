using UnityEngine;

public class AnimationHandlerTransporter : MonoBehaviour
{
    public Sprite[] walking;
    public SpriteRenderer self;
    public SlaveTransporter direction;

    public float timer = 0f;
    private int currentPhase = 0;
    private int totalPhases;
    public float phaseDuration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        self = gameObject.GetComponent<SpriteRenderer>();
        direction = gameObject.GetComponent<SlaveTransporter>();

        totalPhases = walking.Length;
        phaseDuration = 1f / totalPhases;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= phaseDuration)
            {
                timer -= phaseDuration; // Keep leftover time for precision

                if (direction.goingRight)
                {
                    self.sprite = walking[currentPhase];
                    self.flipX = false;
                }
                else if (direction.goingLeft)
                {
                    self.sprite = walking[currentPhase];
                    self.flipX = true;
                }

                currentPhase = (currentPhase + 1) % totalPhases;
            }
    }
}
