using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMoveManager : GameManager
{
    bool isLeftPressed, isRightPressed, isUpPressed, isDownPressed;
    MapManager mapManager;
    string currentDirection;

    public override void Start()
    {
        base.Start();
        mapManager = gameManager.GetComponent<MapManager>();
        isLeftPressed = false; isRightPressed = false; isUpPressed = false; isDownPressed = false;
    }

    public void Update()
    {
         if (isLeftPressed)
        {
            GetPlayer.moveWay();
            if (isMoved())
            {
                GetPlayer.targetPosition = new Vector3(GetPlayer.posx - 1, GetPlayer.posy);
                GetPlayer.blockMove("left");
            }
        }
        else if (isRightPressed)
        {
            GetPlayer.moveWay();
            if (isMoved())
            {
                GetPlayer.targetPosition = new Vector3(GetPlayer.posx + 1, GetPlayer.posy);
                GetPlayer.blockMove("right");
            }
        }
        else if (isUpPressed)
        {
            GetPlayer.moveWay();
            if (isMoved())
            {
                GetPlayer.targetPosition = new Vector3(GetPlayer.posx, GetPlayer.posy + 1);
                GetPlayer.blockMove("up");
            }
        }
        else if (isDownPressed)
        {
            GetPlayer.moveWay();
            if (isMoved())
            {
                GetPlayer.targetPosition = new Vector3(GetPlayer.posx, GetPlayer.posy - 1);
                GetPlayer.blockMove("down");
            }
        }
        else GetPlayer.resetPosition();
    }

    public bool isMoved()
    {
        if (currentDirection.Equals("left"))
        {
            if ((mapManager.miniMap[GetPlayer.posx - 2 + moveX, GetPlayer.posy + moveY] == null
                || mapManager.miniMap[GetPlayer.posx - 1 + moveX, GetPlayer.posy + moveY] == null)) return true;
            else return false;
        }

        else if (currentDirection.Equals("right"))
        {
            if ((mapManager.miniMap[GetPlayer.posx + 2 + moveX, GetPlayer.posy + moveY] == null
                || mapManager.miniMap[GetPlayer.posx + 1 + moveX, GetPlayer.posy + moveY] == null)) return true;
            else return false;
        }

        else if (currentDirection.Equals("up"))
        {
            if ((mapManager.miniMap[GetPlayer.posx + moveX, GetPlayer.posy + 2 + moveY] == null
                || mapManager.miniMap[GetPlayer.posx + moveX, GetPlayer.posy + 1 + moveY] == null)) return true;
            else return false;
        }

        else if (currentDirection.Equals("down"))
        {
            if ((mapManager.miniMap[GetPlayer.posx + moveX, GetPlayer.posy - 2 + moveY] == null
                || mapManager.miniMap[GetPlayer.posx + moveX, GetPlayer.posy - 1 + moveY] == null)) return true;
            else return false;
        }
        else return true;
    }


    public void onLeftClickDown()
    {
        isLeftPressed = true;
        currentDirection = "left";
    }

    public void onLeftClickUp()
    {
        isLeftPressed = false;
    }


    public void onRightClickDown()
    {
        isRightPressed = true;
        currentDirection = "right";
    }

    public void onRightClickUp()
    {
        isRightPressed = false;
    }


    public void onUpClickDown()
    {
        isUpPressed = true;
        currentDirection = "up";
    }

    public void onUpClickUp()
    {
        isUpPressed = false;
    }


    public void onDownClickDown()
    {
        isDownPressed = true;
        currentDirection = "down";
    }

    public void onDownClickUp()
    {
        isDownPressed = false;
    }
}
