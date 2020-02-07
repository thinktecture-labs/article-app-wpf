using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.DataAccessLayer;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class ArticleDetailWindowViewModel : BindableBase
    {
        private readonly ArticleService articleService;
        private readonly CategoryService categoryService;

        public ArticleDetailWindowViewModel(ArticleService articleService, CategoryService categoryService)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;

            LoadedCommand = new DelegateCommand(async () =>
            {
                await LoadCategoriesAsync();
                await LoadDetailsAsync(OpenArticleId);
            });
            CategoryChangedCommand = new DelegateCommand(async () => await LoadSubCategoriesAsync());
            PreviousCommand = new DelegateCommand(async () => await LoadDetailsAsync(Article.PreviousId ?? 0));
            NextCommand = new DelegateCommand(async () => await LoadDetailsAsync(Article.NextId ?? 0));
        }

        private Article article;
        public Article Article
        {
            get
            {
                return article;
            }
            set
            {
                SetProperty(ref article, value);
            }
        }

        private IEnumerable<Category> categories;
        public IEnumerable<Category> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                SetProperty(ref categories, value);
            }
        }

        private IEnumerable<Category> subcategories;

        public IEnumerable<Category> Subcategories
        {
            get
            {
                return subcategories;
            }
            set
            {
                SetProperty(ref subcategories, value);
            }
        }

        public ICommand LoadedCommand { get; set; }
        public ICommand CategoryChangedCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public int OpenArticleId { get; internal set; }

        private async Task LoadDetailsAsync(int id)
        {
            Article = await articleService.Get(id);
        }

        private async Task LoadCategoriesAsync()
        {
            Categories = await categoryService.GetCategories();
        }

        private async Task LoadSubCategoriesAsync()
        {
            Subcategories = await categoryService.GetSubcategories(Article.Category);
        }
    }
}
