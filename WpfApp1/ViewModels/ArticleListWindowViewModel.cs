using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.DataAccessLayer;
using WpfApp1.Models;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public class ArticleListWindowViewModel : BindableBase
    {
        public ArticleListWindowViewModel(ArticleService articleService, CategoryService categoryService)
        {
            LoadedCommand = new DelegateCommand(async () => await LoadListAsync());
            ItemSelectedCommand = new DelegateCommand(() =>
            {
                if (SelectedArticle?.Id != null)
                {
                    var window = new ArticleDetailWindow
                    {
                        DataContext = new ArticleDetailWindowViewModel(articleService, categoryService) { OpenArticleId = SelectedArticle.Id }
                    };
                    window.Show();
                }
            });
        }

        private IEnumerable<Article> articles;
        public IEnumerable<Article> Articles
        {
            get
            {
                return articles;
            }
            set
            {
                SetProperty(ref articles, value);
            }
        }

        private Article selectedArticle;
        public Article SelectedArticle
        {
            get
            {
                return selectedArticle;
            }
            set
            {
                SetProperty(ref selectedArticle, value);
            }
        }

        public ICommand LoadedCommand { get; set; }
        public ICommand ItemSelectedCommand { get; set; }

        private async Task LoadListAsync()
        {
            var httpClient = new HttpClient();
            var articleService = new ArticleService(httpClient);
            Articles = await articleService.GetAll();
        }
    }
}
