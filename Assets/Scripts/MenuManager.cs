using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject startObj;
    [SerializeField] GameObject itemsObj;
    [SerializeField] GameObject readyObj;
    public bool isDogActive = false;
    public bool isCowActive = false;
    public void StartButton()
    {
        startObj.SetActive(false);
        itemsObj.SetActive(true);
    }
    public void DogButton()
    {
        isDogActive = true;
        isCowActive = false;
        readyObj.SetActive(true);
        Debug.Log("Record");
    }
    public void CowButton()
    {
        isDogActive = false;
        isCowActive = true;
        readyObj.SetActive(true);
        Debug.Log("Record");
    }
    public void BackButton()
    {
        isCowActive = false;
        isDogActive = false;
        itemsObj.SetActive(false);
        startObj.SetActive(true);
    }
    public void ReadyButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }
}
