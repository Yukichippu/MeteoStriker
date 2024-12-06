using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private AudioClip clBGM;           //ClearBGM
    [SerializeField ]private float MoveSpeed = 0.2f;    //��������
    Vector3 targetPosition = new Vector3(960, 540, 0);  //���̍��W�܂Ői��

    public bool OnMove = false;                         //�Q�b�o�������𔻒�

    private void Start()
    {
        
    }
    void Update()
    {
        if (OnMove)
        {
            Transform objectTransform = gameObject.GetComponent<Transform>();
            objectTransform.position = Vector3.Lerp(objectTransform.position, targetPosition, MoveSpeed * Time.deltaTime);
        }
    }

    IEnumerator WaitAndStartMovement(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        OnMove = true;
        GetComponent<AudioSource>().PlayOneShot(clBGM);
    }

    public void isGoal()
    {
        StartCoroutine(WaitAndStartMovement(2f));
    }
}
