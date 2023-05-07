using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Config;
using MagicCubes.Events;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class ProgressStarSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<RotateEvent> _rotateFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<CurrentLvlComponent> _currenLvlFilter = null;
        private readonly Configurations _configurations;

        private const string ProgressBarStar1 = "ProgressBarStar1";
        private const string ProgressBarStar2 = "ProgressBarStar2";
        private const string ProgressBarStar3 = "ProgressBarStar3";
        private const string StarImage1 = "StarImage1";
        private const string StarImage2 = "StarImage2";
        private const string StarImage3 = "StarImage3";
        private const string RotationsAmountToLoseStar1 = "RotationsAmountToLoseStar1";
        private const string RotationsAmountToLoseStar2 = "RotationsAmountToLoseStar2";
        private const string RotationsAmountToLoseStar3 = "RotationsAmountToLoseStar3";


        public void Init()
        {
            foreach (var i in _uiFilter)
            {
                _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(StarImage1).style.display = DisplayStyle.Flex;
                _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(StarImage2).style.display = DisplayStyle.Flex;
                _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(StarImage3).style.display = DisplayStyle.Flex;
                foreach (var j in _currenLvlFilter)
                {
                    var id = _currenLvlFilter.Get1(j).Id;
                    _uiFilter.Get1(i).UIDocument.rootVisualElement.Q<Label>(RotationsAmountToLoseStar1).text = $"{_configurations.LvlHolderConfig.LvlData[id].NumStepForLoseThirdStar}";
                    _uiFilter.Get1(i).UIDocument.rootVisualElement.Q<Label>(RotationsAmountToLoseStar2).text = $"{_configurations.LvlHolderConfig.LvlData[id].NumStepForLoseSecondStar}";
                }
            }
        }

        public void Run()
        {
            foreach (var index in _rotateFilter)
            {
                foreach (var i in _uiFilter)
                {
                    foreach (var j in _currenLvlFilter)
                    {
                        CurrentLvlComponent currentLvlComponent = _currenLvlFilter.Get1(j);
                        int id = currentLvlComponent.Id;
                        float currentScore = currentLvlComponent.CurrentScore;
                        float numStepForLoseSecondStar = _configurations.LvlHolderConfig.LvlData[id].NumStepForLoseSecondStar;
                        float numStepForLoseThirdStar = _configurations.LvlHolderConfig.LvlData[id].NumStepForLoseThirdStar;

                        Label label1 = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q<Label>(RotationsAmountToLoseStar1);
                        Label label2 = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q<Label>(RotationsAmountToLoseStar2);
                        label1.text = $"{numStepForLoseThirdStar}";
                        label2.text = $"{numStepForLoseSecondStar}";
                        if (currentScore > numStepForLoseSecondStar)
                        {
                            VisualElement visualElement = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(ProgressBarStar2);
                            VisualElement starImage = visualElement.Q(StarImage2);
                            starImage.style.display = DisplayStyle.None;
                        }
                        else if (currentScore > numStepForLoseThirdStar)
                        {
                            VisualElement visualElement = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(ProgressBarStar1);
                            VisualElement starImage = visualElement.Q(StarImage1);
                            starImage.style.display = DisplayStyle.None;
                        }
                    }
                }
            }
        }
    }
}
