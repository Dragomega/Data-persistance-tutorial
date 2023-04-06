using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MaiMenuUIManager : MonoBehaviour
{
    public PlayerData playerData;
    // Start is called before the first frame update

    public void Awake()
    {
        playerData = PlayerData.Instance;
    }
    public void Start()
    {
        playerData = PlayerData.Instance;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetName(string name)
    {
        Debug.Log("nombre: " +name);
        PlayerData.Instance.playerName= name;
    }

    public void Save()
    {
        playerData.saveData();
    }
    public void Load()
    {
        playerData.LoadData();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else   
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
