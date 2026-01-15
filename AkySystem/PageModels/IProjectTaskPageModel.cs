using AkySystem.Models;
using CommunityToolkit.Mvvm.Input;

namespace AkySystem.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}