using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed;
    public float turn_speed;

    private Vector3 original_pos;
    private Vector3 original_angles;

    void Start()
    {
        //keep original values needed for (R) reset
        original_pos = transform.position;
        original_angles = transform.eulerAngles;
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        float moveSpeed = speed;
        
        //joystick
        if(Input.GetJoystickNames().Length > 0){
            float xAxis = Input.GetAxis("Horizontal");
            float yAxis = Input.GetAxis("Vertical");
            float xAxis2 = Input.GetAxis("Vertical2");
            float yAxis2 = Input.GetAxis("Horizontal2");
            float L = Input.GetAxis("L2");
            float R = Input.GetAxis("R2");

            if(Mathf.Abs(yAxis) > 0.2)
                transform.position += transform.forward * yAxis;
            if (Mathf.Abs(xAxis) > 0.2)//right
                transform.position += transform.right * xAxis;
            if (Mathf.Abs(xAxis2) > 0.2)//turn left-right
                transform.eulerAngles += new Vector3(xAxis2*0.5f, 0, 0);
            if (Mathf.Abs(yAxis2) > 0.2)//turn up-down
                transform.eulerAngles += new Vector3(0, yAxis2*0.5f, 0);
            if(Mathf.Abs(L) > 0.2)//DOWN
                transform.position -= transform.up * L;
            if (Mathf.Abs(R) > 0.2)//UP
                transform.position += transform.up * R;
            //reposition when lost
            if (Input.GetKeyDown(KeyCode.JoystickButton8))//L3
            {
                transform.position = original_pos;
                transform.eulerAngles = original_angles;
            }
            //look at 0,0,0
            if (Input.GetKey(KeyCode.JoystickButton9))//R3 
            {
                transform.forward = ((-1)*transform.position).normalized;
            }
        }

        //keyboard
        //slowdown inside the cube to be able to move better
        if ((transform.position - (new Vector3(50,50,50))).magnitude < 50)
        {
            moveSpeed = moveSpeed*0.2f;
        }

        //reposition when lost
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = original_pos;
            transform.eulerAngles = original_angles;
        }
        //look at 0,0,0
        if (Input.GetKey(KeyCode.C))
        {
            transform.forward = ((-1)*transform.position).normalized;
        }

        //player movement
        if (Input.GetKey(KeyCode.E))//forward
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.X))//backwards
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))//right
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))//left
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))//down
        {
            transform.position -= transform.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))//up
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }

        //camera rotation controls
        if (Input.GetKey(KeyCode.L))//turn right
        {
            transform.eulerAngles += new Vector3(0, turn_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.J))//turn left
        {
            transform.eulerAngles -= new Vector3(0, turn_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.K))//turn downwards
        {
            transform.eulerAngles += new Vector3(turn_speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.I))//turn upwards
        {
            transform.eulerAngles -= new Vector3(turn_speed * Time.deltaTime, 0, 0);
        }
    }
}
