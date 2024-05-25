using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor.SceneManagement;

public class cshVRuser : MonoBehaviourPun
{

    // Start is called before the first frame update

    private void Awake()
    {
        if (!photonView.IsMine)
        {
            DestroyImmediate(GetComponentInChildren<OVRManager>());
            DestroyImmediate(GameObject.Find("[BuildingBlock] Room Model"));
            DestroyImmediate(GameObject.Find("TableVolume"));
        }
    }
    void Start()
    {
        if (!photonView.IsMine)
        {
            
            //// VR ī�޶� FALSE
            ////GetComponentInChildren<OVRCameraRig>().disableEyeAnchorCameras = true;

  //          //Camera[] cameras;
            //cameras = transform.gameObject.GetComponentsInChildren<Camera>();
            //foreach (Camera c in cameras)
            //{
            //    c.enabled = false;
            //}
            ////�ٸ� ����ڵ鿡�� ���� ù��° �ڽ�(= canvas)�� ���� ���ϰ� false
            //transform.GetChild(0).gameObject.SetActive(false);

  //          //// VR ����ڰ� ��Ʈ��ũ �󿡼� �ڽ��� �ƴ� ���
            //// ��ŧ���� �浹�� �����ϱ� ���� ���õ� �Ӽ����� ��� ��Ȱ��ȭ
            ////GetComponent<CharacterController>().enabled = false;
            ////GetComponent<OVRPlayerController>().enabled = false;
            ////GetComponentInChildren<OVRCameraRig>().enabled = false;
            ////GetComponentInChildren<OVRManager>().enabled = false;
            ////GetComponentInChildren<OVRHeadsetEmulator>().enabled = false;
            //Debug.Log("Camera false");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (photonView.IsMine)
        {
            DestroyImmediate(GameObject.Find("TableVolume(Clone)"));
            DestroyImmediate(GameObject.Find("PingPongBall(Clone)"));
            Debug.Log("Destroy????");
            return;
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;
    }
}
