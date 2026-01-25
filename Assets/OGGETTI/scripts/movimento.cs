using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public Vector2 mov;

    void Start()
    {
        vel = 0.018f; 
    }

    // Update is called once per frame
    void Update()
    {
        /*gestione input movimento*/
        float inputX = Input.GetAxisRaw("Horizontal");
        mov.x = inputX * vel;
        float inputY = Input.GetAxisRaw("Vertical");
        mov.y = inputY * vel;
        transform.Translate(mov);

    }

}
