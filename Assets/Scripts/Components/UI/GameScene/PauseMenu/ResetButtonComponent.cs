using UnityEngine.UIElements;

namespace MagicCubes.Components.Ui
{
    internal struct ResetButtonComponent
    {
        internal Button Button;
        private ButtonStatusHolder _buttonStatusHolder;
        internal ButtonStatusHolder ButtonStatusHolder;
        /*        internal ButtonStatusHolder ButtonStatusHolder 
                {
                    get
                    {
                        if(_buttonStatusHolder == null)
                        {
                            _buttonStatusHolder = new();
                        }
                        return _buttonStatusHolder;
                    }
                }
        */
    }
}