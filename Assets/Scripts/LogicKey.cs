using System;
using UnityEngine;

public class LogicKey : MonoBehaviour
{
    public KeyHandler[] chr;
    public GameObject[] keys;
    public bool[] steps;
    public int step = 0;
    public GameObject keyPrefab;
    public GameObject[] clayBlock;
    public static bool chiseled = false;
    public static bool inPlace;
    public CircleCollider2D myCollider;

    public void Initiate(CircleCollider2D collider){
        clayBlock = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            clayBlock[i] = GameObject.FindWithTag(String.Format("Step {0}", (i + 1)));
        }
        steps = new bool[] { false, false, false, false, false, false };
        step = 0;
        myCollider = collider;
        keys = new GameObject[6];
        
        myCollider.radius = 0.4f;
        
        chiseled = false;

        NewKeys();
    }

    void Start()
    {
        step = 0;
        chiseled = false;
        // Fix double assignment
        steps = new bool[] { false, false, false, false, false, false };
        chr = new KeyHandler[6];
        keys = new GameObject[6];



    }

    void Update()
    {
        if (inPlace) // Check if player is locked or chiseling slave is active
        {
            if (!chiseled)
            {
                // Process steps as before
                if (!steps[0] && KeyInput(chr[0].randomKey)) { StepChar(); }
                else if (steps[0] && !steps[1] && KeyInput(chr[1].randomKey)) { StepChar(); }
                else if (steps[1] && !steps[2] && KeyInput(chr[2].randomKey)) { StepChar(); myCollider.radius = 0.3f; }
                else if (steps[2] && !steps[3] && KeyInput(chr[3].randomKey)) { StepChar(); myCollider.radius = 0.2f; }
                else if (steps[3] && !steps[4] && KeyInput(chr[4].randomKey)) { StepChar(); }
                else if (steps[4] && !steps[5] && KeyInput(chr[5].randomKey))
                {
                    StepChar();
                    picking.Chiseled(myCollider.gameObject); // Mark chiseling as complete
                    myCollider.enabled = false;
                    chiseled = true;
                }
                else if (Input.anyKeyDown)
                {
                    Reset();
                }
            }
        }
    }
    void Reset()
    {
        for (int i = 0; i < 6; i++)
        {
            if (keys[i] != null)
            {
                Destroy(keys[i]); // Destroy existing keys
            }
            if (clayBlock[i] != null)
            {
                clayBlock[i].SetActive(true);
            }
        }
        Initiate(myCollider);
    }

    public void StepChar()
    {
        Destroy(keys[step]);
        clayBlock[step].SetActive(false);
        steps[step] = true;
        step++;
    }


    // Optimized key input check function
    public bool KeyInput(char lorp)
    {
        switch (lorp)
        {
            case 'A':
                return Input.GetKeyDown(KeyCode.A);
            case 'S':
                return Input.GetKeyDown(KeyCode.S);
            case 'D':
                return Input.GetKeyDown(KeyCode.D);
            case 'F':
                return Input.GetKeyDown(KeyCode.F);
            case 'G':
                return Input.GetKeyDown(KeyCode.G);
            case 'H':
                return Input.GetKeyDown(KeyCode.H);
            case 'J':
                return Input.GetKeyDown(KeyCode.J);
            case 'K':
                return Input.GetKeyDown(KeyCode.K);
            case 'L':
                return Input.GetKeyDown(KeyCode.L);
            default:
                return Input.anyKeyDown;
        }
    }

    public void NewKeys()
    {
        
        keys = new GameObject[6];
        keys[0] = Instantiate(keyPrefab, new Vector3(-1, 3), new Quaternion(0, 0, 0, 0));
        keys[1] = Instantiate(keyPrefab, new Vector3(0, 3), new Quaternion(0, 0, 0, 0));
        keys[2] = Instantiate(keyPrefab, new Vector3(1, 3), new Quaternion(0, 0, 0, 0));
        keys[3] = Instantiate(keyPrefab, new Vector3(-1, 2), new Quaternion(0, 0, 0, 0));
        keys[4] = Instantiate(keyPrefab, new Vector3(0, 2), new Quaternion(0, 0, 0, 0));
        keys[5] = Instantiate(keyPrefab, new Vector3(1, 2), new Quaternion(0, 0, 0, 0));
        chr = new KeyHandler[6];
        for (int i = 0; i < keys.Length; i++)
        {
            chr[i] = keys[i].GetComponent<KeyHandler>();
        }
    }

    public void ResetLogicKey()
    {
        chiseled = false;
        steps = new bool[] { false, false, false, false, false, false };
        step = 0;
        chiseled = false;
        inPlace = false;

        if (keys != null)
        {
            foreach (var key in keys)
            {
                if (key != null)
                {
                    Destroy(key); // Destroy existing keys
                }
            }
        }
        keys = new GameObject[6]; // Reset the keys array

        if (clayBlock != null)
        {
            foreach (var block in clayBlock)
            {
                if (block != null)
                {
                    Destroy(block); // Destroy existing clay blocks
                }
            }
        }
        chr = new KeyHandler[6]; // Reset the clayBlock array
    }
}
