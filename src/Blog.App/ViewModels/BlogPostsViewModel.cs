using Blog.Core.Services;

namespace Blog.App.ViewModels
{
    public partial class BlogPostsViewModel : BaseViewModel
    {
        public ObservableCollection<BlogPost> BlogPosts { get; } = new();

        private readonly IBlogService _blogService;
        
        public BlogPostsViewModel(IBlogService blogService)
        {
            Title = "Blog Posts";
            _blogService = blogService;
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetBLogPostsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var blogPosts = await _blogService.GetBlogPostsAsync();

                if (BlogPosts.Count != 0)
                    BlogPosts.Clear();

                foreach (var blogPost in blogPosts.BlogPosts)
                    BlogPosts.Add(blogPost);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get blogPosts: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }

    }
}
