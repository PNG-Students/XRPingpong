using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshUserController : MonoBehaviour
{
    public Transform cameraRig; // 카메라 리그
    public Transform characterModel; // 캐릭터 모델

    public float sensitivity = 1f; // 카메라 민감도

    // Start is called before the first frame update
    void Start()
    {
        cameraRig = GameObject.Find("CenterEyeAnchor").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라의 회전 값
        Vector3 cameraRotation = cameraRig.rotation.eulerAngles;

        // 캐릭터 모델의 회전 값 업데이트
        characterModel.rotation = Quaternion.Euler(0f, cameraRotation.y, 0f);

        characterModel.position = cameraRig.position + new Vector3(1.0f,0,0);
    }
}
