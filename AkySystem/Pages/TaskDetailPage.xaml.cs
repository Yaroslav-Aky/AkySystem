namespace AkySystem.Pages;

public partial class TaskDetailPage : ContentPage
{
    public TaskDetailPage(TaskDetailPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}