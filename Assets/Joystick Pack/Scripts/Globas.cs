using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Globas : MonoBehaviour
{
    public FixedJoystick fixedjoystik;
    public FixedButton JumpButton;
    public FixedTouchField touchfield;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var fps = GetComponent<FirstPersonController>();
        fps.Jump = JumpButton.Pressed;
     
    }
}
