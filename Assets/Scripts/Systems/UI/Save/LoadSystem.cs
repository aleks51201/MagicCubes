using Leopotam.Ecs;
using MagicCubes.Components.Ui.Save;
using Newtonsoft.Json;
using UnityEngine;

namespace MagicCubes.Systems.UI.Save
{
    public class LoadSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;

        private const string KEY = "GameSaves";


        public void Init()
        {
            if (PlayerPrefs.HasKey(KEY))
            {
                string str = PlayerPrefs.GetString(KEY);
                _world.NewEntity().Get<SavesComponent>() = Deserialize(str);
            }
        }

        private SavesComponent Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<SavesComponent>(str);
        }
    }
}
