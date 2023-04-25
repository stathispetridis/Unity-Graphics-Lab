using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerButtons : MonoBehaviour
{
	public GameObject[] buttonList;
	public EventSystem eventSystem;
	public int main_buttons;
	
	private int selected_button = 0;
	private bool arrowPressed = false;

	// Update is called once per frame
	public void Update()
	{
		//if the main buttons are active first choice goes to mouse
		for (int b = 0; b < main_buttons; b++)
		{
			if (buttonList[b].activeSelf && buttonList[b].GetComponent<MenuButton>().IsSelected())
			{
				selected_button = b;
			}
		}

		//if we are in a secondary menu
		//Pressing B returns us to the main menu
		if(Input.GetKey(KeyCode.JoystickButton1) && selected_button >= main_buttons)
		{
		   buttonList[selected_button].GetComponent<Button>().onClick.Invoke();
		}

		//Select Back Button
		for (int b=main_buttons; b < buttonList.Length; b++)
		{
			if (buttonList[b].activeSelf)
			{
				selected_button = b;
				eventSystem.SetSelectedGameObject(buttonList[selected_button]);
				return;
			}
		}
		
		//joystick
		if(Input.GetJoystickNames().Length > 0)
		{
			float yAxisL = Input.GetAxis("Vertical");
			float yAxis = Input.GetAxis("ArrowY");
			
			if (yAxisL > 0.2 && !arrowPressed)//Y-Axis movement
			{
				arrowPressed = true;
				selected_button--;
			}
			else if (yAxisL < -0.2 && !arrowPressed)//Y-Axis movement
			{
				arrowPressed = true;
				selected_button++;
			}

			//D-Pad
			else if (yAxis < -0.2 && !arrowPressed)//Y-Axis movement
			{
				arrowPressed = true;
				selected_button++;
			}
			else if (yAxis > 0.2 && !arrowPressed)//Y-Axis movement
			{
				arrowPressed = true;
				selected_button--;
			}
			else if(Mathf.Abs(yAxis) <= 0.2 && Mathf.Abs(yAxisL) <= 0.2)
			{
				arrowPressed = false;
			}
		}
		selected_button = Mathf.Clamp(selected_button, 0, main_buttons-1);
		eventSystem.SetSelectedGameObject(buttonList[selected_button]);
	}

	//return to the main menu
	public void Back()
	{
		selected_button = 0;
		eventSystem.SetSelectedGameObject(buttonList[0]);
	}
}