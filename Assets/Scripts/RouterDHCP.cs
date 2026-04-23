using UnityEngine;
using TMPro;

public class RouterDHCP : MonoBehaviour
{
    public string networkBase = "192.168.1.";
    public int nextIP = 100;

    public bool dhcpEnabled = true;

    public TMP_Text statusText;

    public string GetNextIP()
    {
        if (!dhcpEnabled)
            return "";

        string newIP = networkBase + nextIP;
        nextIP++;
        return newIP;
    }

    public void EnableDHCP()
    {
        dhcpEnabled = true;
        Debug.Log("DHCP Enabled");
        UpdateStatus();
    }

    public void DisableDHCP()
    {
        dhcpEnabled = false;
        Debug.Log("DHCP Disabled");
        UpdateStatus();
    }

    public void SetNetwork(string newBase)
    {
        networkBase = newBase;
        nextIP = 100;

        UpdateStatus();
    }

    void Start()
    {
        UpdateStatus();
    }

    void UpdateStatus()
    {
        if (statusText == null)
            return;

        statusText.text =
            "Network: " + networkBase + "x\n" +
            "DHCP: " + (dhcpEnabled ? "ON" : "OFF") + "\n" +
            "Router IP: " + networkBase + "1";
    }
}