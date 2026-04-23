using UnityEngine;

public class NetworkDevice : MonoBehaviour
{
    public string deviceName;

    public string ipAddress;
    public string subnet = "255.255.255.0";
    public string gateway;

    public bool useDHCP = false;

    public string ssid = "DefaultWifi";
}