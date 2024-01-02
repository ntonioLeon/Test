using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
   
/// <autor>
/// Jorge Pastor y Antonio Leon.
/// </autor>
public class PlayerControler : MonoBehaviour
{
    /// <summary>
    /// Velocidad y movimiento
    /// </summary>
    public float velocidad, alturaSalto, velocidadBase; //Variables que controlan la velocidad de movimiento y altura de salto del pj.
    float velX, velY; //Movimiento en los ejes x e y.

    /// <summary>
    /// Salto
    /// </summary>
    public Transform groundcheck; //Variable que comprueba que el personaje esta en el suelo y no en el aire.
    public bool estaEnElSuelo;  //Bool referido a si el personaje esta en el suelo.
    public float radioDeteccion; //Radio del personaje que deteca si toca el suelo.
    public LayerMask queEsSuelo; //Layer que simboliza el suelo.

    /// <summary>
    /// Objetos
    /// </summary>
    Rigidbody2D rb;  //Espacio fisico que ocupa el personaje.
    Animator anim; //Objeto que realiza las transiciones de animaciones.

    public static PlayerControler instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// Start is called before the first frame update .
    /// Metodo que se lanza al iniciar el juego, debe tener e inicializar las variables y otros necesarios.
    /// </summary>
    void Start()
    {
        velocidadBase = velocidad;
        rb = GetComponent<Rigidbody2D>(); //Inicializamos las variables.
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// Gestiona los graficos del juego.
    /// </summary>
    void Update()
    {
        //actualiza frame por frame si el personaje esta en suelo.
        estaEnElSuelo = Physics2D.OverlapCircle(groundcheck.position, radioDeteccion, queEsSuelo); 

        //Cambia animacion si el personaje no esta en el suelo.
        if (estaEnElSuelo)
        {
            anim.SetBool("Saltar", false);
        } 
        else
        {
            anim.SetBool("Saltar", true);
        }

        FlipedCharacter(); //Encargado de girar el personaje.
        Attack(); //Atacamos
        Slice();
    }

    /// <summary>
    /// Gestion de fisicas del juego.
    /// </summary>
    private void FixedUpdate()
    {
        Movement(); //Movimientos horizontales.
        Jump(); //Movimientos verticales.
    }

    public void Slice()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            anim.SetBool("Slice", true);
        }
        else
        {
            anim.SetBool("Slice", false);
        }
    }
    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Atacar", true);
        }
        else
        {
            anim.SetBool("Atacar", false);
        }
    }

    /// <summary>
    /// Metodo que desplaza el personaje a traves del ejeX (horizontal).
    /// </summary>
    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");  //Esto identifica el imput del las flechas.
        velY = rb.velocity.y;                    
        if (velocidad != 0)
        {
            rb.velocity = new Vector2(velX * velocidad, velY); //Crea un nuevo vector con el movimiento asignado por el input.

            //If para cambiar de animacion si se mueve en horizontal.
            if (rb.velocity.x != 0 && !anim.GetBool("Atacar"))
            {
                anim.SetBool("Correr", true); //Corre.
            }
            else
            {
                anim.SetBool("Correr", false); //No corre.
            }
        }        
    }

    /// <summary>
    /// Metodo que desplaza al personaje a traves del ejeY (Vertical)
    /// </summary>
    public void Jump()
    {
        //Si esta en el suelo y se ha pulsado espacio
        if (Input.GetButton("Jump") && estaEnElSuelo) 
        {
            rb.velocity = new Vector2(rb.velocity.x, alturaSalto);  //Desplazamiento vertical
        } 
    }

    /// <summary>
    /// Metodo que gira el personaje para orientarlo a la direccion donde va.
    /// </summary>
    public void FlipedCharacter()
    {   
        //If que determina si va a la izquierda o derecha
        if (rb.velocity.x > 0 && !anim.GetBool("Atacar")) //derecha //al FINAL SI QUE ERA ESTO
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if (rb.velocity.x < 0 && !anim.GetBool("Atacar")) //izquierda
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }
    }

    public void freeze(float speed)
    {
        velocidad = speed;    
    }
}
