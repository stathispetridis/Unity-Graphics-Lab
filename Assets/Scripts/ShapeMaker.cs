using System.Collections;
using UnityEngine;

public class ShapeMaker : MonoBehaviour
{
    public GameObject[] original;
    public int max_speedUp;
    public GameObject text;

    private bool key_pressed = false;
    private bool joystick_pressed = false;
    private int speedUP;
    private ArrayList object_list = new ArrayList();
    
    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        //speed=1 is very slow so we start at 50% max speed
        speedUP = max_speedUp/2;
        text.GetComponent<TMPro.TextMeshProUGUI>().text = speedUP.ToString();
        //set random color
        float r = (float)rand.NextDouble();
        float g = (float)rand.NextDouble();
        float b = (float)rand.NextDouble();

        (GetComponent<Renderer>()).material.SetColor("_Color", new Color(r, g, b, 0.3f));
    }

    // Update is called once per frame
    void Update()
    {
        bool speedUP_changed = false;

        //joystick
        if(Input.GetJoystickNames().Length > 0){
            if (Input.GetKey(KeyCode.JoystickButton2) && speedUP < max_speedUp)//Square
            {
                speedUP++;
                speedUP_changed = true;
            }
            //slow down
            if (Input.GetKey(KeyCode.JoystickButton0) && speedUP > 1)//X
            {
                speedUP--;
                speedUP_changed = true;
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1) && !key_pressed && !joystick_pressed)//O
            {
                joystick_pressed = true;
                spawn();
            }
            else if (Input.GetKeyUp(KeyCode.JoystickButton1))
            {
                joystick_pressed = false;
            }

        }
        //keyboard
        //speed up
        if (Input.GetKey(KeyCode.Period) && speedUP < max_speedUp)
        {
            speedUP++;
            speedUP_changed = true;
        }
        //slow down
        if (Input.GetKey(KeyCode.Comma) && speedUP > 1)
        {
            speedUP--;
            speedUP_changed = true;
        }
        //update the speed of all objects
        if (speedUP_changed)
        {
            text.GetComponent<TMPro.TextMeshProUGUI>().text = speedUP.ToString();
            foreach(GameObject i in object_list) 
            {
                (i.GetComponent<SmallShapeHandler>()).SetSpeedUP(speedUP);
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && !key_pressed && !joystick_pressed)
        {
            //1 new object per button press no spam
            key_pressed = true;
            spawn();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && !joystick_pressed)
        {
            key_pressed = false;
        }
    }

    private void spawn()
    {
        //choose a random shape
            int shape_index = rand.Next(0, original.Length);
            GameObject shape = original[shape_index];

            //create object
            GameObject small_object = Instantiate(shape, new Vector3(5.5f,5.5f,5.5f), shape.transform.rotation);

            //choose a random scale
            int scale = rand.Next(1,11);
            small_object.transform.localScale *= scale;

            //random velocity
            float x = ((float)rand.NextDouble()) *(0.9f - 0.1f) + 0.1f;
            float y = ((float)rand.NextDouble()) *(0.9f - 0.1f) + 0.1f;
            float z = ((float)rand.NextDouble()) *(0.9f - 0.1f) + 0.1f;
            (small_object.GetComponent<Rigidbody>()).velocity = new Vector3(x, y, z);

            //we have set speed now get the mag
            (small_object.GetComponent<SmallShapeHandler>()).InitMag();

            //give object global speedup
            (small_object.GetComponent<SmallShapeHandler>()).SetSpeedUP(speedUP);

            //random color
            x = (float)rand.NextDouble();
            y = (float)rand.NextDouble();
            z = (float)rand.NextDouble();
            (small_object.GetComponent<Renderer>()).material.SetColor("_Color", new Color(x, y, z, 1.0f));

            //add to list
            object_list.Add(small_object);
    }
}
