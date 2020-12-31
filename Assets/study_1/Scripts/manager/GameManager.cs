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

    public int moveX, moveY;

    Button upButton, downButton, leftButton, rightButton;


    // Start is called before the first frame update
    public virtual void Start()
    {

        gameManager = this.gameObject;
        moveX = 5; moveY = 8;

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
