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
                Position = new Vector3(-0.5f,5.11f,0.62f),
                Rotate = new Vector3(12.5f,-179.8f,0),
                MoveNames = new MoveNames
                {
                    Left = "Door",
                    Right = "Sink",
                }
            }

        },
        {
            "SnowmanQuiz", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(-0.7f,4.94f,-4.32f),
                Rotate = new Vector3(1.4f,-180.3f,0),
                MoveNames = new MoveNames
                {
                    Back = "Snowman",
                }
            }

        },
        {
            "SnowmanBox1", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(-0.7f,4.94f,-4.32f),
                Rotate = new Vector3(1.4f,-180.3f,0),
                MoveNames = new MoveNames
                {
                    Back = "Snowman",
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
                    Right = "Snowman"
                }
            }

        },
        {
            "Fireplace", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(-3.8f,7.4f,-1.5f),
                Rotate = new Vector3(15.55f,-268,0),
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
            "CuttonQuiz", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(0,4.9f,3.1f),
                Rotate = new Vector3(5,-269,0),
                MoveNames = new MoveNames
                {
                    Back = "Window",
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
                    Right = "Window",
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

        UpdateButtonActive();
    }

   private void UpdateButtonActive()
   {
    if (_CameraPositionInfoes[CurrentPositionName].MoveNames.Back == null)
        ButtonBack.SetActive(false);
    else ButtonBack.SetActive(true);
    if (_CameraPositionInfoes[CurrentPositionName].MoveNames.Left == null)
        ButtonLeft.SetActive(false);
    else ButtonLeft.SetActive(true);
    if (_CameraPositionInfoes[CurrentPositionName].MoveNames.Right == null)
        ButtonRight.SetActive(false);
    else ButtonRight.SetActive(true);
    
   }
}
