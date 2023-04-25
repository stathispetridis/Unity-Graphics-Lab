using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

	public Animator animator;

	private int levelToLoad;

	void Update()
	{
		if (Input.GetJoystickNames().Length > 0)
		{
			if(Input.GetKeyDown(KeyCode.JoystickButton6))//share/select
			{
				FadeToLevel(0);//change scene
			}
		}
		if(Input.GetKeyDown(KeyCode.Delete))
		{
			FadeToLevel(0);//change scene
		}
	}

	//do fade animation
    public void FadeToLevel(int levelIndex)
    {
    	levelToLoad = levelIndex;
    	animator.SetTrigger("FadeOut");
    }

    //change scene
    public void OnFadeComplete()
    {
    	SceneManager.LoadScene(levelToLoad);
    }
}
