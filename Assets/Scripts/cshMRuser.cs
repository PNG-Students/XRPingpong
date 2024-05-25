using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class cshMRuser : MonoBehaviourPun
{
    public GameObject tablePrefab;
    private GameObject roomTable;
    public GameObject ballPrefab;

    private void Awake()
    {
        if (!photonView.IsMine)
        {
            DestroyImmediate(GetComponentInChildren<OVRManager>());
            DestroyImmediate(GameObject.Find("TableVolume(Clone)"));
            DestroyImmediate(GameObject.Find("PingPongBall(Clone)"));

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        /*if (!photonView.IsMine)
        {
            // MR ?????? FALSE
            //GetComponentInChildren<OVRCameraRig>().disableEyeAnchorCameras = true;

            Camera[] cameras;
            cameras = transform.gameObject.GetComponentsInChildren<Camera>();
            foreach (Camera c in cameras)
            {
                c.enabled = false;
            }
            //???? ???????????? ???? ?????? ????(= canvas)?? ???? ?????? false
            transform.GetChild(0).gameObject.SetActive(false);

            // VR ???????? ???????? ?????? ?????? ???? ????
            // ???????? ?????? ???????? ???? ?????? ???????? ???? ????????
            //GetComponent<CharacterController>().enabled = false;
            //GetComponent<OVRPlayerController>().enabled = false;
            //GetComponentInChildren<OVRCameraRig>().enabled = false;
            //GetComponentInChildren<OVRHeadsetEmulator>().enabled = false;
            Debug.Log("Camera false");
        }*/

        StartCoroutine(ExecuteAfterDelay(3.0f));
    }

    private IEnumerator ExecuteAfterDelay(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Find the roomTable object
        GameObject roomTable = GameObject.Find("TableVolume(Clone)");
        GameObject ballPos = GameObject.Find("BallSpawnPos");
        if (roomTable != null)
        {
            // Instantiate the tablePrefab using PhotonNetwork
            GameObject instantiatedTable = PhotonNetwork.Instantiate(tablePrefab.name, roomTable.transform.position, roomTable.transform.rotation);
            GameObject instantiatedBall = PhotonNetwork.Instantiate(ballPrefab.name, ballPos.transform.position, ballPos.transform.rotation);

            // Set the scale of the instantiated table to match the roomTable
            instantiatedTable.transform.localScale = roomTable.transform.Find("Parent").localScale;

            //instantiatedTable.transform.localScale = roomTable.transform.localScale;

            Debug.Log("2 seconds have passed, table instantiated and transformed.");
        }
        else
        {
            Debug.LogError("roomTable not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;
    }
}
