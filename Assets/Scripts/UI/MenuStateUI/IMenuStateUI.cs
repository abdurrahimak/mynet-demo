using System;

namespace MynetDemo.UI
{
    public interface IMenuStateUI
    {
        event Action ClickedPlay;
        void Destroy();
    }
}
