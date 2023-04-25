using UnityEngine;

public class SmallShapeHandler : MonoBehaviour
{
	public GameObject[] Explosion;
	
	private float speed_mag;
	private AudioSource[] source;
	private bool soundEnabled = true;
	private bool m_pressed = false;
    private bool joystick_pressed = false;

	void Start()
	{
		source = GetComponents<AudioSource>();
	}

	void OnCollisionEnter(Collision collision)
	{
		Vector3 contact_point = collision.GetContact(0).point;
		
		//play collision sound
		if (soundEnabled)
			source[0].Play();
		//show explosion particles
		if (!collision.rigidbody.isKinematic)
		{   
			GameObject e = Instantiate(Explosion[1], contact_point, Quaternion.identity);
			Destroy(e, 4.0f);
		}else 
		{
			GameObject e = Instantiate(Explosion[0], contact_point, Quaternion.identity);
			Destroy(e, 4.0f);
		}
	}

	public void Update()
	{
		//joystick
        if(Input.GetJoystickNames().Length > 0){
            if (Input.GetKeyDown(KeyCode.JoystickButton3) && !m_pressed && !joystick_pressed)//Triangle
            {
               joystick_pressed = true;
               source[0].mute = !source[0].mute;
            } else if (Input.GetKeyUp(KeyCode.JoystickButton3) && !m_pressed)
                joystick_pressed = false;
        }

        if (Input.GetKeyDown(KeyCode.M) && !m_pressed && !joystick_pressed)
        {
        	m_pressed = true;
        	source[0].mute = !source[0].mute;
        } else if (Input.GetKeyUp(KeyCode.M) && !joystick_pressed)
        	m_pressed = false;
	}

	//when speedUP changes we need to change our speed
	public void SetSpeedUP(int speedUP)
	{
		(GetComponent<Rigidbody>()).velocity = (GetComponent<Rigidbody>()).velocity.normalized * speed_mag * speedUP;
	}

	//speed magnitude should be the same always
	public void InitMag()
	{
		speed_mag = (GetComponent<Rigidbody>()).velocity.magnitude;
	}
}