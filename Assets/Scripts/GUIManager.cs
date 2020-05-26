using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public Text movesText, scoreText;
    private int moveCounter;
    private int score;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }

    public int MoveCounter
    {
        get { return moveCounter; }
        set
        {
            moveCounter = value;
            movesText.text = "Moves: " + moveCounter;
            if (moveCounter<=0)
            {
                moveCounter=0;
                StartCoroutine(GameOver());
            }
        }
    }

    private IEnumerator GameOver(){
        yield return new WaitUntil(()=>!BoardManager.sharedInstance.isShifting);
        yield return new WaitForSeconds(0.25f);
        print("ÑEEE perdiste");
    }

    public static GUIManager sharedInstance;
    // Start is called before the first frame update
    private void Awake() {
                if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {


        score = 0;
        moveCounter = 1;
        movesText.text = "Moves: " + moveCounter;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
