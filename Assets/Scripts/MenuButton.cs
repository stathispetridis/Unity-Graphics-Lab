using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //We need these in order to use enter and exit
{
	private bool selected = false;
    
    //select this on hover overrides all the over means of selection
    public void OnPointerEnter(PointerEventData eventData)
    {
    	selected = true;
    }

    //allow others to be selected on exit
    public void OnPointerExit(PointerEventData eventData)
    {
    	selected = false;
    }

    //is it this "hard" selected
    public bool IsSelected()
    {
    	return selected;
    }

    //select this
    public void Select()
    {
    	selected = true;
    }

    //Deselect this
    public void Deselect()
    {
    	selected = false;
    }
}
