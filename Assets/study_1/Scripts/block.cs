using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{

    public int posx = 0, posy = -2;

    public block(int x, int y)
    {
        posx = x; posy = y;
    }

    public void init()
    {
        // 처음 위치 설정
        posx = 0; posy = -2;
        this.gameObject.transform.position = new Vector3(posx, posy, 0);
    }

    public void move(int x, int y)
    {
        posx += x; posy += y;
        this.gameObject.transform.position = new Vector3(posx, posy, 0);
    }
}
