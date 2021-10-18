using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipControl : MonoBehaviour
{

    public float rotSpeed = 180.0f, ySpeed = 1.0f;
    public float xLimit = 11.0f, yLimit = 6.8f;

    private float playerRot;
    private float xPos, yPos;

    //15/10
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        // Asginar mi rotaci�n z actual a playerRot
        playerRot = transform.eulerAngles.z; // Atenci�n: transform.rotation.z no funcionar�
    }

    // Update is called once per frame
    void Update()
    {

        // Rotamons la nave en funci�n de rotSpeed y el input del usuario
        playerRot -= rotSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;

        // Actualizamos la rotaci�n de la nave
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, playerRot); // Atenci�n: No new Vector3


        // EJERCICIO: Mover la nave adelante y atr�s utilizando transform.up, ySpeed, Input.GetAxis
        transform.position += Input.GetAxis("Vertical") * Time.deltaTime * ySpeed * transform.up;


        // Aplicamos el control de l�mites
        LimitsControl();
    }

    //15/10
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void LimitsControl()
    {
        // Obtenemos xPos e yPos a partir de la posici�n real
        xPos = transform.position.x;
        yPos = transform.position.y;


        if (xPos > xLimit) xPos = -xLimit;
        else if (xPos < -xLimit) xPos = xLimit;

        if (yPos > yLimit) yPos = -yLimit;
        else if (yPos < -yLimit) yPos = yLimit;

        // Aplicamos de nuevo xPos e yPos a la posici�n real
        transform.position = new Vector3(xPos, yPos, 0.0f);
   
    }
}
