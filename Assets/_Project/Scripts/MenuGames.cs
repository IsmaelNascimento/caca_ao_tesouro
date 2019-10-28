using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGames : MonoBehaviour
{
    [SerializeField] private GameObject m_PanelLoading;

    public void OnButtonGameClicked(string scene)
    {
        m_PanelLoading.SetActive(true);
        SceneManager.LoadScene(scene);
    }
}
