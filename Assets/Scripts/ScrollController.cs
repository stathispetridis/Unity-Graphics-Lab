using UnityEngine;

public class ScrollController : MonoBehaviour
{
	RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetJoystickNames().Length > 0)
    	{
            float yAxis = Input.GetAxis("Vertical");
            if(Mathf.Abs(yAxis) > 0.2)
            {
            	rt.anchoredPosition = new Vector2(rt.anchoredPosition[0],rt.anchoredPosition[1] - yAxis*5);
            }
    	}
    	rt.anchoredPosition = new Vector2(rt.anchoredPosition[0],Mathf.Clamp(rt.anchoredPosition[1],0,2600));
    }
}
