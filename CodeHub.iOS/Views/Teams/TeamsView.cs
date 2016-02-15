using CodeHub.iOS.ViewControllers;
using CodeHub.Core.ViewModels.Teams;
using CodeHub.iOS.DialogElements;
using System;

namespace CodeHub.iOS.Views.Teams
{
    public class TeamsView : ViewModelCollectionDrivenDialogViewController
    {
        public override void ViewDidLoad()
        {
            Title = "Teams";
            NoItemsText = "No Teams";

            base.ViewDidLoad();

            var vm = (TeamsViewModel) ViewModel;
            var weakVm = new WeakReference<TeamsViewModel>(vm);
            this.BindCollection(vm.Teams, x => {
                var e = new StringElement(x.Name);
                e.Clicked.Subscribe(_ => weakVm.Get()?.GoToTeamCommand.Execute(x));
                return e;
            });
        }
    }
}