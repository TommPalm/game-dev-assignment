using UnityEngine;

public class movimento : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public Vector2 mov;

    void Start()
    {
        vel = -0.08f; //dato che a muoversi è il labirinto intorno al personaggio
                      //per dare l'illusione del movimento corretto i comandi vanno invertiti
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxisRaw("Horizontal");
        mov.x = inputX * vel;
        float inputY = Input.GetAxisRaw("Vertical");
        mov.y = inputY * vel;
        transform.Translate(mov);


    }
}
