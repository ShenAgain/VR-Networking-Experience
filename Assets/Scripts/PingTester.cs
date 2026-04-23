using UnityEngine;
using TMPro;

public class PingTester : MonoBehaviour
{
    public NetworkDevice currentDevice;
    public TMP_Text resultText;

    public RouterACL routerACL;

    public void SetCurrentDevice(NetworkDevice device)
    {
        currentDevice = device;
    }

    public void PingTarget(NetworkDevice target)
    {
        if (currentDevice == null || target == null)
        {
            resultText.text = "Missing Device.";
            return;
        }

        if (string.IsNullOrEmpty(currentDevice.ipAddress) ||
            string.IsNullOrEmpty(target.ipAddress))
        {
            resultText.text = "Device has no IP.";
            return;
        }

        // ACL CHECK
        if (routerACL != null &&
            routerACL.IsBlocked(currentDevice, target))
        {
            resultText.text =
                "Ping to " + target.deviceName +
                " Failed! (Blocked by ACL)";
            return;
        }

        // NORMAL NETWORK CHECK
        if (SameNetwork(currentDevice.ipAddress, target.ipAddress))
        {
            resultText.text =
                "Ping to " + target.deviceName +
                " Successful!";
        }
        else
        {
            resultText.text =
                "Ping to " + target.deviceName +
                " Failed!";
        }
    }

    bool SameNetwork(string ip1, string ip2)
    {
        string[] a = ip1.Split('.');
        string[] b = ip2.Split('.');

        if (a.Length < 4 || b.Length < 4)
            return false;

        return a[0] == b[0] &&
               a[1] == b[1] &&
               a[2] == b[2];
    }
}