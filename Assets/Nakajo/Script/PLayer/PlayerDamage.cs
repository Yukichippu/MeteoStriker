using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerDamage : MonoBehaviour
{
    private int LifeCount = 3;          //�c�@
    private bool Invincible = false;    //���G���ǂ���
    private float InvincibleTime = 0;   //���G���Ԃ̃J�E���g
    private PolygonCollider2D Col;             //�R���C�_�[�̎擾
    private double time;
    [Tooltip("���G�̎���")][SerializeField]private float InvincibleEnd = 1f;
    [SerializeField] GameObject[] hearts;//�̃n�[�g
    [SerializeField] private SpriteRenderer target;// �_�ł�����Ώ�
    [SerializeField] private float cycle = 1;// �_�Ŏ���[s]

    void Start()
    {
        Col = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (Invincible == true)
        {
            //Debug.Log("�J�E���g�J�n");
            InvincibleTime += Time.deltaTime;
            EndInvincible();

            // �����������o�߂�����
            time += Time.deltaTime;
            if(time >= cycle)
            {
                target.enabled = !target.enabled;
                time = 0f;
            }
        }
    }

    //�G�l�~�[�ɓ���������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && !Invincible)
        {
            //Debug.Log("�c�@�[�P");
            LifeCount -= 1;
            PlayerLifeUI();
            //���G�֐��Ăяo��
            StartInvincible();
            //DeadPlayer();
        }
    }

    //���G�J�n�̊֐�
    private void StartInvincible()
    {
        //Debug.Log("���G�J�n");
        Invincible = true;
        //�R���C�_�[��OFF
        if(Invincible == true)
        {
            Col.enabled = false;
        }
    }

    //���G�I���̊֐�
    private void EndInvincible()
    {
        if (InvincibleTime > InvincibleEnd)
        {
            //Debug.Log("���G�I��");
            target.enabled = true;
            Invincible = false;
            //�R���C�_�[��ON
            Col.enabled = true;
            time = 0f;
            InvincibleTime = 0;
        }
    }
   
    //�v���C���[�̎��S�𔻒f����֐�
    private void DeadPlayer()
    {
        if (LifeCount == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver Scene");
        }
    }

    private void PlayerLifeUI()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i + 1 <= LifeCount) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
