using UnityEngine;

public class RouterACL : MonoBehaviour
{
    public bool blockPCToServer = false;
    public bool blockAPToServer = false;
    public bool blockPCToRouter = false;

    public void AllowAll()
    {
        blockPCToServer = false;
        blockAPToServer = false;
        blockPCToRouter = false;
    }

    public void BlockPCToServer()
    {
        AllowAll();
        blockPCToServer = true;
    }

    public void BlockAPToServer()
    {
        AllowAll();
        blockAPToServer = true;
    }

    public void BlockPCToRouter()
    {
        AllowAll();
        blockPCToRouter = true;
    }

    public bool IsBlocked(NetworkDevice source, NetworkDevice target)
    {
        if (source.deviceName == "PC" &&
            target.deviceName == "Server" &&
            blockPCToServer)
            return true;

        if (source.deviceName == "Access Point" &&
            target.deviceName == "Server" &&
            blockAPToServer)
            return true;

        if (source.deviceName == "PC" &&
            target.deviceName == "Router" &&
            blockPCToRouter)
            return true;

        return false;
    }
}