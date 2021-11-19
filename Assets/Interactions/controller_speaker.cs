using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_speaker : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
	public AudioSource speakerControlled;
    public Renderer offon;
    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    public void Start()
    {
       // _startingPosition = transform.localPosition;
       // _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
        
        Debug.Log("Hello: light?");
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
    }

	public void OnPointerClick(){
        OnClick();
    }
	public void OnClick(){
        if(speakerControlled.isPlaying){
			speakerControlled.Pause();
		}else{
			speakerControlled.Play();
		}
	}


    /// Value `true` if this object is being gazed at, `false` otherwise.
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
           // _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
           offon.material= gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
