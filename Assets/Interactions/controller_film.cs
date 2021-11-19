using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class controller_film : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    public VideoPlayer videoPlayerControlled;
    public Renderer offon;
    private Renderer _myRenderer;

    void Start()
    {
        SetMaterial(false);
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
        if(videoPlayerControlled.isPlaying){
			videoPlayerControlled.Pause();
		}else{
			videoPlayerControlled.Play();
		}
	}


    /// Value `true` if this object is being gazed at, `false` otherwise.
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
           offon.material= gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
