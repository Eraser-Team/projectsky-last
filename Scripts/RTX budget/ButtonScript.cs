/*
 * Project Sky - da
 * Copyright (C) 2024 Eraser-Team
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
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
