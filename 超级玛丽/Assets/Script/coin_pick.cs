using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_pick : MonoBehaviour {
    public GameObject gb;
    private int Hp=1;

    // Use this for initialization
    void Start () {
        gb.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

    //    private void OnCollisionEnter2D(Collision2D collision)
    //    {
    //        if(haveTri == false)
    //        {
    //            gb.SetActive(true);
    //            haveTri = true;
    //       }
    //   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Hp > 0)
        {
            Hp--;
            // die
            if (Hp <= 0)
            {
                gb.SetActive(true);
                AudioManager.Instance.PlaySound("顶砖石块,壳击墙或火球撞墙");
                GetComponent<Animator>().SetBool("big2", true);
                GetComponent<Animator>().SetBool("Up", true);
            }
        }
    }
}