using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDoorOpen : MonoBehaviour
{
    public string OpenPositionName;

    public Vector3 OpenRotate;

    public Vector3 OpenPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenPositionName == CameraManager.Instance.CurrentPositionName)
            gameObject.transform.localPosition = OpenPosition;
        
    }
}
