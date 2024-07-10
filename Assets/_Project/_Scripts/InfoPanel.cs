using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using UnityEngine;
public class InfoPanel : MonoBehaviour
{
    public SatelliteScript _targetPlanet;
    public Transform _iteamPosition;
    private void OnTriggerEnter(Collider other)
    {
        // is there is already a planet  to realese it and attached new as child
        var _temp = other.GetComponentInParent<SatelliteScript>();
        if (_temp != null)
        {
            if (_targetPlanet != null && !_targetPlanet.isGrabe && _targetPlanet.isStay)
            {
                _targetPlanet.MoveToTargetPosition(_targetPlanet.targetObject.transform);
            }
            SelectedPlanet(_temp);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SatelliteScript temp = other.GetComponentInParent<SatelliteScript>();
        if (temp != null)
        {
            ReleasePlanet(temp);
        }
    }

    // To Dipalay the Planet New Position and Attached it's child component 
    private void SelectedPlanet(SatelliteScript newPlanet)
    {
        if (newPlanet != null)
        {
            Debug.Log("Hand Enter ======= " + _targetPlanet);
            _targetPlanet = newPlanet;
            _targetPlanet._infoPanel = GetComponent<InfoPanel>();
            _targetPlanet.isStay = true;
         
        }
    }
    // Ungroup and  send the planet to it's start orbit position
    private void ReleasePlanet(SatelliteScript lastPlanet)
    {
        if (lastPlanet == null) return;
        lastPlanet.isStay = false;
        lastPlanet._infoPanel = null;
        lastPlanet = null;
    }
}
