using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
    public GameObject[] prefabs;  //������ ������Ʈ �迭 
                                 
                                
    private BoxCollider area;    
    public int count;      //�� ���� ������Ʈ ����

    private List<GameObject> gameObject = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>();

        for (int i = 0; i < count; ++i)//count �� ��ŭ �����Ѵ�
        {
            Spawn();//���� + ������ġ�� �����ϴ� �Լ�
        }

        area.enabled = false;
    }
    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-6.5f, 6.5f);        
        float posZ = basePosition.z + Random.Range(-8.5f, 8.5f);

        Vector3 spawnPos = new Vector3(posX, 0.5f, posZ);

        return spawnPos;
    }
    public void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);

        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();//������ġ�Լ�

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
