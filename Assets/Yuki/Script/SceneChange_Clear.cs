using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_Clear : MonoBehaviour
{
    public void PushButton()
    {
        SceneManager.LoadScene("Title Scene");
    }
}
