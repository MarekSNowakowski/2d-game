using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Load()
    {
        PlayerPrefs.SetInt("Load", 1);
        SceneManager.LoadScene("SampleScene");
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Load", 0);
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
