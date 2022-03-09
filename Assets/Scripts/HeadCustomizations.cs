using System;
using System.Collections.Generic;
using System.Linq;
using Customization;
using UnityEngine;

public class HeadCustomizations : MonoBehaviour
{
    [field: SerializeField]

    private SpriteRenderer HeadSpriteRenderer { get; set; }
    public ICustomization CurrentHeadCustomization { get; set; }
    
    private List<ICustomization> _customizations;
    private int _currentHeadIndex;

    private void Start()
    {
        _customizations = GetComponentsInChildren(typeof(ICustomization)).OfType<ICustomization>().ToList();
        Debug.Log("Loaded " + _customizations.Count + " Head Customizations.");
    }

    private void ActivateHeadCustomization()
    {
        CurrentHeadCustomization?.Deactivate(HeadSpriteRenderer.gameObject);
        CurrentHeadCustomization = _customizations[_currentHeadIndex];
        CurrentHeadCustomization.Activate(HeadSpriteRenderer.gameObject);
    }

    private void NextHead()
    {
        _currentHeadIndex++;
        if (_currentHeadIndex >= _customizations.Count)
        {
            _currentHeadIndex = 0;
        }
        ActivateHeadCustomization();
    }

    private void PreviousHead()
    {
        _currentHeadIndex--;
        if (_currentHeadIndex < 0)
        {
            _currentHeadIndex = _customizations.Count - 1;
        }
        ActivateHeadCustomization();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousHead();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextHead();
        }
    }
}