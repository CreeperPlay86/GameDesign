using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    private Camera fpsCam;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;

    public ParticleSystem muzzleFlash;


    private float nextTimeToFire = 0f;

    void Start()
    {

        fpsCam = Camera.main;
        if (currentAmmo == -1)
            currentAmmo = maxAmmo;   
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo <= -1)
        {
            Reload();
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Reload()
    {
        Debug.Log("Reloading...");
        currentAmmo = maxAmmo;
    }
                      
    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        Debug.DrawLine(fpsCam.transform.position, fpsCam.transform.forward * range,Color.red);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
