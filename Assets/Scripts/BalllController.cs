using UnityEngine;

public class BalllController : MonoBehaviour
{
    public float speed = 12f;
    public float deadZone = 0.03f;
    public bool autoCalibrateOnStart = true;

    Rigidbody rb;
    Vector2 calib; //XY axis
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(autoCalibrateOnStart) { calib = ReadTiltXY(); }
    }

    Vector2 ReadTiltXY()
    {
        Vector3 acceleration = Input.acceleration;

        return new Vector2(acceleration.x, acceleration.y);
    }

    public void CallibrateNow() => calib = ReadTiltXY();


    void FixedUpdate()
    {
        Vector2 tilt = ReadTiltXY().normalized - calib;

        if(tilt.magnitude < deadZone)
        {
            tilt = Vector2.zero;
        }

        Vector3 force = new Vector3(tilt.x, 0, tilt.y) * speed;
        rb.AddForce(force, ForceMode.Acceleration);
    }
}
