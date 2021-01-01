using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : GameManager
{
    // 10, 16
    public GameObject[,] miniMap = new GameObject[30, 40];

    public override void Start()
    {
        base.Start();
        
        miniMap[GetPlayer.posx + moveX, GetPlayer.posy + moveY] = player;

        StartCoroutine("instantiateBlocksCoroutine");
    }

    private void InstantiateBlock(int x, int y)
    {
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
            int x = Random.Range(-5, 6); int y = Random.Range(-8, 9);
            if (x == GetStep.posx + moveX && y == GetStep.posy + moveY) continue;
            else InstantiateBlock(x, y);
            yield return new WaitForSeconds(3.0f);
        }
    }

}
