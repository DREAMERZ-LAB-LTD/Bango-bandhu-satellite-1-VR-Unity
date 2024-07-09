using UnityEngine;

public abstract class EjectionStage: MonoBehaviour
{
    public EjectionStage nextejection = null;
    public abstract void ExecuteOperation();
    
}
