using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewUsername : MonoBehaviour {

	public  InputField field_Username;
	public  InputField field_Password;

	 public string inputUserName;
	public string inputPassword;
	public string backData_str;

	string CreateUserUrl = "https://ea2.ir/Game_Dir/PHP/GDB_Register.php";

	// Use this for initialization
	//void Start () {
	//}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			CreateUser (inputUserName, inputPassword);
		}
			
	}

	// Create Username nad Password
	public void CreateUser(string username , string password)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("US_NAME",username);
		form.AddField ("US_PASS",password);
		WWW www = new WWW (CreateUserUrl , form);
		StartCoroutine(WaitForRequest(www));

	}

	public void creat_User()
	{
		inputUserName= field_Username.text;
		inputPassword= field_Password.text;

		CreateUser (inputUserName, inputPassword);
	}


	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

			// check for errors
			if (www.error == null)
				{
					Debug.Log("WWW Ok!: " + www.text);// contains all the data sent from the server
				} 
				else 
					{
						Debug.Log("WWW Error: "+ www.error);
					}    




		backData_str =www.text;





		switch (backData_str) 
		{
		case "Register_Done":
			{
				print ("Register_Done");
				SceneManager.LoadScene ("SignUp_Done");
			}
			break;

		case "Register_Failed":
			{
				print ("Register_Failed");
				SceneManager.LoadScene ("SignUp_Failed");

			}
			break;
		case "Duplicate_Username":
			{
				print ("Duplicate_Username");
				SceneManager.LoadScene ("SignUp_Failed2");

			}
			break;
		}
	}
}

