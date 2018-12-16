using UnityEngine;
using UniRx;

public class ImageColorModel : MonoBehaviour
{
	Color color;    // 画像の色

	public ColorReactiveProperty colorRP = new ColorReactiveProperty();
	

	void Start()
	{
		// ReactivePropertyの値の初期化
		colorRP.Value = Color.black;
	}
}
