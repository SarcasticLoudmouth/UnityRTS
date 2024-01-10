
using Mirror;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;




public class UnitSpawner : NetworkBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject unitPrefab = null;
    [SerializeField] private Transform unitSpawnPoint = null;


    #region Server

    [Command]
    private void CmdSpawnUnit()
    {
        GameObject unitInstance = Instantiate(
            unitPrefab.gameObject,
            unitSpawnPoint.position,
            unitSpawnPoint.rotation);

        
        NetworkServer.Spawn(unitInstance, connectionToClient);
    }

    #endregion

    #region Client

 public void OnMouseDown()
    {
        if (!hasAuthority) return;
 
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
 
            CmdSpawnUnit();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
    #endregion




