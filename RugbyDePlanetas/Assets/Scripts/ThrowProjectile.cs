using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class ThrowProjectile : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float projectileForce = 5f;
    void Start()
    {
        StartCoroutine(Cooldown());
    }
    private GameObject Shoot()
    {
        Vector3 projectilePosition = firePoint.position;
        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(projectilePosition * projectileForce, ForceMode.Impulse);
        return projectile;
    }
    IEnumerator Cooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject ball = Shoot();
            Destroy(ball, 3f);
        }
    }
}
