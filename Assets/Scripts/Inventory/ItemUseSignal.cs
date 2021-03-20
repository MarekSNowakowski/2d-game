using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemUseSignal : ScriptableObject
{
    [SerializeField]
    protected string itemCode;
    protected ItemUseManager listener;

    public virtual void Raise()
    {
        if (listener == null) Debug.LogWarning("No listeners! Add signal to itemUseManager");
        else listener.OnsignalRaised(itemCode);
    }
    public void RegisterListener(ItemUseManager listener)
    {
        this.listener = listener;
    }
    
    /*
    public void DeRegisterListeners(ItemUseManager listener)
    {
        listener = null;
    }
    */
}