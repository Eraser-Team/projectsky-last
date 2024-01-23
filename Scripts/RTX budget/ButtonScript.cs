using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject targetObject;
    public int value1 = 256;
    public int value2 = 512;
    public int value3 = 1024;
	public int value4 = 2048;

	private void FuckingMagic(bool b)
	{
		targetObject.GetComponent<MirrorReflection>().enabled = b;
	}
	
    public void On256()
    {
		FuckingMagic(true);
        targetObject.GetComponent<MirrorReflection>().m_TextureSize = value1;
    }

    public void On512()
    {
		FuckingMagic(true);
        targetObject.GetComponent<MirrorReflection>().m_TextureSize = value2;
    }

    public void On1024()
    {
		FuckingMagic(true);
        targetObject.GetComponent<MirrorReflection>().m_TextureSize = value3;
    }
	
	public void On2048()
	{
		FuckingMagic(true);
        targetObject.GetComponent<MirrorReflection>().m_TextureSize = value4;
	}

	public void OffReflections()
	{
		FuckingMagic(false);
	}
}
