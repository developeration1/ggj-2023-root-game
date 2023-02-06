using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text completionText;

    private void Update()
    {
        // UpdateWaterUI(GameManager.Instance.lifeManager.currentLife);

    }

    public void UpdateCompletion(float completion)
    {
        completionText.text = completion.ToString() + "%";
    }
}
