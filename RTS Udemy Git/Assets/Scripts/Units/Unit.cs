using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class Unit : NetworkBehaviour
{
   [SerializeField] private UnitMovement unitMovement = null;
   [SerializeField] private UnityEvent onSelected = null;
   [SerializeField] private UnityEvent onDeSelected = null;

   public static event Action<Unit> ServerOnUnitSpawned;
   public static event Action<Unit> ServerOnUnitDespawned;   
   public static event Action<Unit> AuthorityOnUnitSpawned;
   public static event Action<Unit> AuthorityOnUnitDespawned;


public UnitMovement GetUnitMovement()
{
    return unitMovement;
}

   #region Server
public override void OnStartServer()
{
    ServerOnUnitSpawned?.Invoke(this);
}

public override void OnStopServer()
{
    ServerOnUnitDespawned?.Invoke(this);
}

    #endregion

    #region Client

    public override void OnStartClient()
    {
        if(!isClientOnly || !hasAuthority) {return;}
        
        AuthorityOnUnitSpawned?.Invoke(this);
    }

    public override void OnStopClient()
    {
        AuthorityOnUnitDespawned?.Invoke(this);
    }

    [Client]
    public void Select()
    {
        if(!hasAuthority) {return;}
     
        onSelected?.Invoke();
    }

[Client]
public void Deselect()
{
    if(!hasAuthority) {return;}
    
    onDeSelected?.Invoke();
}

    #endregion
 
}
