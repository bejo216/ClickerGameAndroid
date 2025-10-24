using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneNumber : MonoBehaviour
{
    public int sceneNumber;
    public void OnClick()
    {

        SceneManager.LoadScene(sceneNumber); 

    }
}
