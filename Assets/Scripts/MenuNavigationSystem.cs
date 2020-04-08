using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuNavigationSystem : MonoBehaviour
{
    [Serializable]
    public class PanelContent
    {
        public PanelName Name;
        public GameObject PanelGameObject;
        public GameObject FirstElementInPanel;
        
    }
    public enum PanelName
    {
        None,
        MainMenu,
        Option,
        HowTo,
    }

    public PanelName defaultPanel;
    public PanelName currentPanel;
    
    public List<PanelContent> panelContents;

    private void Awake()
    {
        NavigateToPanel(defaultPanel);
    }

    public void NavigateToPanel(string panelName)
    {
            bool parseResult = Enum.TryParse(panelName, true, out PanelName result);
            if (!parseResult)
            {
                Debug.LogError($"Can't find the panel with the name {panelName} to translate to");
            }
            NavigateToPanel(result);
    }

    
    public void NavigateToPanel(PanelName panelName)
    {
        foreach (PanelContent content in panelContents)
        {
            if (content.Name == currentPanel)
            {
                content.PanelGameObject.SetActive(false);
                currentPanel = PanelName.None;
            }
            
        }

        foreach (PanelContent content in panelContents)
        {
            if (content.Name == panelName)
            {
                content.PanelGameObject.SetActive(true);
                EventSystem.current.SetSelectedGameObject(content.FirstElementInPanel);
                currentPanel = panelName;
            }
        }
        
        
        
    }
    
}
