using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHelp2 : MonoBehaviour
{
    public void OnClick(){
        transform.position = transform.position + new Vector3(+1 * Screen.width, 0, 0);
    }
}
