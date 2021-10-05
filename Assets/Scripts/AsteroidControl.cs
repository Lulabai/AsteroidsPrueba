using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    // Vamos a crear dos nuevas variables, xSpeed e ySpeed
    public float xSpeed = 1f, ySpeed = 1f;


    // Creamos condici�n para delimitar el movimiento del asteroide
    public float xLimit = 11.0f, yLimit = 6.8f;


    // Vamos a crear un boleano para el rebote
    public bool asteroidBounce;


    // Vamos a crear dos variables: xPos e yPos
    // Estas variables ser�n privadas para que no se puedan cambiar desde Unity
    private float xPos, yPos;


    // Start is called before the first frame update
    void Start()
    {
        //vamos a asignar a xPos mi posici�n inicial en x, y lo mismo con y
        xPos = transform.position.x;
        yPos = transform.position.y;


        // Si queremos que solo se ejecute una vez el cambio de posici�n, entonces indicamos en la funci�n de START: transform.position = new Vector3(xPos, yPos, 0.0f);
        // Si no, lo indicaremos tambi�n en el UPDATE

    }

    // Update is called once per frame
    void Update()
    {

        // Ejercicio: Cambiar en cada frame la posici�n seg�n xPeed e ySpeed
        xPos += xSpeed * Time.deltaTime; // Es lo mismo que xPos = xPos + xSpeed * Time.deltaTime
        yPos += ySpeed * Time.deltaTime; // Es lo mismo que yPos = yPos + ySpeed * Time.deltaTime

        // Time.deltaTime es una variable correcci�n de los frames por segundo. As� hace que en todos los ordenadores, independiente de su potencia, funcione a la misma velocidad

        // Decidimos si queremos rebote o control de l�mites
        if (asteroidBounce) BounceControl();
        else LimitsControl();

        // Aplicamos la nueva posici�n
        transform.position = new Vector3(xPos, yPos, 0.0f);
    }

    // Creamos una nueva funci�n que se llama LimitsControl
    void LimitsControl()
    {
        // Control de l�mites en X (en CLASS hemos creado variable p�blica):
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

        /* Tambi�n se pueden poner en una l�nea:
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

    // Creamos una nueva funci�n para el rebote:

    void BounceControl()
    {

        // Si el asteroide se sale de l�mites, rebota

        if (xPos > xLimit) xSpeed = -Mathf.Abs(xSpeed);
        if (xPos < -xLimit) xSpeed = Mathf.Abs(xSpeed);

        
        // Para y, otra forma que tambi�n es correcta:

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