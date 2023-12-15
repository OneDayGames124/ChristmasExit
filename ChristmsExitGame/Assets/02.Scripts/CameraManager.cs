using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance {get; private set;}

    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject ButtonBack;

    private class CameraPositionInfo
    {
        public Vector3 Position {get; set;}
        public Vector3 Rotate {get; set;}
        public Vector3 MoveName {get; set;}
    }

    private class MoveName
    {
        public string Left {get; set;}
        public string Right {get; set;}
        public string Back {get; set;}
    }


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    private Dictionary<string, CameraPositionInfo> CameraPositionInfoes = new Dictionary<string, CameraPositionInfo>
    {
        {
            "bed", // 카니 씨는 Door로 설정
            new CameraPositionInfo
            {
                Position = new Vector3(-2,4,-1),
                Rotate = new Vector3(14,-29,0),

            }

        }
    };

    // Update is called once per frame
    void Update()
    {
        
    }
}
