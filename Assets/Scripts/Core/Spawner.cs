using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Spawner : NetworkBehaviour
{
    [SerializeField] private NetworkIdentity _prefab;


    public override void OnStartServer()
    {

        base.OnStartServer();
        
        
        

    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit))
                {
                    Spawn(hit.point);
                }
                
            }
           
        }
    }
    void Spawn(Vector3 pos)
    {
        NetworkIdentity gm = Instantiate(_prefab, pos, Quaternion.identity);
        NetworkServer.Spawn(gm.gameObject);
    }
}
