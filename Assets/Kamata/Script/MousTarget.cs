using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseTarget : MonoBehaviour
{
    [SerializeField] private Image cursorImage; // �J�[�\���̉摜
    [SerializeField] private Vector2 offset = new Vector2(10f, -10f); // �}�E�X�ʒu����̃I�t�Z�b�g

    // �J�[�\���̈ړ��͈́i�X�N���[�����W�Ŏw��j
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    void Start()
    {
        // �J�[�\�����\���ɂ���
        Cursor.visible = false;
    }

    void Update()
    {
        // �}�E�X�̈ʒu���擾���A�I�t�Z�b�g��K�p
        Vector3 mousePosition = Input.mousePosition;

        // X��Y�̈ʒu�ɐ�����������
        mousePosition.x = Mathf.Clamp(mousePosition.x, minX, maxX);
        mousePosition.y = Mathf.Clamp(mousePosition.y, minY, maxY);

        // �J�[�\���摜�̈ʒu���X�V
        cursorImage.transform.position = mousePosition + (Vector3)offset;
    }

    void OnDestroy()
    {
        // �X�N���v�g���폜���ꂽ�Ƃ��ɃJ�[�\����\���ɖ߂�
        Cursor.visible = true;
    }
}
