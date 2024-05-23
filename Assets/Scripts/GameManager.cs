using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    public static GameManager instance // ???????? ?????? ?????????? ???????? ?????? ????????
    {
        get
        {
            // ???? ?????? ?????? ???? ?????????? ???????? ????????
            if (m_instance == null)
            {
                // ?????? GameManager ?????????? ???? ????
                m_instance = FindObjectOfType<GameManager>();
            }

            // ?????? ?????????? ????
            return m_instance;
        }
    }

    private static GameManager m_instance; // ???????? ?????? static ????

    public GameObject[] vrPlayers;
    public GameObject[] vrPlayersPos;

    public GameObject[] mrlayers;
    public GameObject[] mrPlayersPos;

    public GameObject MRPlayerPrefab; // ?????? MR ???????? ??????
    public GameObject VRPlayerPrefab; // ?????? VR ???????? ??????

    public GameObject MRSpawnPosPrefab; // ?????? MR ???????? ???????? ????
    public GameObject VRSpawnPosPrefab; // ?????? VR ???????? ???????? ????



    private int playerCnt = 0;

    public int userId;

    Hashtable Player = new Hashtable();
    bool state = true;


    private void Awake()
    {
        // ???? ?????? ?????????? ?? ???? GameManager ?????????? ??????
        if (instance != this)
        {
            // ?????? ????
            Destroy(gameObject);
        }
    }







    public GameObject objectToActivate; // ???????? ???? ????????
    public float delayInSeconds = 3f; // ?????? ???? (??)

    private void Start()
    {
        userId = GameObject.FindWithTag("UserId").GetComponent<cshSelectUser>().userId;
        //???????????? ???????????? ?????????????? ArrayList?? ????


        // ?????? ???? ???? ???? ?????????? ????????????.
        Invoke("ActivateObject", delayInSeconds);


        if (userId == 0)//mr??? ??
        {
            // ?????? ???? ???? ????
            //Vector3 randomSpawnPos = VRSpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
            Vector3 randomSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);//Random.insideUnitSphere * 5f;

            // ???????????? ???? ?????????????? ???? ????  
            // ???? ???? ?????????? ???????? ???? ???????? ???? ?????? ???????????? ????

            PhotonNetwork.Instantiate(MRPlayerPrefab.name, MRSpawnPosPrefab.transform.position, Quaternion.identity);
            //playerCnt++;
        }
        if (userId == 1)//vr?????? ????
        {
            // ?????? ???? ???? ????
            //Vector3 randomSpawnPos = VRSpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
            Vector3 randomSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);//Random.insideUnitSphere * 5f;

            // ???????????? ???? ?????????????? ???? ????  
            // ???? ???? ?????????? ???????? ???? ???????? ???? ?????? ???????????? ????
            PhotonNetwork.Instantiate(VRPlayerPrefab.name, randomSpawnPos, Quaternion.identity);
            //playerCnt++;
        }
        else
        {
            //Vector3 randomSpawnPos = MRSpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
            Vector3 randomSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);///Random.insideUnitSphere * 5f;
            //PhotonNetwork.Instantiate(MixedRealityPlayspace.name, randomSpawnPos, Quaternion.identity);
            //PhotonNetwork.Instantiate(MixedRealityToolkit.name, randomSpawnPos, Quaternion.identity);
            //MixedRealityPlayspace = GameObject.Find("MixedRealityPlayspace");
            //GameObject MRPCamera = MixedRealityPlayspace.transform.GetChild(0).gameObject;
            //GameObject temp = PhotonNetwork.Instantiate(MRPlayerPrefab.name, randomSpawnPos, Quaternion.identity);
            //temp.transform.parent = MRPCamera.transform;
        }



    }

    //private void ActivateObject()
    //{
    //    objectToActivate.SetActive(true);
    //}
}
