using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private float posY = 10;
    [SerializeField] private EnemySave enemySave;
    [SerializeField] private GameObject border;

    [SerializeField] private RectTransform player;

    [SerializeField] private RectTransform start;
    [SerializeField] private RectTransform end;

    private void Start()
    {
        posY = enemySave.EnemyDatas[enemySave.EnemyDatas.Count - 1].position.y;
    }

    void Update()
    {
        float step = border.transform.position.y / posY;
        player.position = Vector3.Lerp(start.position, end.position, step);
    }
}
