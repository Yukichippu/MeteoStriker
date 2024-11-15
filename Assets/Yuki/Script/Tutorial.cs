using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Sprite newImage;
    [SerializeField] private SpriteRenderer image;
    // ���ݑI������Ă���{�^���̔ԍ�
    // -1�Ȃ牽���I������Ă��Ȃ�
    int selectedButtonNo = -1;

    private void Start()
    {
    }

    public void PushStageSelectButton(int stageNo)
    {
        if (selectedButtonNo != stageNo)
        {
            image.sprite = newImage;
            // ���ɑI������Ă���{�^���ł͂Ȃ��Ƃ��i��1��ځj
            // �{�^���̑I��
            selectedButtonNo = stageNo;

        }
        else
        {
            // ���ɑI������Ă���{�^���̂Ƃ��i��2��ځj
            // �Q�[���V�[����
            SceneManager.LoadScene("main");
            selectedButtonNo = -1;
        }
    }
}
