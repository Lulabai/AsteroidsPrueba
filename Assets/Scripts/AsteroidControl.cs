using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    // Vamos a crear dos nuevas variables, xSpeed e ySpeed
    public float xSpeed = 1f, ySpeed = 1f;

    //15/10
    public bool randomSpeed;


    // Creamos condici�n para delimitar el movimiento del asteroide
    public float xLimit = 11.0f, yLimit = 6.8f;

    // Vamos a crear un boleano para el rebote
    public bool asteroidBounce;


    // 15/10 
    public bool createChildren;
    public GameObject theChildren;
    public GameObject explosion;
    public int energy = 3;

    // Vamos a crear dos variables: xPos e yPos
    // Estas variables ser�n privadas para que no se puedan cambiar desde Unity
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

    // 15/10 colisiones

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Me han dado, el culpable es " + collision.tag);

        //Si la colisi�n es con una bala, generamos una explosi�n y destruimos el asteroide
        if(collision.CompareTag("PlayerBullet"))
        {

            print(energy);
            //Reducimos la energia, y si es menor o igual a 0, explotamos:
            energy--; //Es lo mismo que energy -=1;

            if(energy <= 0)
            {
                //EJERCICIO: Crear dos asteroides m�s peque�os. Si el asteroide es peque�o, no crear nada
                if(createChildren)
                {

                    GameObject meteor1 = Instantiate(theChildren, transform.position, transform.rotation);
                    GameObject meteor2 = Instantiate(theChildren, transform.position, transform.rotation);

                    // Movemos la posicion del segundo asteroide en relaci�n a la posici�n del primero
                    meteor2.transform.Translate(transform.position.x+5, transform.position.y+5, transform.position.z);
                }

                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
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