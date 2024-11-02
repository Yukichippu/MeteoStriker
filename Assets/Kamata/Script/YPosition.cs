using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPosition : MonoBehaviour
{
    [SerializeField] private float minYPosition = 200f; // �}�E�X��Y���W�̉���

    void Update()
    {
        // �}�E�X�̃X�N���[�����W���擾
        Vector3 mousePosition = Input.mousePosition;

        // Y���W��minYPosition��艺�ł���ΐ�������
        if (mousePosition.y < minYPosition)
        {
            mousePosition.y = minYPosition;
        }

        // �}�E�X���W�����[���h���W�ɕϊ��i��Ƃ��āj
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

        // �I�u�W�F�N�g�̈ʒu���}�E�X�ɒǏ]������ꍇ�̗�
        transform.position = worldPosition;
    }
}
