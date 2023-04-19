using UnityEngine.UIElements;

namespace MagicCubes.Components.Ui
{
    internal struct StartButtonComponent
    {
        internal Button Button;
        internal ButtonStatusHolder ButtonStatusHolder;
    }

    internal class ButtonStatusHolder
    {
        internal bool IsClicked { get; private set; }


        public ButtonStatusHolder()
        {
            IsClicked = false;

        }


        internal void OnClicked()
        {
            IsClicked = true;
        }

        internal void StatusReset()
        {
            IsClicked = false;
        }
    }
}
