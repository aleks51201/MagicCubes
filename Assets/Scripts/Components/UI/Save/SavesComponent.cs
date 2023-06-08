using System;

namespace MagicCubes.Components.Ui.Save
{
    public struct SavesComponent
    {
        public Level[] Levls;
    }

    [Serializable]
    public class Level
    {
        public string SceneName;
        public int Stars;
    }
}
