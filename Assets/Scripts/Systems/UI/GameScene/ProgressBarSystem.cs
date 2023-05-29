using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Config;
using MagicCubes.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class ProgressBarSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<RotateEvent> _rotateFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<CurrentLvlComponent> _currenLvlFilter = null;
        private readonly Configurations _configurations;

        private const string ProgressDisplay = "ProgressDisplay";


        public void Init()
        {
            foreach (int i in _uiFilter)
            {
                _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(ProgressDisplay).style.height = Length.Percent(0);
            }
        }

        public void Run()
        {
            foreach (int index in _rotateFilter)
            {
                foreach (int i in _uiFilter)
                {
                    foreach (int j in _currenLvlFilter)
                    {
                        CurrentLvlComponent currentLvlComponent = _currenLvlFilter.Get1(j);
                        int id = currentLvlComponent.Id;
                        float currentScore = currentLvlComponent.CurrentScore;
                        float numStepForLoseSecondStar = _configurations.LvlHolderConfig.LvlData[id].NumStepForLoseSecondStar;
                        float numStepForLoseThirdStar = _configurations.LvlHolderConfig.LvlData[id].NumStepForLoseThirdStar;

                        if (currentScore > numStepForLoseThirdStar && currentScore < numStepForLoseSecondStar)
                        {
                            Length percent = Length.Percent((currentScore - numStepForLoseThirdStar) / (numStepForLoseSecondStar - numStepForLoseThirdStar) * 100f);
                            _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(ProgressDisplay).style.height = percent;
                        }
                        else if (currentScore < numStepForLoseThirdStar)
                        {
                            Length percent = Length.Percent(currentScore / numStepForLoseThirdStar * 100f);
                            _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(ProgressDisplay).style.height = percent;
                        }
                        else
                        {
                            _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(ProgressDisplay).style.height = Length.Percent(100f);
                        }
                    }
                }
            }
        }
    }
}
