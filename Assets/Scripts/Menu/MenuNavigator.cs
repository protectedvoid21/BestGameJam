using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour
{
    [SerializeField]
    public string _playSceneName = "Play";
    
    public void Play()
    {
        SceneManager.LoadScene(_playSceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}