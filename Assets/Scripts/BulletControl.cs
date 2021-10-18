using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    public float bulletSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Movemos la bala en dirección up a la velocidad bulletSpeed
        transform.position += bulletSpeed * Time.deltaTime * transform.up;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid")) Destroy(gameObject); //CompareTag es igual a (collision.tag == "Asteroid")
    }
}
