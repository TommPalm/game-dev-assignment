using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    private input_mov blubInput;
    private float vel = 0.025f;
    private Vector2 mov;
    private Rigidbody2D rb;

    private void Awake()
    {
        blubInput= new input_mov();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        blubInput.Enable();
    }
    private void OnDisable()
    {
        blubInput.Disable();
    }

    void Update()
    {
        /*vecchio input pc
        float inputX = Input.GetAxisRaw("Horizontal");
        mov.x = inputX * vel;
        float inputY = Input.GetAxisRaw("Vertical");
        mov.y = inputY * vel;*/
        
        mov = blubInput.blub.move.ReadValue<Vector2>();
        transform.Translate(mov*vel);


    }

}
