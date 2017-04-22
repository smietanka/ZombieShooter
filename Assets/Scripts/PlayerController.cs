using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fireRate;
    public GunController theGun;
    public float speed = 10f;


    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Fire();
        Moving(x, y);
        Turning();
    }
    void Fire()
    { 
        if (Input.GetButton("Fire1")) theGun.isFiring = true;
        else theGun.isFiring = false;
    }
    void Moving(float x, float y)
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(x * speed, y * speed);
        anim.SetFloat("speed", Mathf.Abs((x + y) * 100));
    }
    void Turning()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
}
