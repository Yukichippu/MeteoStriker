using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    [SerializeField] private EnemySave enemySave;
    [SerializeField] private float borderSpeed = 0f;
    private List<EnemyData> enemyDatas = new List<EnemyData>();
    private float currentY = 8.5f;
    private int currentIndex = 0;
    [SerializeField] private GameObject border;
    private void Awake()
    {
        enemyDatas = enemySave.EnemyDatas;
    }

    private void Update()
    {
        if (currentIndex >= enemyDatas.Count) return;

        currentY += borderSpeed * Time.deltaTime;
        border.transform.position = new Vector3(0f, currentY, 0f);

        if (currentY >= enemyDatas[currentIndex].position.y)
        {
            Vector3 pos = enemyDatas[currentIndex].position;
            pos.y = 5f;
            Instantiate(enemyDatas[currentIndex].enemyPrefab, pos, Quaternion.identity, transform);
            currentIndex++;
        }

    }

}
