using UnityEngine;
using UnityEngine.UIElements;

public class PlayButtonClick : MonoBehaviour
{
    private const string UIHolder = "UIHolder";
    private const string StartButton = "StartButton";

    [SerializeField] private VisualTreeAsset _gameUI;

    private Button _btn;
    private UIDocument _uIDocument;


    private void OnClick(ClickEvent clickEvent)
    {
        _uIDocument = GetComponent<UIDocument>();
        var i = _uIDocument.rootVisualElement.Q(UIHolder);
        //i.style.display = DisplayStyle.None;
        _uIDocument.visualTreeAsset = _gameUI;
    }

    private void OnEnable()
    {
        _btn = GetComponent<UIDocument>().rootVisualElement.Q<Button>(StartButton);
        _btn.RegisterCallback<ClickEvent>(OnClick);
    }
}
