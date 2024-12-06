using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private int LifeCount = 3;          //�c�@
    private bool Invincible = false;    //���G���ǂ���
    private float InvincibleTime = 0;   //���G���Ԃ̃J�E���g
    private PolygonCollider2D Col;             //�R���C�_�[�̎擾
    private double time;
    [Tooltip("���G�̎���")][SerializeField] private float InvincibleEnd = 1f;
    [SerializeField] GameObject[] hearts;//�̃n�[�g
    [SerializeField] private SpriteRenderer target;// �_�ł�����Ώ�
    [SerializeField] private float cycle = 1;// �_�Ŏ���[s]
    [SerializeField] private AudioClip sound; //SE

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
            if (time >= cycle)
            {
                target.enabled = !target.enabled;
                time = 0f;
            }
        }

        DeadPlayer();
    }

    //�G�l�~�[�ɓ���������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2" && !Invincible)
        {
            //Debug.Log("�c�@�[�P");
            LifeCount -= 1;
            PlayerLifeUI();
            //���G�֐��Ăяo��
            StartInvincible();
            //DeadPlayer();
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }

    //���G�J�n�̊֐�
    private void StartInvincible()
    {
        //Debug.Log("���G�J�n");
        Invincible = true;
        //�R���C�_�[��OFF
        if (Invincible == true)
        {
            Col.enabled = false;
        }
    }

    //���G�I���̊֐�
    private void EndInvincible()
    {
        if (InvincibleTime > InvincibleEnd)
        {
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
            SceneManager.LoadScene("GameOver Scene");
            Destroy(this.gameObject);
        }
    }

    private void PlayerLifeUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i + 1 <= LifeCount) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
