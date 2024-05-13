using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    public static GameManager instance // 외부에서 싱글톤 오브젝트를 가져올때 사용할 프로퍼티
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    public GameObject[] Players;
    public GameObject[] PlayersPos;

    public GameObject MRPlayerPrefab; // 생성할 MR 플레이어 캐릭터
    public GameObject VRPlayerPrefab; // 생성할 VR 플레이어 캐릭터

    public GameObject MRSpawnPosPrefab; // 생성할 MR 플레이어 캐릭터의 위치
    public GameObject VRSpawnPosPrefab; // 생성할 VR 플레이어 캐릭터의 위치



    private int playerCnt = 0;

    public int userId;

    Hashtable Player = new Hashtable();
    bool state = true;
    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }







    public GameObject objectToActivate; // 활성화할 게임 오브젝트
    public float delayInSeconds = 3f; // 기다릴 시간 (초)

    private void Start()
    {
        userId = GameObject.FindWithTag("UserId").GetComponent<cshSelectUser>().userId;
        //생성됨과함께 게임메니저가 관리하기위하여 ArrayList에 등록


        // 지정한 시간 후에 게임 오브젝트를 활성화합니다.
        Invoke("ActivateObject", delayInSeconds);


        PhotonNetwork.Instantiate(MRPlayerPrefab.name, MRSpawnPosPrefab.transform.position, Quaternion.identity);
        if (userId == 1)//vr유저일 경우
        {
            // 생성할 랜덤 위치 지정
            //Vector3 randomSpawnPos = VRSpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
            Vector3 randomSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);//Random.insideUnitSphere * 5f;

            // 네트워크상의 모든 클라이언트에서 생성 실행  
            // 해당 게임 오브젝트의 주도권은 생성 메서드를 직접 실행한 클라이언트에 있음
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

    private void ActivateObject()
    {
        objectToActivate.SetActive(true);
    }
}
