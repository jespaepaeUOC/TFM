using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PopUpTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+Time.deltaTime*1.5f, transform.position.z);
    }

    public void ChangeText(String newText)
    {
        this.GetComponent<TextMeshProUGUI>().text = newText;
    }

    public void ChangeTextSize(float size)
    {
        this.GetComponent<TextMeshProUGUI>().fontSize = size;
    }

    public void ChangeTextColor(float r, float g, float b)
    {
        this.GetComponent<TextMeshProUGUI>().color = new Color(r,g,b);
    }

    private IEnumerator DestroyAfterSeconds() {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
