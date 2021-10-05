using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    // Vamos a crear dos nuevas variables, xSpeed e ySpeed
    public float xSpeed = 1f, ySpeed = 1f;


    // Creamos condición para delimitar el movimiento del asteroide
    public float xLimit = 11.0f, yLimit = 6.8f;


    // Vamos a crear un boleano para el rebote
    public bool asteroidBounce;


    // Vamos a crear dos variables: xPos e yPos
    // Estas variables serán privadas para que no se puedan cambiar desde Unity
    private float xPos, yPos;


    // Start is called before the first frame update
    void Start()
    {
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