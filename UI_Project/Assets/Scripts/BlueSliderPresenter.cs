using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class BlueSliderPresenter : MonoBehaviour
{
	[SerializeField]
	GameObject imageObj;	// 色を変える画像

	[SerializeField]
	GameObject valueObj;    // 現在の値を反映させるInputField

	[SerializeField]
	Image backgroundImage;  // スライダ背景画像

	[SerializeField]
	Image fillImage;        // スライダゲージ画像


	void Start()
	{
		ImageColorModel icm = imageObj.GetComponent<ImageColorModel>();
		Slider slider = GetComponent<Slider>();
		PanelView pv = imageObj.GetComponent<PanelView>();
		InputField inputfield = valueObj.GetComponent<InputField>();

		// model→imageの反映
		icm.colorRP
			.Subscribe(color => {

				// viewに色を反映
				pv.SetBlue(color.b);

				// InputFieldに値を反映
				inputfield.text = ((int)(color.b * 255.0f)).ToString();

				// スライダの色を変える
				backgroundImage.color = new Color(1 - color.b, 1 - color.b, 255);
				fillImage.color = new Color(1 - color.b, 1 - color.b, 255);
			});

		// slider→modelの反映
		slider
			.OnValueChangedAsObservable()
			.DistinctUntilChanged()
			.Subscribe(b => {

				// modelに色を反映
				icm.colorRP.Value = new Color(icm.colorRP.Value.r, icm.colorRP.Value.g, b);
			});
	}
}
