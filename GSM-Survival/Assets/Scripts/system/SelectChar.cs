using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character;
    SpriteRenderer sr;
    public SelectChar[] chars;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerAudio = GetComponent<AudioSource>();
        if (DataMgr.instance.currentCharacter == character) FirstSelect();
        else OnDeSelect();
    }

    private void Update()
    {

    }

    private void OnMouseUpAsButton()
    {
        DataMgr.instance.currentCharacter = character;
        OnSelect();
        for(int i = 0; i < chars.Length; i++)
        {
            if (chars[i] != this) chars[i].OnDeSelect();
        }
    }
    void OnDeSelect()
    {
        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }

    void OnSelect()
    {
        sr.color = new Color(1f, 1f, 1f);
        playerAudio.Play();
        Invoke("AudioStop", 0.8f);
    }

    void FirstSelect()
    {
        sr.color = new Color(1f, 1f, 1f);
    }

    void AudioStop()
    {
        playerAudio.Stop();
    }
}
