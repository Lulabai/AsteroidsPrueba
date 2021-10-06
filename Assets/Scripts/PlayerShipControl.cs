using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipControl : MonoBehaviour
{

    public float xSpeed = 1.0f, ySpeed = 1.0f;

    private float xPos, yPos;

    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        // Cambiamos xPos e yPos en función del input del usuario y la velocidad
        
        xPos += Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        yPos += Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;

        

 
            print("Posiciones");
            Debug.Log(xPos);
            Debug.Log(yPos);
       

        // Aplicar xPos e yPos a la posición de la nave
        transform.position = new Vector3(xPos, yPos, 0.0f);

    }
   
}
