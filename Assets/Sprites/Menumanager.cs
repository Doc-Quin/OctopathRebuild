using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menumanager : MonoBehaviour
{
    #region Get all objects
    public string Selectedname = " ";
    [SerializeField] private GameObject _mainMenuCanvasGo;
    [SerializeField] private GameObject _settingsMenuCanvasGo;
    [SerializeField] private GameObject _TopInfo;
    [SerializeField] private GameObject _ButtomInfo;
    [SerializeField] private GameObject _WorldMapButton;
    [SerializeField] private GameObject _WML2Menu;
    [SerializeField] private GameObject _ChangeTeamMemberButton;
    [SerializeField] private GameObject _TeamMenu;
    [SerializeField] private GameObject _CTML2Menu;
    [SerializeField] private GameObject _TravelerRecordButton;
    [SerializeField] private GameObject _TRL2Menu;
    [SerializeField] private GameObject _ItemsButton;
    [SerializeField] private GameObject _ITL2Menu;
    [SerializeField] private GameObject _HealSkillsButton;
    [SerializeField] private GameObject _HSL2Menu;
    [SerializeField] private GameObject _EquipmentButton;
    [SerializeField] private GameObject _EQL2Menu;
    [SerializeField] private GameObject _ProfessionsButton;
    [SerializeField] private GameObject _PFL2Menu;
    [SerializeField] private GameObject _SkillsButton;
    [SerializeField] private GameObject _SKL2Menu;
    [SerializeField] private GameObject _StateButton;
    [SerializeField] private GameObject _STL2Menu;
    [SerializeField] private GameObject _OthersButton;
    [SerializeField] private GameObject _OTL2Menu;
    #endregion

    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingsMenuFirst;
    [SerializeField] private GameObject _QuitButton;

    #region Judge the Lv2 menu status var
    private bool ifpaused;
    private bool ifWML2;
    private bool ifCTML2;
    private bool ifTRL2;
    private bool ifITL2;
    private bool ifHSL2;
    private bool ifEQL2;
    private bool ifPFL2;
    private bool ifSKL2;
    private bool ifSTL2;
    private bool ifOTL2;
    #endregion
    private void Start()
    {
        _mainMenuCanvasGo.SetActive(false);
        _settingsMenuCanvasGo.SetActive(false);
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            Selectedname = EventSystem.current.currentSelectedGameObject.name;
        }
        else
        {
            Selectedname = "Empty";
        }

        L2Check();

        if (inputManager.instance.MenuOpenCloseInput)
        {
            if (!ifpaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }

        if (inputManager.instance.Canceln)
        {
            if (ifWML2)
            {
                QuitWML2();
                return;
            }

            if (ifCTML2)
            {
                QuitCTML2();
                return;
            }

            if (ifTRL2)
            {
                QuitTRL2();
                return;
            }

            if (ifITL2)
            {
                QuitITL2();
                return;
            }

            if (ifHSL2)
            {
                QuitHSL2();
                return;
            }

            if (ifEQL2)
            {
                QuitEQL2();
                return;
            }

            if (ifPFL2)
            {
                QuitPFL2();
                return;
            }

            if (ifSKL2)
            {
                QuitSKL2();
                return;
            }

            if (ifSTL2)
            {
                QuitSTL2();
                return;
            }

            if (ifOTL2)
            {
                QuitOTL2();
                return;
            }

            if (ifpaused)
            {
                Unpause();
                return;
            }
        }
    }

    #region Quit function
    private void QuitWML2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _WML2Menu.SetActive(false);
        ifWML2 = false;
    }
    private void QuitCTML2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _CTML2Menu.SetActive(false);
        ifCTML2 = false;
    }
    private void QuitTRL2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _TRL2Menu.SetActive(false);
        ifTRL2 = false;
    }
    private void QuitITL2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _ITL2Menu.SetActive(false);
        ifITL2 = false;
    }
    private void QuitHSL2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _HSL2Menu.SetActive(false);
        ifHSL2 = false;
    }
    private void QuitEQL2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _EQL2Menu.SetActive(false);
        ifEQL2 = false;
    }
    private void QuitPFL2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _PFL2Menu.SetActive(false);
        ifPFL2 = false;
    }
    private void QuitSKL2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _SKL2Menu.SetActive(false);
        ifSKL2 = false;
    }
    private void QuitSTL2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _STL2Menu.SetActive(false);
        ifSTL2 = false;
    }
    private void QuitOTL2()
    {
        EventSystem.current.SetSelectedGameObject(_QuitButton);
        _OTL2Menu.SetActive(false);
        ifOTL2 = false;
    }
    #endregion
    public void Pause()
    {
        ifpaused = true;
        Time.timeScale = 0f;

        OpenMainMenu();
    }
    public void Unpause()
    {
        ifpaused = false;
        Time.timeScale = 1f;

        CloseAllMenus();
    }
    public void OpenMainMenu()
    {
        _mainMenuCanvasGo.SetActive(true);
        _settingsMenuCanvasGo.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }
    public void CloseAllMenus()
    {
        _mainMenuCanvasGo.SetActive(false);
        _settingsMenuCanvasGo.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    #region Open function
    public void OnWMPress()
    {
        _WML2Menu.SetActive(true);
        ifWML2 = true;
        _QuitButton = _WorldMapButton;
    }
    public void OnCTMPress()
    {
        _CTML2Menu.SetActive(true);
        ifCTML2 = true;
        _QuitButton = _ChangeTeamMemberButton;
    }
    public void OnTRPress()
    {
        _TRL2Menu.SetActive(true);
        ifTRL2 = true;
        _QuitButton = _TravelerRecordButton;
    }
    public void OnITPress()
    {
        _ITL2Menu.SetActive(true);
        ifITL2 = true;
        _QuitButton = _ItemsButton;
    }
    public void OnHSPress()
    {
        _HSL2Menu.SetActive(true);
        ifHSL2 = true;
        _QuitButton = _HealSkillsButton;
    }
    public void OnEQPress()
    {
        _EQL2Menu.SetActive(true);
        ifEQL2 = true;
        _QuitButton = _EquipmentButton;
    }
    public void OnPFPress()
    {
        _PFL2Menu.SetActive(true);
        ifPFL2 = true;
        _QuitButton = _ProfessionsButton;
    }
    public void OnSKPress()
    {
        _SKL2Menu.SetActive(true);
        ifSKL2 = true;
        _QuitButton = _SkillsButton;
    }
    public void OnSTPress()
    {
        _STL2Menu.SetActive(true);
        ifSTL2 = true;
        _QuitButton = _StateButton;
    }
    public void OnOTPress()
    {
        _OTL2Menu.SetActive(true);
        ifOTL2 = true;
        _QuitButton = _OthersButton;
    }
    #endregion
    public void OnSettingBackPress()
    {
        OpenMainMenu();
    }
    private void OpenSettingsMenuHandle()
    {
        _settingsMenuCanvasGo.SetActive(true);
        _mainMenuCanvasGo.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }
    public void L2Check()
    {
        if (ifWML2 && _QuitButton == _WorldMapButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_WorldMapButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }

        if (ifCTML2 && _QuitButton == _ChangeTeamMemberButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_ChangeTeamMemberButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }

        if (ifTRL2 && _QuitButton == _TravelerRecordButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_TravelerRecordButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }

        if (ifITL2 && _QuitButton == _ItemsButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_ItemsButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }

        if (ifHSL2 && _QuitButton == _HealSkillsButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_HealSkillsButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }

        if (ifEQL2 && _QuitButton == _EquipmentButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_EquipmentButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }

        if (ifPFL2 && _QuitButton == _ProfessionsButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_ProfessionsButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }

        if (ifSKL2 && _QuitButton == _SkillsButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_SkillsButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }

        if (ifSTL2 && _QuitButton == _StateButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_StateButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }

        if (ifOTL2 && _QuitButton == _OthersButton && EventSystem.current.currentSelectedGameObject != null)
        {
            if (!EventSystem.current.currentSelectedGameObject.transform.IsChildOf(_OthersButton.transform))
            {
                EventSystem.current.SetSelectedGameObject(_QuitButton);
                return;
            }
        }
    }
}
