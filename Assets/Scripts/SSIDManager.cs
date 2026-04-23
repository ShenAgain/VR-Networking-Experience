using UnityEngine;
using TMPro;

public class SSIDManager : MonoBehaviour
{
    public NetworkDevice accessPoint;
    public TMP_Text ssidText;

    public void SetSSID(string newSSID)
    {
        accessPoint.ssid = newSSID;
        UpdateUI();
    }

    void OnEnable()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (ssidText != null)
            ssidText.text = "SSID: " + accessPoint.ssid;
    }
}