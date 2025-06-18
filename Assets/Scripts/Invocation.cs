using UnityEngine;

public class Invocation : MonoBehaviour
{
    public GameObject placer;
    public GameObject transporter;
    public GameObject collector;

    public GameObject placerHolder;
    public GameObject transporterHolder;
    public GameObject collectorHolder;

    public GameObject placerImprover;
    public GameObject transporterImprover;
    public GameObject collectorImprover;

    bool placerAva = true;
    bool transporterAva = true;
    bool collectorAva = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Collider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (placerAva)
                {
                    if (Point.points >= 2)
                    {
                        placer.SetActive(true);
                        placerHolder.SetActive(false);
                        placerAva = false;
                        AnimationHandlerPlayer.isInvoking = true;
                        Point.points -= 2;
                        placerImprover.SetActive(true);
                        
                    }
                }
                else
                {
                    if (Point.points >= 2)
                    {
                        placer.GetComponent<SlavePlacer>().speed += 0.2f;
                        AnimationHandlerPlayer.isInvoking = true;
                        Point.points -= 2;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (transporterAva)
                {
                    if (Point.points >= 1)
                    {
                        transporter.SetActive(true);
                        transporterHolder.SetActive(false);
                        transporterAva = false;
                        AnimationHandlerPlayer.isInvoking = true;
                        Point.points -= 1;
                        transporterImprover.SetActive(true);
                    }
                    
                }
                else
                    {
                        if (Point.points >= 1)
                        {
                            transporter.GetComponent<SlaveTransporter>().speed += 0.2f;
                            AnimationHandlerPlayer.isInvoking = true;
                            Point.points -= 1;
                        }
                    }
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (collectorAva)
                {
                    if (Point.points >= 3)
                    {
                        collector.SetActive(true);
                        collectorHolder.SetActive(false);
                        collectorAva = false;
                        AnimationHandlerPlayer.isInvoking = true;
                        Point.points -= 3;
                        collectorImprover.SetActive(true);
                    }
                    
                }
                else
                    {
                        if (Point.points >= 3)
                        {
                            collector.GetComponent<ClaySlaveCollector>().clickPerSecond -= 0.1f;
                            AnimationHandlerPlayer.isInvoking = true;
                            Point.points -= 3;
                        }
                    }
            }
        }
    }
}
