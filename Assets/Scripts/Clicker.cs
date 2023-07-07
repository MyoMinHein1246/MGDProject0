using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Builder builder;

    private Mode _currentMode = Mode.None;

    public void UpdateMode(Mode mode)
    {
        _currentMode = mode;
        print($"Mode changed to {mode}.");
    }

    private void Update()
    {
        if (_currentMode == Mode.None) return;
        
        if (Input.GetMouseButton(0))
        {
			var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var coord = GetGridCoordinates(mousePos);

            if (_currentMode == Mode.Delete)
            {
                builder?.DeleteAt(coord);
            }else
            {
				builder?.Build(new BlockData(GetColor(), coord));
			}
        }
    }

	private Vector3 GetGridCoordinates(Vector3 pos)
	{
		var coord = new Vector3();

		coord.x = ((Mathf.Abs((int)(pos.x / 1.5f)) + 1f) * 1.5f) - 0.75f;
		coord.y = ((Mathf.Abs((int)(pos.y / 1.5f)) + 1f) * 1.5f) - 0.75f;
		coord.z = 0;

		coord.x *= pos.x < 0 ? -1 : 1;
		coord.y *= pos.y < 0 ? -1 : 1;

		return coord;
	}

	private Color GetColor()
    {
        switch (_currentMode)
        {
            case Mode.None:
                return Color.clear;
            case Mode.Delete:
                return Color.clear;
            case Mode.Red:
                return new Color(0xFF / 255f, 0x70 / 255f, 0x70 / 255f);
			case Mode.Green:
				return new Color(0x70 / 255f, 0xFF / 255f, 0x70 / 255f);
			case Mode.Blue:
				return new Color(0x70 / 255f, 0x70 / 255f, 0xFF / 255f);
            default:
                return Color.clear;
		}
    }
}
