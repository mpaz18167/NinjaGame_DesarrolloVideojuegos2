using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{


    public float velocidad;
    public float fuerzasalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;


    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool miraDerecha = true;
    private int saltosRestantes;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;   

    }


    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Salto();
    }

    void Movimiento()
    {
        //Variable para capturar el input del teclado
        float inputMov = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(inputMov * velocidad, rigidBody.velocity.y);

        Orientacion(inputMov);
    }

    void Orientacion(float inputMov)
    {
        if ((inputMov < 0 && miraDerecha==true)||(inputMov > 0 && miraDerecha == false))
        {
            miraDerecha = !miraDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    void Salto()
    {
        if (EstaEnSuelo()) 
        {
            saltosRestantes = saltosMaximos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * fuerzasalto, ForceMode2D.Impulse);
        }
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit= Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y),0f,Vector2.down,0.1f,capaSuelo);
        return raycastHit.collider != null;
    }

}
