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
    private GameObject instantiatedTable;
    private GameObject instantiatedBall;
    private void Awake()
    {
        if (!photonView.IsMine)
        {
            DestroyImmediate(GetComponentInChildren<OVRManager>());

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
            GameObject[] tables = GameObject.FindGameObjectsWithTag("Table");

            // Cube 오브젝트의 개수를 출력합니다.
            int tableCount = tables.Length;
            

            if (tableCount < 1)
            {
                instantiatedTable = PhotonNetwork.Instantiate(tablePrefab.name, roomTable.transform.position, roomTable.transform.rotation);
                instantiatedBall = PhotonNetwork.Instantiate(ballPrefab.name, ballPos.transform.position, ballPos.transform.rotation);
            }

            // Set the scale of the instantiated table to match the roomTable
            instantiatedTable.transform.localScale = roomTable.transform.Find("Parent").localScale;

            if (!photonView.IsMine)
            {
                
            }

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
            /*DestroyImmediate(GameObject.Find("TableVolume(Clone)"));
            DestroyImmediate(GameObject.Find("PingPongBall(Clone)"));
            Debug.Log("Destroy????");*/
            return;
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;
    }
}
