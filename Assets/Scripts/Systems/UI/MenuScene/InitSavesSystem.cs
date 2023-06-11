using Leopotam.Ecs;
using MagicCubes.Components.Ui.Save;
using MagicCubes.Config;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCubes.Systems.UI.MenuScene
{
    public class InitSavesSystem : IEcsInitSystem
    {
        private readonly Configurations _configurations;

        private const string KEY = "GameSaves";

        public void Init()
        {
            if (!PlayerPrefs.HasKey(KEY))
            {
                CreateSave();
            }
        }

        private void CreateSave()
        {
            List<Level> levels = new();
            foreach (var lvl in _configurations.LvlHolderConfig.LvlData)
            {
                levels.Add(new Level() { SceneName = lvl.SceneName, Stars = 0 });
            }
            SavesComponent savesComponent = new() { Levls = levels.ToArray() };
            string str = JsonConvert.SerializeObject(
                savesComponent,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            PlayerPrefs.SetString(KEY, str);
        }
    }
}
