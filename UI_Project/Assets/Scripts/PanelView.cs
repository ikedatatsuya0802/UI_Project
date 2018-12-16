using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
	Image image;	// 色を変える画像


	// Use this for initialization
	void Start()
	{
		image = GetComponent<Image>();
	}

	public void SetRed(float r)
	{
		image.color = new Color(r, image.color.g, image.color.b);
	}

	public void SetGreen(float g)
	{
		image.color = new Color(image.color.r, g, image.color.b);
	}

	public void SetBlue(float b)
	{
		image.color = new Color(image.color.r, image.color.g, b);
	}
}
