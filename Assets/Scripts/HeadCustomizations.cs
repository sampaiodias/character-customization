using System;
using System.Collections.Generic;
using System.Linq;
using Customization;
using UnityEngine;

public class HeadCustomizations : MonoBehaviour
{
    [field: SerializeField]

    private SpriteRenderer HeadSpriteRenderer { get; set; }
    
    private List<ICustomization> _customizations;
    private int _currentHeadIndex;
    private ICustomization _currentHeadCustomization;

    private void Start()
    {
        _customizations = GetComponentsInChildren(typeof(ICustomization)).OfType<ICustomization>().ToList();
        Debug.Log("Loaded " + _customizations.Count + " Head Customizations.");
    }

    private void ActivateHeadCustomization()
    {
        _currentHeadCustomization?.Deactivate(HeadSpriteRenderer.gameObject);
        _currentHeadCustomization = _customizations[_currentHeadIndex];
        _currentHeadCustomization.Activate(HeadSpriteRenderer.gameObject);
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