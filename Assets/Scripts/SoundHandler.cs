using UnityEngine;

public class SoundHandler : MonoBehaviour
{
	private AudioSource source;
	private bool m_pressed = false;
    private bool joystick_pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //joystick
        if(Input.GetJoystickNames().Length > 0){
            if (Input.GetKeyDown(KeyCode.JoystickButton3) && !m_pressed && !joystick_pressed)//Triangle
            {
               joystick_pressed = true;
                if (source.isPlaying){
                    source.Pause();
                } else {
                    source.UnPause();
                }
            } else if (Input.GetKeyUp(KeyCode.JoystickButton3) && !m_pressed)
            {
                joystick_pressed = false;
            }

        }
        //keyboard
        if (Input.GetKeyDown(KeyCode.M) && !m_pressed && !joystick_pressed)
        {
        	m_pressed = true;
        	if (source.isPlaying){
        		source.Pause();
        	} else {
        		source.UnPause();
        	}
        } else if (Input.GetKeyUp(KeyCode.M) && !joystick_pressed)
        {
        	m_pressed = false;
        }
    }
}
