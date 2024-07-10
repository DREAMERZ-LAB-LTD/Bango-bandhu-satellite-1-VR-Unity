using UnityEngine;

public abstract class EjectionStage: MonoBehaviour
{
    public EjectionStage nextejection = null;
    protected abstract void ExecuteOperation();
    
}
