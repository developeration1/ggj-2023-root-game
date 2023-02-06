using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    //public TMP_Text waterText;

    private void Update()
    {
        UpdateWaterUI(GameManager.Instance.lifeManager.currentLife);
    }

    public void UpdateWaterUI(float waterQuantity)
    {
        //waterText.text = "Water:" + waterQuantity.ToString();
    }
}
