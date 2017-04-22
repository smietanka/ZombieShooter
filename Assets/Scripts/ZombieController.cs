using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
    public float speed;
    public GameObject player;
    public ZombieHealth healt;
    private Animator anim;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //transform.LookAt(playerPos);
        var screenPoint = Camera.main.ScreenToWorldPoint(player.transform.position);

        Vector3 difference = screenPoint - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
        anim.SetFloat("speed", Mathf.Abs((player.transform.position.x + player.transform.position.y) * 100));
        if(healt.curHealth<= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Zombie uderzył gracza.");
        }
        if (col.gameObject.tag.Equals("bullet"))
        {
            Debug.Log("Pocisk uderzył zombie.");
            healt.curHealth -= 10;
        }
        
    }
}
