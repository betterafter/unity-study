using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{

    public int posx, posy;

    public block(int x, int y)
    {
        posx = x; posy = y;
    }


    public void init(int x, int y)
    {
        // 처음 위치 설정
        posx = x; posy = y;
        this.gameObject.transform.position = new Vector3(posx, posy, 0);
    }

    public void init(Vector3 blockTargetPosition)
    {
        // 처음 위치 설정
        posx = (int)blockTargetPosition.x; posy = (int)blockTargetPosition.y;
        this.gameObject.transform.position = blockTargetPosition;
    }

    public void move(int x, int y)
    {
        posx += x; posy += y;
        this.gameObject.transform.position = new Vector3(posx, posy, 0);
    }

    public void move(Vector3 tagetPosition)
    {
        this.gameObject.transform.position = tagetPosition;
    }

}


