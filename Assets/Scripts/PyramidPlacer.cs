using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PyramidPlacer : MonoBehaviour
{
    public int[] triangularValues = new int[] { 1, 3, 6, 10, 15, 21 };
    public GameObject blockPrefab;
    public static int pyramidSize = 3;
    public GameObject[] placeHolder;
    public Collider2D myCollider;
    public SlavePlacer slave;

    public static bool win = false;

    float xBlock;
    float yBlock;
    public static int pyramidBlockCounter;
    bool pyramidBuilt = false; // <-- New: flag to prevent rebuilding

    void Start()
    {
        xBlock = blockPrefab.transform.localScale.x;
        yBlock = blockPrefab.transform.localScale.y;

        if (placeHolder == null || placeHolder.Length == 0)
        {
            BuildPyramid(); // Only build if placeholders are missing
        }
        else
        {
            pyramidBuilt = true; // Already built
        }
    }

    void BuildPyramid()
    {
        if (!CheckingTriangle(pyramidSize))
        {
            throw new System.Exception("Not a pyramid number");
        }

        placeHolder = new GameObject[pyramidSize];
        int height = 0;
        int counting = 0;
        int throwAway = pyramidSize;

        if (pyramidBlockCounter == 0)
        {
            pyramidBlockCounter = pyramidSize;
        }

        while (throwAway != 0)
        {
            counting++;
            throwAway -= counting;
            height++;
        }

        bool first = true;
        float precedent = 0;
        float newLayer = -15;
        counting = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                GameObject useful = Instantiate(blockPrefab, new Vector3(first ? newLayer - xBlock / 2 : (precedent + xBlock), (height - i) * yBlock - 0.92f), Quaternion.identity, this.transform);
                precedent = useful.transform.position.x;
                placeHolder[counting] = useful;
                counting++;

                if (first)
                {
                    newLayer = useful.transform.position.x;
                }
                first = false;
            }
            first = true;
        }

        for (int i = 0; i < PyramidPlacer.pyramidBlockCounter; i++)
        {
            placeHolder[i].SetActive(false);
        }

        pyramidBuilt = true;
    }

    void Update()
    {
        if (!pyramidBuilt) return;

        if (movement.haveClay && myCollider.IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Placer(GameObject.FindGameObjectWithTag("Player"));
            }
        }
    }

    public void Placer(GameObject person)
    {
        
        if (PyramidPlacer.pyramidBlockCounter > 0)
        {
            if (person.GetComponent<SlavePlacer>() != null)
            {
                slave.haveClay = false;
            }
            else
            {
                movement.haveClay = false;
            }

            placeHolder[PyramidPlacer.pyramidBlockCounter - 1].SetActive(true);
            PyramidPlacer.pyramidBlockCounter--;
            Point.points++;


            if (PyramidPlacer.pyramidBlockCounter == 0)
            {
                // Reset all components for the next cycle
                GameObject.FindAnyObjectByType<InPlace>().ResetInPlace();
                GameObject.FindAnyObjectByType<LogicKey>().ResetLogicKey();
                ResetPyramidPlacer();
                win = true;
                Point.points = 0;
                SceneManager.LoadScene("StartUpScreen");
            }
        }
    }
    bool CheckingTriangle(int number)
    {
        for (int i = 0; i < triangularValues.Length; i++)
        {
            if (number == triangularValues[i])
            {
                return true;
            }
        }
        return false;
    }

    public void ResetPyramidPlacer()
    {
        pyramidBuilt = false;
        pyramidBlockCounter = 0;
        foreach (var block in placeHolder)
        {
            if (block != null)
            {
                Destroy(block);
            }
        }
        placeHolder = null;
    }
}
