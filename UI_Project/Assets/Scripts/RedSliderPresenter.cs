using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class RedSliderPresenter : MonoBehaviour
{
	[SerializeField]
	GameObject imageObj;	// 色を変える画像

	[SerializeField]
	GameObject valueObj;	// 現在の値を反映させるInputField

	[SerializeField]
	Image backgroundImage;	// スライダ背景画像

	[SerializeField]
	Image fillImage;		// スライダゲージ画像


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
				pv.SetRed(color.r);

				// InputFieldに値を反映
				inputfield.text = ((int)(color.r * 255.0f)).ToString();

				// スライダの色を変える
				backgroundImage.color = new Color(255, 1 - color.r, 1 - color.r);
				fillImage.color = new Color(255, 1 - color.r, 1 - color.r);
			});

		// slider→modelの反映
		slider
			.OnValueChangedAsObservable()
			.DistinctUntilChanged()
			.Subscribe(r => {

				// modelに色を反映
				icm.colorRP.Value = new Color(r, icm.colorRP.Value.g, icm.colorRP.Value.b);
			});
	}
}
