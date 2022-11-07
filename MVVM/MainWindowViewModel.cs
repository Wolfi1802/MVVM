using MVVM.Commands;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace MVVM
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            //Fill with test datas
            this.AnimeItemsSource = new ObservableCollection<Anime>();
            this.AnimeItemsSource.Add(new Anime("Swort Art Online", "Here could your text be", 4));
            this.AnimeItemsSource.Add(new Anime("Fate", "Here could your text be", 8));
            this.AnimeItemsSource.Add(new Anime("Seraph of the end", "Here could your text be", 1));
            this.AnimeItemsSource.Add(new Anime("Rising of Shield Hero", "Here could your text be", 3));

            this.SaveButtonIsEnabled = false;
        }

        public Anime SelectedItem
        {
            get => base.GetProperty<Anime>(nameof(SelectedItem));
            set
            {
                base.SetProperty(nameof(SelectedItem), value);

                if (value != null)
                    this.SaveButtonIsEnabled = true;
                else
                    this.SaveButtonIsEnabled = false;
            }
        }

        public ObservableCollection<Anime> AnimeItemsSource
        {
            get => base.GetProperty<ObservableCollection<Anime>>(nameof(AnimeItemsSource));
            set => base.SetProperty(nameof(AnimeItemsSource), value);
        }

        public bool SaveButtonIsEnabled
        {
            get => base.GetProperty<bool>(nameof(SaveButtonIsEnabled));
            set => base.SetProperty(nameof(SaveButtonIsEnabled), value);
        }

        public ICommand Delete => new RelayCommand(param =>
        {
            try
            {
                if (param is Anime anime)
                {
                    this.AnimeItemsSource.Remove(anime);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MainWindowViewModel)},{nameof(Delete)},\nEX :[{ex}]");
            }
        });

        public ICommand SaveSelectedItem => new RelayCommand(param =>
        {
            try
            {
                if (param is Anime anime)
                {
                    FileHelper.Save(anime);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{nameof(MainWindowViewModel)},{nameof(SaveSelectedItem)},\nEX :[{ex}]");
            }
        });

    }
}
