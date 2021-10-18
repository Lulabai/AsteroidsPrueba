using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    // Vamos a crear dos nuevas variables, xSpeed e ySpeed
    public float xSpeed = 1f, ySpeed = 1f;

    //15/10
    public bool randomSpeed;


    // Creamos condición para delimitar el movimiento del asteroide
    public float xLimit = 11.0f, yLimit = 6.8f;

    // Vamos a crear un boleano para el rebote
    public bool asteroidBounce;


    // 15/10 
    public bool createChildren;
    public GameObject theChildren;
    public GameObject explosion;
    public int energy = 3;

    // Vamos a crear dos variables: xPos e yPos
    // Estas variables serán privadas para que no se puedan cambiar desde Unity
    private float xPos, yPos;


    // Start is called before the first frame update
    void Start()
    {
        //Si es necesario asignamos una velocidad aleatoria
        if (randomSpeed)
        {
            xSpeed = Random.Range(-xSpeed, xSpeed);
            ySpeed = Random.Range(-ySpeed, ySpeed);
        }


        //vamos a asignar a xPos mi posición inicial en x, y lo mismo con y
        xPos = transform.position.x;
        yPos = transform.position.y;


        // Si queremos que solo se ejecute una vez el cambio de posición, entonces indicamos en la función de START: transform.position = new Vector3(xPos, yPos, 0.0f);
        // Si no, lo indicaremos también en el UPDATE

    }

    // Update is called once per frame
    void Update()
    {

        // Ejercicio: Cambiar en cada frame la posición según xPeed e ySpeed
        xPos += xSpeed * Time.deltaTime; // Es lo mismo que xPos = xPos + xSpeed * Time.deltaTime
        yPos += ySpeed * Time.deltaTime; // Es lo mismo que yPos = yPos + ySpeed * Time.deltaTime

        // Time.deltaTime es una variable corrección de los frames por segundo. Así hace que en todos los ordenadores, independiente de su potencia, funcione a la misma velocidad

        // Decidimos si queremos rebote o control de límites
        if (asteroidBounce) BounceControl();
        else LimitsControl();

        // Aplicamos la nueva posición
        transform.position = new Vector3(xPos, yPos, 0.0f);
    }

    // 15/10 colisiones

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Me han dado, el culpable es " + collision.tag);

        //Si la colisión es con una bala, generamos una explosión y destruimos el asteroide
        if(collision.CompareTag("PlayerBullet"))
        {

            print(energy);
            //Reducimos la energia, y si es menor o igual a 0, explotamos:
            energy--; //Es lo mismo que energy -=1;

            if(energy <= 0)
            {
                //EJERCICIO: Crear dos asteroides más pequeños. Si el asteroide es pequeño, no crear nada
                if(createChildren)
                {

                    GameObject meteor1 = Instantiate(theChildren, transform.position, transform.rotation);
                    GameObject meteor2 = Instantiate(theChildren, transform.position, transform.rotation);

                    // Movemos la posicion del segundo asteroide en relación a la posición del primero
                    meteor2.transform.Translate(transform.position.x+5, transform.position.y+5, transform.position.z);
                }

                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    // Creamos una nueva función que se llama LimitsControl
    void LimitsControl()
    {
        // Control de límites en X (en CLASS hemos creado variable pública):
        if (xPos > xLimit)
        {
            xPos = -xLimit;
        }
        else if (xPos < -xLimit)
        {
            xPos = xLimit;
        }

        /* Esto es lo mismo:
           if (xPos > xLimit)  
              xPos = -xLimit; 
           else if (xPos < -xLimit) 
                   xPos = xLimit; */

        /* También se pueden poner en una línea:
           if (xPos > xLimit)  xPos = -xLimit; 
           else if (xPos < -xLimit) xPos = xLimit; */

        if (yPos > yLimit)
        {
            yPos = -yLimit;
        }
        else if (yPos < -yLimit)
        {
            yPos = yLimit;
        }

    }

    // Creamos una nueva función para el rebote:

    void BounceControl()
    {

        // Si el asteroide se sale de límites, rebota

        if (xPos > xLimit) xSpeed = -Mathf.Abs(xSpeed);
        if (xPos < -xLimit) xSpeed = Mathf.Abs(xSpeed);


        // Para y, otra forma que también es correcta:

        if (yPos > yLimit)
        {

            if (ySpeed > 0.0f) ySpeed = -ySpeed;

        }

        if (yPos < -yLimit)
        {

            if (ySpeed < 0.0f) ySpeed = -ySpeed;
        
        }

    }

}