using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleTarget : MonoBehaviour
{
    [SerializeField] private Image cursorImage; //�J�[�\���̉摜
    [SerializeField] private Vector2 offset = new Vector2(10f, -10f);// �}�E�X�ʒu����̃I�t�Z�b�g

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

        // ���N���b�N�����o
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick(mousePosition);
        }
    }

    // �N���b�N���̏������L�q
    private void HandleClick(Vector3 mousePosition)
    {
        Debug.Log("�N���b�N���܂����I �}�E�X�ʒu: " + mousePosition);

        // Raycast���g���ăN���b�N�Ώۂ��擾
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            Debug.Log("�N���b�N�Ώ�: " + hit.collider.gameObject.name);

            // �Ώۂ̃I�u�W�F�N�g�ɓ���̏�����ǉ��������ꍇ
            if (hit.collider.CompareTag("Clickable"))
            {
                Debug.Log(hit.collider.gameObject.name + " ���N���b�N���܂����I");
                // �����ɏ�����ǉ�
            }
        }
    }

    void OnDestroy()
    {
        // �X�N���v�g���폜���ꂽ�Ƃ��ɃJ�[�\����\���ɖ߂�
        Cursor.visible = true;
    }
}
