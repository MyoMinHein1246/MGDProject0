using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text message;

	private void Awake()
	{
        UpdateUI(UIState.Normal);
	}

	public void UpdateUI(UIState state)
    {
        switch(state)
        {
            case UIState.Normal:
                panel.SetActive(false);
                break;
            case UIState.Saving:
                OpenPanel("Saving...");
                break;
            case UIState.Loading:
                OpenPanel("Loading...");
                break;
        }
    }

    public void OpenPanel(string msg)
    {
        panel.SetActive(true);
        message.SetText(msg);
    }
}

public enum UIState
{
    Normal = 0,
    Saving = 1,
    Loading = 2
}
