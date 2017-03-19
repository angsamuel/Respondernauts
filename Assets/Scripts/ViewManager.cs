using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ViewManager : MonoBehaviour {

    public GameObject applications_panel;
    public GameObject squad_panel;
    public GameObject missions_panel;

    public GameObject missions_manager;
    // Use this for initialization
    void Start () {
        OpenApplicationsPanel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void HidePanels()
    {
        applications_panel.transform.position = new Vector3(0, 0, -1000);
        squad_panel.transform.position = new Vector3(0, 0, -1000);
        missions_panel.transform.position = new Vector3(0, 0, -1000);
    }
    public void OpenSquadPanel()
    {
        HidePanels();
        squad_panel.transform.position = new Vector3(0, 0, 0);
    }
    public void OpenApplicationsPanel()
    {
        HidePanels();
        applications_panel.transform.position = new Vector3(0, 0, 0);
    }
    public void OpenMissionsPanel()
    {
        HidePanels();
        missions_panel.transform.position = new Vector3(0, 0, 0);
        missions_manager.GetComponent<MissionsManager>().FillMissionDetails(0);
    }
}
