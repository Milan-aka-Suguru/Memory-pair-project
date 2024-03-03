using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mozgatas : MonoBehaviour {
	//Random rnd = new Random();
	// Use this for initialization
	public int sorok;
	public kartyageneralas kartyageneralas;

	void Start () {

		
		
	}
	List<GameObject> indit(){
		List<GameObject> temp = new List<GameObject>();
		GameObject[] kartyaObjects = GameObject.FindGameObjectsWithTag("Kartya");

        // Loop through each GameObject with the tag "Kartya"
        foreach (GameObject obj in kartyaObjects)
        {
			if(obj.name != "peldakartya"){
			temp.Add(obj);
			}
		}
		return temp;
	}
	
	
	// Update is called once per frame
	void Update () {		
	}
	public void keveres(){
		float zz = Math.Abs(GameObject.Find("sarok1").transform.position[2]-GameObject.Find("sarok2").transform.position[2]); //kiszámoljuk a "játszó teret" mind2 dimenzióban, magasságot nem kell számolni
		float xx = Math.Abs(GameObject.Find("sarok1").transform.position[0]-GameObject.Find("sarok2").transform.position[0]); //hiszen az egy statik érték lesz, egy picit feljebb mint az "Asztal"
		// List<GameObject> kartyak = indit(); 
		int db = indit().Count; //megkeresi az összes "kartya" taggel rendelkező elemet és nem veszi figyelembe a példakártyát és lementi a darabszámot majd a listát teli kártyákkal eldobja.
		//fontos, hogy nem tudjuk lementeni globálba, mert ez egy dinamikus változó és a Unity összeszarja magát az ilyentől :P
		Vector3[] temp = new Vector3[db];
		for(int i = 0; i < sorok;i++){
			for(int j = 0; j < db/sorok; j++){
				try{
				kartyak[i*db/sorok+j].transform.position = new Vector3((xx/(sorok)*(i+0.5f))+GameObject.Find("sarok1").transform.position[0],GameObject.Find("Asztal").transform.position[1],zz/(db/sorok)*(j+0.5f)+GameObject.Find("sarok2").transform.position[2]);
				}catch{
					break;
				}
			}
		}
	}
}
