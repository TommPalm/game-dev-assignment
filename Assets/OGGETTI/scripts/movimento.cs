using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public Vector2 mov;

    void Start()
    {
        vel = 0.025f; 
    }

    void Update()
    {

        /*gestione input movimento pc
        float inputX = Input.GetAxisRaw("Horizontal");
        mov.x = inputX * vel;
        float inputY = Input.GetAxisRaw("Vertical");
        mov.y = inputY * vel;*/
        transform.Translate(mov);
        
        //rb.linearVelocity = mov;
    }

    /*funzioni gestione input movimento tramite tasti per mobile*/
    public void UpButton()
    {
        mov.y = vel;
    }
    public void DownButton()
    {
        
    }
    public void LeftButton()
    {
       
    }
    public void RightButton()
    {
        
    }
    public void ferma()
    {
        mov.y = 0;
        mov.x = 0;
    }

}
