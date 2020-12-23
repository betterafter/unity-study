using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step : MonoBehaviour
{
    public int posx = 5, posy = 0;
    public Sprite[] steps = new Sprite[2];

    public void init()
    {
        posx = 5; posy = 0;
        this.gameObject.transform.position = new Vector3(posx, posy, 0);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Block"))
        {
            Debug.Log("!!!!!!!!!!!!");
            GameObject block = collision.gameObject;
            block GetBlock = block.GetComponent<block>();
            Debug.Log(GetBlock.posx + ", " + GetBlock.posy + ", " + posx + ", " + posy);
            if(GetBlock.posx == posx && GetBlock.posy == posy)
                this.gameObject.GetComponent<SpriteRenderer>().sprite = steps[1];
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Block"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = steps[0];
        }
    }
}
