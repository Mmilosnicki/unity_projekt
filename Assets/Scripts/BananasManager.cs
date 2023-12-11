using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananasManager : MonoBehaviour
{
    public int bananasCount;
    public Text bananasCountText;

    void Update()
    {
        bananasCountText.text = "- " + bananasCount.ToString();
    }
}
