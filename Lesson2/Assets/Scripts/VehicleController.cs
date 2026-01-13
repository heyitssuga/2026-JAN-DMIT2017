using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    public InputAction moveInput;
    public InputAction brakeInput;
    public Transform[] wheels;

    float enginePower = 150f;

    public float power = 0f;
    public float brake = 0f;
    public float steer = 0f;

    float maxSteer = 50f;

    public Vector3 centerOfMass = new Vector3(0, -1, 0.3f);
    
    
    void Start()
    {
        moveInput.Enable();
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
        moveInput.performed += ReadInput;
        moveInput.canceled += ReadInput;
        brakeInput.performed += BrakeInput;
        brakeInput.canceled += BrakeInput;

    }

    public void ReadInput(InputAction.CallbackContext context)
    {
        Vector2 tmp = context.ReadValue<Vector2>();
        // x = left/right
        // y = fwd/back
        
        power = tmp.y * enginePower;
        steer = tmp.x * maxSteer;
    }

    private void BrakeInput(InputAction.CallbackContext context)
    {
        if (brake == 0)
        {
            brake = GetComponent<Rigidbody>().mass;
        }
        else
        {
            brake = 0;
        }
    }

    private void FixedUpdate()
    {
                
        GetCollider(0).steerAngle = steer;
        GetCollider(1).steerAngle = steer;

        if (brake > 0f)
        {
            for (int i = 0; i < 4; i++)
            {
                GetCollider(i).brakeTorque = brake;
            }

            GetCollider(2).motorTorque = 0f;
            GetCollider(3).motorTorque = 0f;
        }
        else
        {
            GetCollider(2).motorTorque = power;
            GetCollider(3).motorTorque = power;
        }
        
    }

    WheelCollider GetCollider(int n)
    {
        return wheels[n].gameObject.GetComponent<WheelCollider>();
    }
}
