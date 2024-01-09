using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RTSPlayer : NetworkBehaviour
{
   private List<Unit> myUnits = new List<Unit>();

   #region Server

    public override void OnStartServer()
    {
        Unit.ServerOnUnitSpawned += ServerHandleUnitSpawned;
        Unit.ServerOnUnitDespawned += ServerHandleUnitDespawned;
    }

    public override void OnStopServer()
    {
        Unit.ServerOnUnitSpawned -= ServerHandleUnitSpawned;
        Unit.ServerOnUnitDespawned -= ServerHandleUnitDespawned;
    }

    private void ServerHandleUnitSpawned(Unit unit)
    {
        if(unit.connectionToClient.connectionId != connectionToClient.connectionId) {return;}

        myUnits.Add(unit);
    }
    private void ServerHandleUnitDespawned(Unit unit)
    {

    }
    #endregion

    #region Client

    public override void OnStartClient()
    {
        if (!isClientOnly) { return; }
        
        Unit.ServerOnUnitSpawned += ServerHandleUnitSpawned;
        Unit.ServerOnUnitDespawned += ServerHandleUnitDespawned;
    }

    public override void OnStopClient()
    {
        if (!isClientOnly) { return; }

        Unit.AuthorityOnUnitSpawned -= ServerHandleUnitSpawned;
        Unit.AuthorityOnUnitDespawned -= ServerHandleUnitDespawned;
    }


    #endregion 
}
