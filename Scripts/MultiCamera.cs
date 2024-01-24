using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MultiCamera : NetworkBehaviour
{
    public Camera myCamera;
    void Start() {
        myCamera.depth = 0;
        if (isLocalPlayer) { myCamera.depth = 1; }
    }
}
