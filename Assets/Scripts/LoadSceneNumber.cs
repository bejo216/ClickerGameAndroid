using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneNumber : MonoBehaviour
{
    public int sceneNumber;
    public void OnClick()
    {
        SoundManager.Instance.PlayClickSound();
        SceneManager.LoadScene(sceneNumber); 

    }
}
