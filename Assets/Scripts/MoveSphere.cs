using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public int speed;
    public Material[] materials;
    
    //tells us which material is going to be chosen next
    //enables us to have any number of materials to swap
    private int m = 0;
    private bool t_pressed = false;
    private bool joystick_pressed = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        changeMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        //joystick
        if (Input.GetJoystickNames().Length > 0)
        {
            float xAxis = Input.GetAxis("ArrowX");
            float yAxis = Input.GetAxis("ArrowY");
            
            //D-pad
            if (Mathf.Abs(xAxis) > 0.2)//X-Axis movement 
            {
                transform.position += transform.right * xAxis;
            }
            if (Mathf.Abs(yAxis) > 0.2)//Y-Axis movement
            {
                transform.position += transform.up * yAxis;
            }

            //L1
            if (Input.GetKey(KeyCode.JoystickButton4))//Z-Axis movement
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            //R1
            if (Input.GetKey(KeyCode.JoystickButton5))//Z-Axis movement
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            //Options
            if (Input.GetKeyDown(KeyCode.JoystickButton7) && !joystick_pressed && !t_pressed)//option
            {
                joystick_pressed = true;
                changeMaterial();

            } else if (Input.GetKeyUp(KeyCode.JoystickButton7))
            {
                joystick_pressed = false;
            }
        }

        //keyboard
        if (Input.GetKey(KeyCode.RightArrow))//X-Axis movement
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//X-Axis movement
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))//Y-Axis movement
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))//Y-Axis movement
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.KeypadPlus))//Z-Axis movement
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.KeypadMinus))//Z-Axis movement
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        //texture
        if (Input.GetKeyDown(KeyCode.T) && !t_pressed && !joystick_pressed)
        {
            t_pressed = true;
            changeMaterial();

        } else if (Input.GetKeyUp(KeyCode.T) && !joystick_pressed)
        {
            t_pressed = false;
        }

        //keep inside the cube
        float x = Mathf.Clamp(transform.position.x, 15f, 85f);
        float y = Mathf.Clamp(transform.position.y, 15f, 85f);
        float z = Mathf.Clamp(transform.position.z, 15f, 85f);

        transform.position = new Vector3(x, y, z);
    }

    void changeMaterial()
    {
        MeshRenderer mat = null;
        TryGetComponent<MeshRenderer>(out mat);
        if (mat != null)
        {
            mat.material = materials[m];//change material
            m = (++m) % materials.Length;//the next material
        }
    }
}
