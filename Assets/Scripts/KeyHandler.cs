
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    public Sprite[] alphabet = new Sprite[9];
    public SpriteRenderer self;
    public char randomKey;
    string chars = "ASDFGHJKL";

    public float timeCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        self = gameObject.GetComponent<SpriteRenderer>();
        randomKey = chars[UnityEngine.Random.Range(0, chars.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        keyHandler(randomKey);
    }

    void keyHandler(char ch){
        //CHoosing the right sprite
        self.sprite = alphabet[charToInt(ch)];
    }

    int charToInt(char ch){
        int result;
        switch(ch){
            case 'A':
            result = 0;
            break;
            case 'S':
            result = 1;
            break;
            case 'D':
            result = 2;
            break;
            case 'F':
            result = 3;
            break;
            case 'G':
            result = 4;
            break;
            case 'H':
            result = 5;
            break;
            case 'J':
            result = 6;
            break;
            case 'K':
            result = 7;
            break;
            case 'L':
            result = 8;
            break;
            default:
            result = 0;
            break;
        }
        return result;
    }
}
