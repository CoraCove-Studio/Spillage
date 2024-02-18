using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menuPanels = new();
    [SerializeField] private GameObject currentPanel;

    #region button functions
    public void OnClickStartButton()
    {
        // logic to transition to character select
    }
    
    public void OnClickMenuButton(int desiredPanelIndex)
    {
        // works for all inter-menu buttons, accepts the index of the panel to navigate to.
        currentPanel.SetActive(false);
        menuPanels[desiredPanelIndex].SetActive(true);
        currentPanel = menuPanels[desiredPanelIndex];
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    #endregion

}
