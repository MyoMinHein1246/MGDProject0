using System;
using UnityEngine;

[RequireComponent(typeof(Clicker))]
public class ModeSelector : MonoBehaviour
{
    private Clicker _clicker;
    
    private void Start()
    {
        _clicker = GetComponent<Clicker>();
    }

    public void OnSelectRed(bool value)
    {
        _clicker.UpdateMode(value ? Mode.Red : Mode.None);
    }
    
    public void OnSelectGreen(bool value)
    {
        _clicker.UpdateMode(value ? Mode.Green : Mode.None);
    }
    
    public void OnSelectBlue(bool value)
    {
        _clicker.UpdateMode(value ? Mode.Blue : Mode.None);
    }
    
    public void OnSelectDelete(bool value)
    {
        _clicker.UpdateMode(value ? Mode.Delete : Mode.None);
    }
}
