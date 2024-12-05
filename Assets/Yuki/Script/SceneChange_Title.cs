using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_Title : MonoBehaviour
{
    public void PushButton()
    {
        SceneManager.LoadScene("Title");
    }
}
