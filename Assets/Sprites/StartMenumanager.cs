using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;
public class StartMenumanager : MonoBehaviour
{
    #region Get all objects
    [SerializeField] private GameObject _StartNewGame;
    [SerializeField] private GameObject _ContinueGame;
    [SerializeField] private GameObject _Options;
    [SerializeField] private GameObject _QuitGame;
    [SerializeField] private GameObject _QuitLv2Menu;
    [SerializeField] private GameObject _QuitYes;
    [SerializeField] private GameObject _QuitNo;
    [SerializeField] private GameObject _PressAnyKey;
    [SerializeField] private GameObject _Buttons;
    [SerializeField] private GameObject _QuitButton;

    [SerializeField] private GameObject _MenuFirst;
    #endregion

    private bool ifFirst;
    private bool ifQUL2;
    void Start()
    {
        ifFirst = true;
        ifQUL2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        L2Check();

        if (inputManager.instance.MenuOpenCloseInput || inputManager.instance.Canceln)
        {
            if (ifQUL2)
            {
                OnQL2NoPress();
                return;
            }
        }

        if (Input.anyKeyDown && ifFirst)
        {
            _PressAnyKey.SetActive(false);
            _Buttons.SetActive(true);
            EventSystem.current.SetSelectedGameObject(_MenuFirst); 
            ifFirst = false;
        }
    }

    #region Quit function
    #endregion

    #region Open function
    public void OnSNGPress()
    {

    }

    public void OnCGPress()
    {

    }

    public void OnOptionsPress()
    {

    }

    public void OnQuit()
    {
        _QuitButton = _QuitGame;
        ifQUL2 = true;
        _Buttons.SetActive(false);
        _QuitLv2Menu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_QuitNo);
    }

    public void OnQL2YesPress()
    {
        // 在编辑器模式下，使用UnityEditor.EditorApplication.isPlaying = false退出游戏
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在构建的应用程序中使用Application.Quit退出游戏
        Application.Quit();
#endif
    }

    public void OnQL2NoPress()
    {
        _QuitLv2Menu.SetActive(false);
        _Buttons.SetActive(true);
        ifQUL2 = false;
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _QuitButton = null;   
    }
    #endregion

    public void L2Check()
    {

    }
}
