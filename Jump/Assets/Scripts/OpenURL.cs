using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public string Url;

    public void URLOpen()
    {
        Application.OpenURL(Url);
    }
}
