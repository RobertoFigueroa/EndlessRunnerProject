using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 25.0f;
    private float jumpHeight = 20.0f;
    private float gravity = 1.0f;
    private float yvelocity = 0.0f;
    public Animator animator;
    public float force = 100.0f;
    public float gunRange = 5.0f;
    public Camera fpscam;
    public float damage = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //mejoramos la fuerza del robot

        

        //direccion en la que el jugador siempre va a correr (Vector3)
        Vector3 direction = new Vector3(0, 0, 1);
        //velocidad = dirección * velocidad
        Vector3 velocity = direction * speed;

        //salta al egregarle velocidad al eje y
        //se debe chequear si el jugador puede saltar, en este caso que esté en el suelo
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {

            controller.SimpleMove(new Vector3(-0.1f / Time.deltaTime, 0, 0));
            controller.transform.Find("Robot1").rotation = Quaternion.Euler(0, -15, 0);



        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            controller.SimpleMove(new Vector3(0.1f / Time.deltaTime, 0, 0));
            controller.transform.Find("Robot1").rotation = Quaternion.Euler(0, 15, 0);


        }
        else
        {
            controller.transform.Find("Robot1").rotation = Quaternion.Euler(0, 0, 0);
    
        }
        if (controller.isGrounded)
        {
            animator.SetBool("is_grounded", true);
            //chequera que el al presionar space salte
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yvelocity = jumpHeight;
                animator.SetBool("is_grounded", false);

            }
        }
        else
        {
            //agregamos gravedad para caer
            yvelocity -= gravity;
            //modificamos la variable de la animación
        }
        velocity.y = yvelocity;
        //tomar la velocidad en y e igualarla a la variable local
        controller.Move(velocity * Time.deltaTime);

        //Move (velocidad *time.deltatime)
        controller.Move(velocity * Time.deltaTime);

        if(GameController.health <= 0)
        {
            Loose();
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }

    private void Shoot()
    {
        

        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(myRay, out hitInfo) && hitInfo.transform.gameObject.CompareTag("target"))
        {
            //sentecia para empujar el objeto
            //hitInfo.rigidbody.AddForce(-hitInfo.normal * force, ForceMode.Impulse);
            Destroy(hitInfo.transform.gameObject);
        }


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("target"))
        {
            GameController.health -= 0.1f;
            
        }
    }
    
      public void Loose()
    {
        fpscam.transform.Find("LostCanvas").Find("LoserPanel").gameObject.SetActive(true);
        Time.timeScale = 0;
        GameController.health = 0;
        GameController.BestScoreCalculator();      
        PauseMenuCanvasScript.loser = true;
    }
    
}




