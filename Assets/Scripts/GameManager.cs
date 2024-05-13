using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    public static GameManager instance // �ܺο��� �̱��� ������Ʈ�� �����ö� ����� ������Ƽ
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<GameManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static GameManager m_instance; // �̱����� �Ҵ�� static ����

    public GameObject[] Players;
    public GameObject[] PlayersPos;

    public GameObject MRPlayerPrefab; // ������ MR �÷��̾� ĳ����
    public GameObject VRPlayerPrefab; // ������ VR �÷��̾� ĳ����

    public GameObject MRSpawnPosPrefab; // ������ MR �÷��̾� ĳ������ ��ġ
    public GameObject VRSpawnPosPrefab; // ������ VR �÷��̾� ĳ������ ��ġ



    private int playerCnt = 0;

    public int userId;

    Hashtable Player = new Hashtable();
    bool state = true;
    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    }







    public GameObject objectToActivate; // Ȱ��ȭ�� ���� ������Ʈ
    public float delayInSeconds = 3f; // ��ٸ� �ð� (��)

    private void Start()
    {
        userId = GameObject.FindWithTag("UserId").GetComponent<cshSelectUser>().userId;
        //�����ʰ��Բ� ���Ӹ޴����� �����ϱ����Ͽ� ArrayList�� ���


        // ������ �ð� �Ŀ� ���� ������Ʈ�� Ȱ��ȭ�մϴ�.
        Invoke("ActivateObject", delayInSeconds);


        PhotonNetwork.Instantiate(MRPlayerPrefab.name, MRSpawnPosPrefab.transform.position, Quaternion.identity);
        if (userId == 1)//vr������ ���
        {
            // ������ ���� ��ġ ����
            //Vector3 randomSpawnPos = VRSpawnPosPrefab.transform.position;//Random.insideUnitSphere * 5f;
            Vector3 randomSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);//Random.insideUnitSphere * 5f;

            // ��Ʈ��ũ���� ��� Ŭ���̾�Ʈ���� ���� ����  
            // �ش� ���� ������Ʈ�� �ֵ����� ���� �޼��带 ���� ������ Ŭ���̾�Ʈ�� ����
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
