using UnityEngine;

public class FixRotation : MonoBehaviour
{
	//keep the orientation the same
    void LateUpdate()
    {
    	transform.eulerAngles = Vector3.zero;
    }
}