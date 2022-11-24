using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadScore();
        bestScoreText.text = "Best Score: " + GameManager.Instance.bestPlayer + ": " + GameManager.Instance.bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
