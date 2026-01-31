using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Turnaround : MonoBehaviour
{
    private float pi;
    private float x,y;
    private Vector2 mov;
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
        pi = math.PI;
        this.x = 0;
        this.y = 0;
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
        if(this.x >=0)
            transform.rotation = quaternion.RotateZ( (Mathf.Asin(this.y)*Mathf.Deg2Rad)   );
        if(this.x <0)
            transform.rotation = quaternion.RotateZ(pi- (Mathf.Asin(this.y) * Mathf.Deg2Rad)  );



    }

}
