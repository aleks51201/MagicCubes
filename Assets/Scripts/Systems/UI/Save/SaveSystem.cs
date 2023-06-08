using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Components.Ui.Save;
using MagicCubes.Events;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicCubes.Systems.UI.Save
{
    public class SaveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WinEvent> _winFilter;
        private readonly EcsFilter<SavesComponent> _saveFilter;
        private readonly EcsFilter<StarHolderComponent> _starFilter;

        private const string KEY = "GameSaves";


        public void Run()
        {
            foreach(var k in _winFilter)
            {
                foreach (var i in _saveFilter)
                {
                    ref SavesComponent savesComponent = ref _saveFilter.Get1(i);
                    foreach(var j in _saveFilter)
                    {
                        ref StarHolderComponent starHolderComponent = ref _starFilter.Get1(i);
                        if (PlayerPrefs.HasKey(KEY))
                        {
                            savesComponent = UpdateData(savesComponent, starHolderComponent);
                            string str = Serialize(savesComponent);
                            PlayerPrefs.SetString(KEY, str);
                        }
                    }
                }
            }
        }

        private string Serialize(SavesComponent component)
        {
            return JsonConvert.SerializeObject(
                component,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        private SavesComponent UpdateData(SavesComponent savesComponent, StarHolderComponent starHolder)
        {
            foreach (var level in savesComponent.Levls)
            {
                if (level.SceneName != SceneManager.GetActiveScene().name) continue;
                if (level.Stars >= starHolder.StarCount) continue;
                level.Stars = starHolder.StarCount;
            }
            return savesComponent;
        }
    }
}
