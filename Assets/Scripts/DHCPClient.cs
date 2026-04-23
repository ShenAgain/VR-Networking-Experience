using UnityEngine;
using TMPro;

public class DHCPClient : MonoBehaviour
{
    public NetworkDevice targetDevice;
    public RouterDHCP router;

    public TMP_Text ipText;
    public TMP_Text gatewayText;
    public TMP_Text dhcpText;

    // =========================
    // USE DHCP
    // =========================
    public void UseDHCP()
    {
        string newIP = router.GetNextIP();

        if (newIP == "")
        {
            Debug.Log("DHCP is disabled on router.");
            return;
        }

        targetDevice.useDHCP = true;

        targetDevice.ipAddress = newIP;
        targetDevice.subnet = "255.255.255.0";
        targetDevice.gateway =
            router.GetComponent<NetworkDevice>().ipAddress;

        UpdateUI();
    }

    // =========================
    // GENERIC STATIC IP METHOD
    // =========================
    public void SetStaticIP(string ip, string gateway)
    {
        targetDevice.useDHCP = false;

        targetDevice.ipAddress = ip;
        targetDevice.subnet = "255.255.255.0";
        targetDevice.gateway = gateway;

        UpdateUI();
    }

    // =========================
    // PRESET BUTTON METHODS
    // =========================
    public void SetStatic192()
    {
        SetStaticIP("192.168.1.50", "192.168.1.1");
    }

    public void SetStatic10()
    {
        SetStaticIP("10.0.0.50", "10.0.0.1");
    }

    public void SetStatic172()
    {
        SetStaticIP("172.16.0.50", "172.16.0.1");
    }

    // =========================
    // UPDATE UI TEXT
    // =========================
    public void UpdateUI()
    {
        if (ipText != null)
            ipText.text = "IP: " + targetDevice.ipAddress;

        if (gatewayText != null)
            gatewayText.text = "Gateway: " + targetDevice.gateway;

        if (dhcpText != null)
            dhcpText.text =
                "DHCP: " +
                (targetDevice.useDHCP ? "Enabled" : "Disabled");
    }

    // =========================
    // SHOW INFO ON START
    // =========================
    void Start()
    {
        UpdateUI();
    }
}