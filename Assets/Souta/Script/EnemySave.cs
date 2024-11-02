using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

//ìGÇÃê∂ê¨èÓïÒ    
[Serializable]
public struct EnemyData
{
    public Vector3 position;
    public GameObject enemyPrefab;

    public EnemyData(Vector3 position, GameObject prefab)
    {
        this.position = position;
        this.enemyPrefab = prefab;
    }
}

public class EnemySave : MonoBehaviour
{
    [SerializeField]private List<EnemyData> enemyDatas;
    public List<EnemyData> EnemyDatas
    {
        get { return enemyDatas; }
    }

    public void SaveEnemies()
    {
        enemyDatas = new List<EnemyData>();
        foreach (Transform enemy in GetComponentsInChildren<Transform>())
        {
            GameObject prefab = (GameObject)PrefabUtility.GetCorrespondingObjectFromSource(enemy.gameObject);
            if (prefab != null)
            {
                EnemyData enemyData = new EnemyData(enemy.position, prefab);
                enemyDatas.Add(enemyData);
            }
        }
        enemyDatas.Sort((a, b) =>
        {
            float v = a.position.y - b.position.y;
            if (v > 0) return 1;
            else return -1;
        });
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(EnemySave))]
    public class CreateInstanceByPropertyChangeSampleEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();

            if (GUILayout.Button("É}ÉbÉvÇÃï€ë∂"))
            {
                ((EnemySave)target).SaveEnemies();
            }
        }
    }
#endif