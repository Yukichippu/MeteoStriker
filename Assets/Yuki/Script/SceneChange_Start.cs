using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange_Start : MonoBehaviour
{
    //ボタンを押したときの処理
    public void PushButton()
    {
        SceneManager.LoadScene("Clear Scene");
    }
}
