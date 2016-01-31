using UnityEngine;
using System.Collections;

public class SoundExampleScript : MonoBehaviour
{
    public string click_SFX_Name;

    private Renderer mRenderer;

    void Awake()
    {
        mRenderer = GetComponent<Renderer>();
        mRenderer.sharedMaterial.color = Color.blue;
    }

    void OnMouseDown()
    {
        mRenderer.sharedMaterial.color = mRenderer.sharedMaterial.color == Color.blue ? Color.green : Color.blue;

        click_SFX_Name.PlaySound(transform.position);

        //Other ways of calling it:
        //click_SFX_Name.PlaySound();
        //SoundManager.Play(click_SFX_Name);
        //SoundManager.Play(click_SFX_Name, new Vector3(0, 2, 3));
    }
}
