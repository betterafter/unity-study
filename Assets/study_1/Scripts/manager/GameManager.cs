using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    public GameObject blockPrefab;
    public GameObject step;
   

    public player GetPlayer;
    public step GetStep;

    public static Text scoreText;
    public static int score;

    public int moveX, moveY;

    Button upButton, downButton, leftButton, rightButton;


    // Start is called before the first frame update
    public virtual void Start()
    {
        moveX = 10; moveY = 16;
        gameManager = this.gameObject;
        score = 0;

        scoreText = GameObject.Find("scoreText").GetComponent<Text>();

        player = GameObject.FindWithTag("Player");
        step = GameObject.FindWithTag("Step");

        upButton = GameObject.Find("upButton").GetComponent<Button>();
        downButton = GameObject.Find("downButton").GetComponent<Button>();
        leftButton = GameObject.Find("leftButton").GetComponent<Button>();
        rightButton = GameObject.Find("rightButton").GetComponent<Button>();

        GetPlayer = player.GetComponent<player>();
        GetStep = step.GetComponent<step>();

        GetPlayer.init();
        GetStep.init();
    }


    

    private void Update()
    {

    }
}
