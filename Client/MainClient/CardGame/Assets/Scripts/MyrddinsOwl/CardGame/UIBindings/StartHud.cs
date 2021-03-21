using MyrddinsOwl.Core;
using UnityEngine;
using UnityEngine.UI;

public class StartHud : CheckingBehavior
{
    [SerializeField] private Button _play;
    
    protected override void Awake()
    {             
        base.Awake();
    }
    
    protected override void ValidateFields()
    {            
        LogIfMissing(_play, nameof(_play));
    }
}
