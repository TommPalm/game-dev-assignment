using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Turnaround : MonoBehaviour
{
    //private float pi;
    public float x,y;
    private Vector2 mov,def;
    private input_mov blubInput;


    //transform.rotation = quaternion.RotateZ(math.PI/4); 45°

    private void Awake()
    {
        blubInput = new input_mov();
    }
    private void OnEnable()
    {
        blubInput.Enable();
    }
    private void OnDisable()
    {
        blubInput.Disable();
    }
    void Start()
    {
       // pi = math.PI;
        this.x = 0;
        this.y = 0;
        def.x = 0;
        def.y = 1;

    }
   
    void Update()
    {
        /*vecchio input pc
        float inputX = Input.GetAxisRaw("Horizontal");
        x = inputX;
        float inputY = Input.GetAxisRaw("Vertical");
        y = inputY;*/

        
        mov = blubInput.blub.move.ReadValue<Vector2>();
        this.x = mov.x;
        this.y = mov.y;

        if (mov.y < 0 && mov.x > 0)
        {
           transform.rotation = quaternion.RotateZ(angoloTraVettori(mov, def) * (-1));
        }
        if (mov.y < 0 && mov.x < 0)
        {
           transform.rotation = quaternion.RotateZ(angoloTraVettori(mov, def));
        }
        if (mov.y > 0 && mov.x > 0)
        {
           transform.rotation = quaternion.RotateZ(angoloTraVettori(mov, def) * (-1));
        }
        if (mov.y > 0 && mov.x < 0)            {
           transform.rotation = quaternion.RotateZ(angoloTraVettori(mov, def));
        }
        

    }

    public float angoloTraVettori(Vector2 a, Vector2 b)
    {
        float v = (a.x * b.x) + (a.y * b.y);
        return Mathf.Acos(v/ 
                            ( Mathf.Sqrt
                                (a.x*a.x + a.y*a.y) 
                            * Mathf.Sqrt
                                (b.x*b.x + b.y*b.y)
                            )
                         );
    }
}
