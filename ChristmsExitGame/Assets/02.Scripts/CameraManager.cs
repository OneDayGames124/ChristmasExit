using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance {get; private set;}

    public string CurrentPositionName {get; private set;}

    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject ButtonBack;

    private class CameraPositionInfo
    {
        public Vector3 Position {get; set;}
        public Vector3 Rotate {get; set;}
        public MoveNames MoveNames {get; set;}
    }

    private class MoveNames
    {
        public string Left {get; set;}
        public string Right {get; set;}
        public string Back {get; set;}
    }


    // Start is called before the first frame update

    private Dictionary<string, CameraPositionInfo>  _CameraPositionInfoes= new Dictionary<string, CameraPositionInfo>
    {
        {
            "Bed", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(-2,4,-1),
                Rotate = new Vector3(14,-29,0),
                MoveNames = new MoveNames
                {
                    Left = "Clock",
                    Right = "Closet",
                }
            }

        },
        {
            "Clock", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(1,4,-1),
                Rotate = new Vector3(4,-89,0),
                MoveNames = new MoveNames
                {
                    Left = "Sink",
                    Right = "Bed",
                }
            }

        },
        {
            "Sink", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(1,4,0),
                Rotate = new Vector3(4,-128,0),
                MoveNames = new MoveNames
                {
                    Left = "Snowman",
                    Right = "Clock",
                }
            }

        },
        {
            "Snowman", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(0,5,2),
                Rotate = new Vector3(4,-17,0),
                MoveNames = new MoveNames
                {
                    Left = "Door",
                    Right = "Sink",
                }
            }

        },
        {
            "Door", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(0,5,1),
                Rotate = new Vector3(5,-210,0),
                MoveNames = new MoveNames
                {
                    Left = "Fireplace",
                    Right = "Sink"
                }
            }

        },
        {
            "Fireplace", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(-1,5,1),
                Rotate = new Vector3(5,-245,0),
                MoveNames = new MoveNames
                {
                    Left = "Window",
                    Right = "Door",
                }
            }

        },
        {
            "Window", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(-3,4,2),
                Rotate = new Vector3(5,-286,0),
                MoveNames = new MoveNames
                {
                    Left = "Closet",
                    Right = "Fireplace",
                }
            }

        },
        {
            "Closet", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(-3,4,0),
                Rotate = new Vector3(6,-356,0),
                MoveNames = new MoveNames
                {
                    Left = "Bed",
                    Right = "Fireplace",
                }
            }

        },
    };
    void Start()
    {
        Instance = this;

        ChangeCameraPosition("Bed");

        ButtonBack.GetComponent<Button>().onClick.AddListener(()=>
        {
            ChangeCameraPosition(_CameraPositionInfoes[CurrentPositionName].MoveNames.Back);
        });
        ButtonLeft.GetComponent<Button>().onClick.AddListener(()=>
        {
            ChangeCameraPosition(_CameraPositionInfoes[CurrentPositionName].MoveNames.Left);
        });
        ButtonRight.GetComponent<Button>().onClick.AddListener(()=>
        {   
            ChangeCameraPosition(_CameraPositionInfoes[CurrentPositionName].MoveNames.Right);
        });
    }

    public void ChangeCameraPosition(string positionName)
    {
        if (positionName == null) return;

        CurrentPositionName = positionName;

        GetComponent<Camera>().transform.position = _CameraPositionInfoes[CurrentPositionName].Position;
        GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfoes[CurrentPositionName].Rotate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
