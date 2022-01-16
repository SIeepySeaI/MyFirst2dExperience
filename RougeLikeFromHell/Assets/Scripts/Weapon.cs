using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject projectilePrefab;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //спавним стрелочку на стреляющей точке
        Instantiate(projectilePrefab,shootingPoint.position,shootingPoint.rotation);
    }
}
