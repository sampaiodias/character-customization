using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentHeadCustomization : MonoBehaviour
{
    [field: SerializeField]
    private TextMeshProUGUI Text { get; set; }
    [field: SerializeField]
    private HeadCustomizations Customizations { get; set; }
    
    private void Update()
    {
        Text.SetText(Customizations.CurrentHeadCustomization?.ToString());
    }
}
