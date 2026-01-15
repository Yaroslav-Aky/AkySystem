using AkySystem.Models;

namespace AkySystem.Pages;

public partial class ProjectDetailPage : ContentPage
{
    public ProjectDetailPage(ProjectDetailPageModel model)
    {
        InitializeComponent();

        BindingContext = model;
    }
}
