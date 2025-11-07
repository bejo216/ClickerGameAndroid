using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneNumber : MonoBehaviour
{
    public string sceneName;
    public void OnClick()
    {
        SoundManager.Instance.PlayClickSound();
        SceneManager.LoadScene(sceneName); 

    }
}
