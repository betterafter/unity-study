﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Sprite[] dirSprites = new Sprite[3];

    // 0 : 위 1 : 아래 2 : 왼쪽 3 : 오른쪽
    public GameObject[] collideBlock = new GameObject[4];

    public int posx, posy;


    public void init()
    {
        // 처음 위치 설정
        posx = 0; posy = 0;
        this.gameObject.transform.position = new Vector3(posx, posy, 0);

        // Resources.Load : Resources 라는 폴더 안의 데이터를 가져올 때 사용. Resources 폴더는 유니티에서 지정한 특수한 폴더 이름이며, 사용자가 폴더를 직접 만들어서 사용하면 된다.
        // 불러올 자료의 경로는 Resources 하위 폴더부터 경로를 설정하며, 확장자는 붙이면 안된다.
        dirSprites[0] = Resources.Load<Sprite>("Images/frontidle");
        dirSprites[1] = Resources.Load<Sprite>("Images/backidle");
        dirSprites[2] = Resources.Load<Sprite>("Images/player");


        // Atlas 이미지의 경우에는 모든 조각들을 불러오는 방식이 조금 다른데 (위의 frontidle과 backidle도 아틀라스 이미지다. 다만 위와 같이 아틀라스 이미지 이름을 경로로써 불러온다면 맨처음의 조각 이미지를 가져오게 된다.)
        // Aprites 폴더 안에 Atlas_Sample 이라는 파일이 존재하면, 
        // Sprite[] sprites = Resources.LoadAll<Sprite>("Images/frontidle");
        // 와 같이 REsources.LoadAll로 전부 불러오면 된다. 
        // sprites 배열을 public으로 지정하고 inspector 창에서 확인해보도록 하자.
       
    }

    public void move(string direction)
    {
        // 보고 있는 방향이 다르면 sprite를 각각 다르게 설정
        if (direction.Equals("up"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dirSprites[1];
            if (collideBlock[0] != null)
                collideBlock[0].GetComponent<block>().move(0, 1);

        }
        else if (direction.Equals("down"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dirSprites[0];
            if (collideBlock[1] != null)
                collideBlock[1].GetComponent<block>().move(0, -1);
        }

        // left와 right에서 gameObject.transform.localScale이 나오는데, inspector 창에서 직접 수치를 바꾸면서 확인해보자. (스프라이트가 뒤집힘)
        else if (direction.Equals("left"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dirSprites[2];
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            if (collideBlock[2] != null)
                collideBlock[2].GetComponent<block>().move(-1, 0);
        }
        else if (direction.Equals("right"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dirSprites[2];
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            if (collideBlock[3] != null)
                collideBlock[3].GetComponent<block>().move(1, 0);
        }
        this.gameObject.transform.position = new Vector3(posx, posy, 0);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Block"))
        {
            GameObject colBlock = collision.gameObject;
            block GetBlock = colBlock.GetComponent<block>();
            // 블록이 위쪽에 있을 경우
            if (posy == GetBlock.posy - 1 && posx == GetBlock.posx) collideBlock[0] = colBlock;
            // 블록이 아래쪽에 있을 경우
            else if (posy == GetBlock.posy + 1 && posx == GetBlock.posx) collideBlock[1] = colBlock;
            // 블록이 오른쪽에 있을 경우
            else if (posx == GetBlock.posx - 1 && posy == GetBlock.posy) collideBlock[3] = colBlock;
            // 블록이 왼쪽에 있을 경우
            else if (posx == GetBlock.posx + 1 && posy == GetBlock.posy) collideBlock[2] = colBlock;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Block"))
        {
            GameObject colBlock = collision.gameObject;
            block GetBlock = colBlock.GetComponent<block>();
           

            // 블록이 위쪽에 있을 경우
            if (collideBlock[0] == colBlock && posy < GetBlock.posy) collideBlock[0] = null;
            // 블록이 아래쪽에 있을 경우
            else if (collideBlock[1] == colBlock && posy > GetBlock.posy) collideBlock[1] = null;
            // 블록이 오른쪽에 있을 경우
            else if (collideBlock[3] == colBlock && posx < GetBlock.posx) collideBlock[3] = null;
            // 블록이 왼쪽에 있을 경우
            else if (collideBlock[2] == colBlock && posx > GetBlock.posx) collideBlock[2] = null;
        }
    }

}