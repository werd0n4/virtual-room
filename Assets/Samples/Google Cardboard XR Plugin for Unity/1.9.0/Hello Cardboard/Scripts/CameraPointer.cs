//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;
    public float speed = 1f;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }


        if (Input.GetKey("joystick button 0" ))// B comp// android  B patrz po komentarzach, nie debugu
		{
			//Debug.Log("Hello: B?");
			// transform.Translate(0, speed*Time.deltaTime, 0);
			//maincam.transform.position = new Vector3(0.18f, 0.9f, 0.2f);
			_gazedAtObject?.SendMessage("OnPointerClick");//start interaction of gazedAtObeject-> go see OnPointerClick in ObjectController of that object
		}//OK
		
		if (Input.GetKeyDown("joystick button 1" ))// D //android D
		{
			//Debug.Log("Hello: android D?");
		}
		
		if (Input.GetKey("joystick button 2" ))// B comp// android C 
		{
			//Debug.Log("Hello: android C?");
			transform.Translate(0, -speed*Time.deltaTime, 0);
			//maincam.transform.position = new Vector3(0.18f, 0.9f, 0.2f);
		}
		
		if (Input.GetKey("joystick button 3" ))//C comp//android A
		{
			//Debug.Log("Hello: android A?");
			//maincam.transform.position = new Vector3(0.3f, 0.9f, 2f);
			//transform.Translate(0, speed*Time.deltaTime, 0);//C move camera UP
			//heightStatePlus=true;
		}
		
		//@B mode android test , https://gamepad-tester.com/ -------------------------- BLUETOOTH CONTROLLER HANDLING
		if (Input.GetKeyDown("joystick button 4" ))//A  //android maly gorny
		{
			//Debug.Log("Hello: maly gorny android?");
			// _gazedAtObject?.SendMessage("OnPointerClick");//start interaction of gazedAtObeject-> go see OnPointerClick in ObjectController of that object
		}
		
		if (Input.GetKey("joystick button 5" ))//C //android duzy gorny
		{
			//Debug.Log("Hello: duzy gorny android?");

		}

        float translationVer = Input.GetAxis("Vertical") * speed;	
		float translationHor = Input.GetAxis("Horizontal") * speed;
		
		translationHor *= Time.deltaTime;
		translationVer *= Time.deltaTime;     
		transform.Translate(0, 0, translationVer);// do przodu do tyłu
		transform.Translate(translationHor, 0, 0);//prawo lewo


	    //if testing env- only for presentation of code, or it can be... full support for keyboard and android
		if(true){	
			if (Input.GetKey("e" ))//C
			{
				transform.Translate(0, speed*Time.deltaTime, 0);
			}
			if (Input.GetKey("q" ))//C
			{
				transform.Translate(0, -speed*Time.deltaTime, 0);
			}
			if (Input.GetKey("r" ))//C
			{
				transform.Rotate(0, -30*speed*Time.deltaTime, 0);
			}
			if (Input.GetKey("t" ))//C
			{
				transform.Rotate(0, 30*speed*Time.deltaTime, 0);
			}
			if (Input.GetKey("f" ))//C
			{
				transform.Rotate(-30*speed*Time.deltaTime, 0, 0);
			}
			if (Input.GetKey("v" ))//C
			{
				transform.Rotate(30*speed*Time.deltaTime, 0, 0);
			}
			//PC doesnt need this, for android without controller
			if (Input.GetKey("z" ))//C
			{
				//transform.Rotate(30*speed*Time.deltaTime, 0, 0);
				transform.Translate(0,0 , -speed*Time.deltaTime);
			}
			if (Input.GetKey("x" ))//C
			{
				transform.Translate(0,0 , speed*Time.deltaTime);
				//transform.Rotate(30*speed*Time.deltaTime, 0, 0);
			}
			//both adnroid support and Pc
			if(Input.GetKeyUp("space"))
			{
				_gazedAtObject?.SendMessage("OnPointerClick");//start interaction of gazedAtObeject-> go see OnPointerClick in ObjectController of that object
			}
		}   
    }
}
