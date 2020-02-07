using Prism.Commands;
using System.Windows.Input;
using WpfApp1.DataAccessLayer;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public class DemoSelectorWindowViewModel
    {
        public ICommand OpenBindingsViewCommand { get; set; }
        public ICommand OpenTabViewCommand { get; set; }
        public ICommand OpenArticleListViewCommand { get; set; }

        public DemoSelectorWindowViewModel(ArticleService articleService, CategoryService categoryService)
        {
            OpenBindingsViewCommand = new DelegateCommand(() =>
            {
                var bindingsWindow = new BindingsWindow { DataContext = new BindingsWindowViewModel() };
                bindingsWindow.Show();
            });

            OpenTabViewCommand = new DelegateCommand(() =>
            {
                var tabWindow = new TabWindow();
                tabWindow.Show();
            });

            OpenArticleListViewCommand = new DelegateCommand(() =>
            {
                var articleListWindow = new ArticleListWindow { DataContext = new ArticleListWindowViewModel(articleService, categoryService) };
                articleListWindow.Show();
            });
        }
    }
}
