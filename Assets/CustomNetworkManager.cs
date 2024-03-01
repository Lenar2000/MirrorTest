using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    [SerializeField] private GameObject _emptyPlayer;
    
    private GameObject _player;
    
    public override void OnStartServer()
    {
        base.OnStartServer();
        
        _player = Instantiate(playerPrefab);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        NetworkServer.ReplacePlayerForConnection(conn, Instantiate(_emptyPlayer));

        _player.GetComponent<NetworkIdentity>().RemoveClientAuthority();
        
        //base.OnServerDisconnect(conn);
    }
    
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);

        NetworkServer.AddPlayerForConnection(conn, _player);
    }
}
