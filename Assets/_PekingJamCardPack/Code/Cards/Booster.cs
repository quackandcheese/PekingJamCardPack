using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnboundLib;
using UnityEngine;

public class Booster : MonoBehaviour
{
    Player player;
    private float boostStrength = 100f;

    public void Start()
    {
        player = GetComponentInParent<Player>();
    }
    public void Boost()
    {
        player.data.playerVel.SetFieldValue("velocity", (Vector2)player.data.playerVel.GetFieldValue("velocity") + (Vector2)(-player.data.aimDirection * boostStrength));
    }
}
