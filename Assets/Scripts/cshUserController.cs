using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshUserController : MonoBehaviourPun
{
    private Transform cameraRig; // 카메라 리그
    private Transform rightHandRig; // 카메라 리그
    public Transform rightHandModel;
    public Transform characterTransform; // 캐릭터 모델
    public GameObject characterModel; // 캐릭터 모델

    public float sensitivity = 1f; // 카메라 민감도

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            characterModel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            cameraRig = GameObject.Find("CenterEyeAnchor").transform;
            rightHandRig = GameObject.Find("RightHandAnchor").transform;

            // 카메라의 회전 값
            Vector3 cameraRotation = cameraRig.rotation.eulerAngles;

            // 캐릭터 모델의 회전 값 업데이트
            characterTransform.rotation = Quaternion.Euler(0f, cameraRotation.y, 0f);
            characterTransform.position = cameraRig.position + new Vector3(0, -0.3f, 0);

            // 카메라의 회전 값
            Vector3 rightHandRotation = rightHandRig.rotation.eulerAngles;

            // 캐릭터 모델의 회전 값 업데이트
            rightHandModel.rotation = Quaternion.Euler(rightHandRotation.x, rightHandRotation.y, rightHandRotation.z);
            rightHandModel.position = rightHandRig.position;
        }
        
    }
}
