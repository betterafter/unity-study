using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    GameObject block;
    player GetPlayer;
    block GetBlock;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        block = GameObject.FindWithTag("Block");

        GetPlayer = player.GetComponent<player>();
        GetBlock = block.GetComponent<block>();
        GetPlayer.init();
        GetBlock.init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetPlayer.posy++;
            GetPlayer.move("up");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetPlayer.posy--;
            GetPlayer.move("down");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetPlayer.posx--;
            GetPlayer.move("left");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetPlayer.posx++;
            GetPlayer.move("right");
        }
        
    }
}
