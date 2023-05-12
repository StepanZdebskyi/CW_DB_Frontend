using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CW_DB_Frontend.UI.Base;
using CW_DB_Frontend.UI.ViewModels;

namespace CW_DB_Frontend.UI.RedirectionCommands
{
    public class RedirectToPatCasesCommand : CommandBase
    {
        private readonly MyViewModel _model;

        public RedirectToPatCasesCommand(MyViewModel mdl)
        {
            _model = mdl;
        }

        public override void Execute(object parameter)
        {
            _model.CurrentUserControl = "PatCasesControl";
        }
    }
}
