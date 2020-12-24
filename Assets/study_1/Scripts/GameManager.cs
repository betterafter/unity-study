using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    public GameObject[] block = new GameObject[2];
    GameObject step;
    player GetPlayer;
    block[] GetBlock = new block[2];
    step GetStep;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        block = GameObject.FindGameObjectsWithTag("Block");
        step = GameObject.FindWithTag("Step");

        GetPlayer = player.GetComponent<player>();

        GetBlock[0] = block[0].GetComponent<block>();
        GetBlock[1] = block[1].GetComponent<block>();
        GetStep = step.GetComponent<step>();

        GetPlayer.init();
        GetBlock[0].init(0, -2);
        GetBlock[1].init(1, -2);
        GetStep.init();
    }

    // Update is called once per frame
    void Update()
    {
        //Lerp 기능을 적용하지 않은 캐릭터 이동
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    GetPlayer.posy++;
        //    //GetPlayer.move("up");
        //    GetPlayer.move("up");
        //}
        //else if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    GetPlayer.posy--;
        //    //GetPlayer.move("down");
        //    GetPlayer.move("down");
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    GetPlayer.posx--;
        //    //GetPlayer.move("left");
        //    GetPlayer.move("left");
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    GetPlayer.posx++;
        //    //GetPlayer.move("right");
        //    GetPlayer.move("right");
        //}
        if (Input.GetKeyDown(KeyCode.UpArrow)) GetPlayer.blockMove("up");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetPlayer.targetPosition = new Vector3(GetPlayer.posx, GetPlayer.posy + 1);
            GetPlayer.moveWay();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetPlayer.resetPosition();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) GetPlayer.blockMove("down");
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetPlayer.targetPosition = new Vector3(GetPlayer.posx, GetPlayer.posy - 1);
            GetPlayer.moveWay();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            GetPlayer.resetPosition();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) GetPlayer.blockMove("left");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetPlayer.targetPosition = new Vector3(GetPlayer.posx - 1, GetPlayer.posy);
            GetPlayer.moveWay();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GetPlayer.resetPosition();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) GetPlayer.blockMove("right");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetPlayer.targetPosition = new Vector3(GetPlayer.posx + 1, GetPlayer.posy);
            GetPlayer.moveWay();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetPlayer.resetPosition();
        }

    }

}
