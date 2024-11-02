using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private float LifeCount = 3;//�c�@
    private bool Invincible = false;//���G���ǂ���
    private float InvincibleTime = 0;//���G���Ԃ̃J�E���g
    private Collider2D Col;
    [Tooltip("���G�̎���")][SerializeField]private float InvincibleEnd = 1;

    [SerializeField] GameObject Hearts1;//1�ڂ̃n�[�g
    [SerializeField] GameObject Hearts2;//�Q�ڂ̃n�[�g
    [SerializeField] GameObject Hearts3;//�R�ڂ̃n�[�g


    void Start()
    {
        Col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Invincible == true)
        {
            Debug.Log("�J�E���g�J�n");
            //���G���ԃJ�E���g�J�n
            InvincibleTime += Time.deltaTime;
        }
        EndInvincible();
    }

    //�G�l�~�[�ɓ���������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("�c�@�[�P");
            //�c�@-1
            LifeCount -= 1;
            PlayerLifeUI();
            //���G�֐��Ăяo��
            StartInvincible();
            DeadPlayer();
        }
    }

    //���G�J�n�̊֐�
    private void StartInvincible()
    {
        Debug.Log("���G�J�n");
        //���G��ON
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
                Debug.Log("���G�I��");
                //���G��OFF
                Invincible = false;
                //�R���C�_�[��ON
                Col.enabled = true;
                InvincibleTime = 0;
            }
    }

    //�v���C���[�̎��S�𔻒f����֐�
    private void DeadPlayer()
    {
        if (LifeCount == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void PlayerLifeUI()
    {
       
        if(Hearts1 != null)
        {
            Destroy(Hearts1);
        }
        if(Hearts2 != null)
        {
            Destroy(Hearts2);
        }
        if (Hearts3 != null)
        {
            Destroy(Hearts3);
        }
    }
}
