using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseTarget : MonoBehaviour
{
   
    [SerializeField]private Image cursorImage; // �J�[�\���̉摜
    [SerializeField]private Vector2 offset = new Vector2(10f, -10f); // �}�E�X�ʒu����̃I�t�Z�b�g

    void Start()
    {
        // �J�[�\�����\���ɂ���
        Cursor.visible = false;
    }

    void Update()
    {
        // �}�E�X�̈ʒu���擾���āA�I�t�Z�b�g��K�p
        Vector3 mousePosition = Input.mousePosition;
        cursorImage.transform.position = mousePosition + (Vector3)offset;
    }

    void OnDestroy()
    {
        // �X�N���v�g���폜���ꂽ�Ƃ��ɃJ�[�\����\���ɖ߂�
        Cursor.visible = true;
    }
}
