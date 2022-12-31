using Blog.App.ViewModels;

namespace Blog.App.Views;

public partial class BlogPosts : ContentPage
{
    public BlogPosts(BlogPostsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}