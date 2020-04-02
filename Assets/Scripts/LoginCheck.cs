using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginCheck : MonoBehaviour {

	public  InputField field_Username_login;
	public  InputField field_Password_login;

	public string inputUserName_login;
	public string inputPassword_login;
	public string backData_str_login;

	string LoginUserUrl = "https://ea2.ir/Game_Dir/PHP/GDB_Login.php";

	// Use this for initialization
	//void Start () {
	//}

	// Update is called once per frame
	void Update () 
	{


	}

	// Create Username nad Password
	public void LoginUser(string username_login , string password_login)
	{
		WWWForm form_login = new WWWForm ();
		form_login.AddField ("US_NAME",username_login);
		form_login.AddField ("US_PASS",password_login);
		WWW www = new WWW (LoginUserUrl , form_login);
		StartCoroutine(WaitForRequest(www));

	}

	public void login_User()
	{
		inputUserName_login= field_Username_login.text;
		inputPassword_login= field_Password_login.text;

		LoginUser (inputUserName_login, inputPassword_login);
	}


	IEnumerator WaitForRequest(WWW www_login)
	{
		yield return www_login;

		// check for errors
		if (www_login.error == null)
		{
			Debug.Log("WWW Ok!: " + www_login.text);// contains all the data sent from the server
		} 
		else 
		{
			Debug.Log("WWW Error: "+ www_login.error);
		}    




		backData_str_login =www_login.text;





		switch (backData_str_login) 
		{
		case "Login Successfully":
			{
				print ("Login Successfully");
				SceneManager.LoadScene ("Login_Done");
			}
			break;

		case "Login_Failed":
			{
				print ("Register_Failed");
				SceneManager.LoadScene ("Login_Failed");

			}
			break;
		}
	}
}

