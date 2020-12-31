using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : GameManager
{
    int moveX, moveY;
    // 10, 16
    public GameObject[,] miniMap = new GameObject[15, 20];

    public override void Start()
    {
        base.Start();
        moveX = 5; moveY = 8;

        if (blockPrefab == null) Debug.Log("!@#!@#!");
        miniMap[GetPlayer.posx + moveX, GetPlayer.posy + moveY] = player;
        miniMap[GetStep.posx + moveX, GetStep.posy + moveY] = step;

        StartCoroutine("instantiateBlocksCoroutine");
    }

    private void InstantiateBlock()
    {
        int x = Random.Range(-5, 6); int y = Random.Range(-8, 9);
        if (miniMap[x + moveX, y + moveY] == null)
        {
            GameObject block = Instantiate(blockPrefab, new Vector3(x, y), Quaternion.identity);
            block GetBlock = block.GetComponent<block>();
            GetBlock.posx = x; GetBlock.posy = y;
            miniMap[x + moveX, y + moveY] = block;
        }
    }

    IEnumerator instantiateBlocksCoroutine()
    {
        while (true)
        {
            InstantiateBlock();
            yield return new WaitForSeconds(3.0f);
        }
    }

}
