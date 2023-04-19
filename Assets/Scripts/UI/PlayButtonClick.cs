using UnityEngine;
using UnityEngine.UIElements;

public class PlayButtonClick : MonoBehaviour
{
    private const string UIHolder = "UIHolder";
    private const string StartButton = "StartButton";

    [SerializeField] private UIDocument _uiDocument;
    [SerializeField] private VisualTreeAsset _levelElement;
    [SerializeField] private VisualTreeAsset _levelStar;
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
        //List<Button> g = GetComponent<UIDocument>().rootVisualElement.Query<Button>(StartButton).ToList();
        //_btn = GetComponent<UIDocument>().rootVisualElement.Query<Button>(StartButton);
        /*        foreach(var btn  in g)
                {
                    btn.RegisterCallback<ClickEvent>(OnClick);
                }
        */        //_btn.RegisterCallback<ClickEvent>(OnClick);
    }
}
