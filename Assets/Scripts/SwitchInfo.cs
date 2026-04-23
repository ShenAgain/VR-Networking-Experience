using UnityEngine;
using TMPro;

public class SwitchInfo : MonoBehaviour
{
    public NetworkDevice switchDevice;
    public TMP_Text infoText;

    void OnEnable()
    {
        if (switchDevice == null || infoText == null)
            return;

        infoText.text =
            "IP: " + switchDevice.ipAddress + "\n" +
            "Subnet: " + switchDevice.subnet + "\n" +
            "Gateway: " + switchDevice.gateway;
    }
}