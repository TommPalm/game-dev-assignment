using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Turnaround : MonoBehaviour
{
    private float pi;
    private float x;
    private float y;
        //transform.rotation = quaternion.RotateZ(math.PI/4); 45°
    void Start()
    {
        pi = math.PI;
        this.x = 0;
        this.y = 0;
    }
   
    void Update()
    {

        float inputX = Input.GetAxisRaw("Horizontal");
        x = inputX;
        float inputY = Input.GetAxisRaw("Vertical");
        y = inputY;

        /*rotazione del personaggio*/
        //up
        if ( IU() && !ID() && !IR() && !IL()) 
        {
            transform.rotation = quaternion.RotateZ(0); //0°
        }
        //up right
        if (IU() && !ID() && IR() && !IL())
        {
            transform.rotation = quaternion.RotateZ(pi*1.75f); //315°
        }
        //right
        if (!IU() && !ID() && IR() && !IL())
        {
            transform.rotation = quaternion.RotateZ(pi*1.5f); //270°
        }
        //down right
        if (!IU() && ID() && IR() && !IL())
        {
            transform.rotation = quaternion.RotateZ(pi*1.25f); //225°
        }
        //down
        if (!IU() && ID() && !IR() && !IL())
        {
            transform.rotation = quaternion.RotateZ(pi); //180°
        }
        //down left
        if (!IU() && ID() && !IR() && IL())
        {
            transform.rotation = quaternion.RotateZ(pi*0.75f); //135°
        }
        //left
        if (!IU() && !ID() && !IR() && IL())
        {
            transform.rotation = quaternion.RotateZ(pi*0.5f); //90°
        }
        //up left
        if (IU() && !ID() && !IR() && IL())
        {
            transform.rotation = quaternion.RotateZ(pi*0.25f); //45°
        }

    }

    private bool IU() //Input Up
    {
        if (this.y > 0) return true;
        else return false;
    }
    private bool ID() //Input Down
    {
        if (this.y < 0) return true;
        else return false;
    }
    private bool IR() //Input Right
    {
        if (this.x > 0) return true;
        else return false;
    }
    private bool IL() // Input Left
    {
        if (this.x < 0) return true;
        else return false;
    }
}
