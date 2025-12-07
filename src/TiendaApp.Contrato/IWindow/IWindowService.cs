using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaApp.Contrato.IWindow
{
    public interface IWindowService
    {
        void ShowMainWindow();
        void ShowLoginWindow();
        void CloseCurrentWindow();
    }
}
