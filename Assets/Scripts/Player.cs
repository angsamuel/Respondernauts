using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public List<Naut> nauts;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        nauts = new List<Naut>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
