﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
	#region : attributs

	GameObject player;

	float cur_health;

	System.Random rand = new System.Random();
	#endregion

	void Start()
	{
		SetPlayerPrefs ();
		Save ();
		player = GameObject.Find ("Player");
		cur_health = player.GetComponent<PlayerHealth> ().health;
	}

	void Update()
	{
		if (CheckPoint.CPactive)
			Debug.Log ("0");
			SetPlayerPrefs ();
			Save ();

		if (Input.GetKey (KeyCode.L))
			Load ();
	}

	void Save()
	{
		PlayerPrefs.Save();

		BinaryFormatter binform = new BinaryFormatter ();
		FileStream fstream = File.Create(Application.persistentDataPath + "savefile.dat");

		WeaponBase save_data = GetComponent<WeaponBase>();
		save_data.OnBeforeSerialize ();

		binform.Serialize (fstream, save_data.save_weapons);
		fstream.Close ();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "savefile.dat")) 
		{
			BinaryFormatter binform = new BinaryFormatter ();

			FileStream fstream = File.Open (Application.persistentDataPath + "savefile.dat", FileMode.Open);
			List<WeaponBase.SerializableWeaponCharacteristics> saved_weapons = (List<WeaponBase.SerializableWeaponCharacteristics> )binform.Deserialize (fstream);
			fstream.Close ();

			GetComponent<WeaponBase> ().save_weapons = saved_weapons;
			GetComponent<WeaponBase>().OnAfterDeserialize ();

			LoadPlayerPrefs ();

		}
	}

	public void SetPlayerPrefs()
	{
		// position and rotation save
		PlayerPrefs.SetFloat ("PosX", transform.position.x);
		PlayerPrefs.SetFloat ("PosY", transform.position.y);
		PlayerPrefs.SetFloat ("PosZ", transform.position.z);

		PlayerPrefs.SetFloat ("Rotx", transform.eulerAngles.x);
		PlayerPrefs.SetFloat ("RotY", transform.eulerAngles.y);
		PlayerPrefs.SetFloat ("RotZ", transform.eulerAngles.z);

		// weapon Characteristics save
		PlayerPrefs.SetInt ("CurWeapon", GameVariables.cur_weapon);

		PlayerPrefs.SetInt ("NbMunitions", GameVariables.nbmunition);

		//life save
		PlayerPrefs.SetFloat ("Life", GetComponent<PlayerHealth>().health);
	}

	public void LoadPlayerPrefs()
	{
		// position and rotation load and instantiate
		float x = PlayerPrefs.GetFloat ("PosX");
		float y = PlayerPrefs.GetFloat ("PosY");
		float z = PlayerPrefs.GetFloat ("PosZ");

		float rx = PlayerPrefs.GetFloat ("RotX");
		float ry = PlayerPrefs.GetFloat ("RotY");
		float rz = PlayerPrefs.GetFloat ("RotZ");

		transform.position = new Vector3 (x, y, z);
		transform.rotation = Quaternion.Euler (rx, ry, rz);


		// WeaponCharacteristic load and instantiate
		GameVariables.cur_weapon = PlayerPrefs.GetInt ("CurWeapon");

		GameVariables.nbmunition = PlayerPrefs.GetInt ("NbMunitions");

		cur_health = PlayerPrefs.GetFloat ("Life");

		// health load and instantiate
		if (cur_health <= 20f)
		{
			cur_health += (float)rand.Next (30, 50);
		}
		else if (cur_health <= 40f)
		{
			cur_health += (float)rand.Next (10, 30);
		}
		else if (cur_health <= 60)
		{
			cur_health += (float)rand.Next (10, 20);
		}
		else 
			cur_health = PlayerPrefs.GetFloat ("Life");
	}
}
