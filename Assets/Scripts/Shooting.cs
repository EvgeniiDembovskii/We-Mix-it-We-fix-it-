using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public GameObject shootingPoint;
    public string myKey;
    public float bulletSpeed ;
    public bool GunNotAi;
    public bool GunTriggered;

    private float TimeBTWShots;
    public float startTimeBtwShots;
    public int GunDamage;


    private void Awake()
    {
        bulletSpeed = 0.3f;
        GunNotAi = true;
        TimeBTWShots = startTimeBtwShots;
    }
    void Update()
    {
        if (Input.GetKeyDown(myKey)&& GunNotAi && TimeBTWShots <= 0)
        {
            Shoot();
            TimeBTWShots = startTimeBtwShots;
        }
        else if ( GunNotAi == false && GunTriggered && TimeBTWShots <=0)
        {
            bulletSpeed = 0.15f;

            Shoot();
            TimeBTWShots = startTimeBtwShots;
        }else
        {
            TimeBTWShots -= Time.deltaTime;
        }
    }


    void Shoot()
    {
        
        GameObject Newbullet = Instantiate(bullet, shootingPoint.transform.position, transform.rotation);
        Rigidbody2D rb = Newbullet.GetComponent<Rigidbody2D>();
        BulletScript bulletProperty = Newbullet.GetComponent<BulletScript>();
        bulletProperty.damage = GunDamage;
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
        }
    }

}
