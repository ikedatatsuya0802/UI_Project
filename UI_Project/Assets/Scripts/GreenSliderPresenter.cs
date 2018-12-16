using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GreenSliderPresenter : MonoBehaviour
{
	[SerializeField]
	GameObject imageObj;    // 色を変える画像

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
				pv.SetGreen(color.g);

				// InputFieldに値を反映
				inputfield.text = ((int)(color.g * 255.0f)).ToString();

				// スライダの色を変える
				backgroundImage.color = new Color(1 - color.g, 255, 1 - color.g);
				fillImage.color = new Color(1 - color.g, 255, 1 - color.g);
			});

		// slider→modelの反映
		slider
			.OnValueChangedAsObservable()
			.DistinctUntilChanged()
			.Subscribe(g => {

				// modelに色を反映
				icm.colorRP.Value = new Color(icm.colorRP.Value.r, g, icm.colorRP.Value.b);
			});
	}
}
