using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private Item _item;
    
    private readonly SyncList<Item> _items = new();

    public override void OnStartClient()
    {
        Debug.Log("OnStartClient:");
        
        ViewItems();
    }
    
    private void Start()
    {
        if (!isClient)
        {
            return;
        }
        
        Debug.Log("Start:");
            
        ViewItems();
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        
        var item = Instantiate(_item);

        item.name = _item.name;
            
        _items.Add(item);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ViewItems();
        }
    }

    private void ViewItems()
    {
        Debug.Log("ViewItems: ");
        
        foreach (var i in _items)
        {
            Debug.Log("Item: " + i + ", instance ID: " + i?.GetInstanceID());
        }
    }
}
