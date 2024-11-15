using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Sprite newImage;
    [SerializeField] private SpriteRenderer image;
    // 現在選択されているボタンの番号
    // -1なら何も選択されていない
    int selectedButtonNo = -1;

    private void Start()
    {
    }

    public void PushStageSelectButton(int stageNo)
    {
        if (selectedButtonNo != stageNo)
        {
            image.sprite = newImage;
            // 既に選択されているボタンではないとき（＝1回目）
            // ボタンの選択
            selectedButtonNo = stageNo;

        }
        else
        {
            // 既に選択されているボタンのとき（＝2回目）
            // ゲームシーンへ
            SceneManager.LoadScene("main");
            selectedButtonNo = -1;
        }
    }
}
