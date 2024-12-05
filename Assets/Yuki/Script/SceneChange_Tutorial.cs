using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_Tutorial : MonoBehaviour
{
    public void PushButton()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }
}
