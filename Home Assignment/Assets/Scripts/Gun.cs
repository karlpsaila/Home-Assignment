using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet bullet;


    public void shoot()
    {
        GameObject rp = Instantiate(bullet.gameObject , transform.position, Quaternion.identity);
    }

}
