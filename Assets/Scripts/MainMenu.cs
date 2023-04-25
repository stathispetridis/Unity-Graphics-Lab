using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    public Animator animator;

    //transition
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
    //Get in into the game
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    //close game
    public void Quit()
    {
        Application.Quit();
    }
}
