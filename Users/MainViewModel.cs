using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Users
{
    public class MainViewModel : PropertyChangedBase
    {
        ApplicationContext db; // Контекст для работы с базой
        IEnumerable<Zakazi> zakazi;
        IEnumerable<Zakazi> selectedZakazi;
        private Zakazi selectedZakaz;
        private RelayCommand deleteCommand;
        private RelayCommand saveCommand;
        private RelayCommand addCommand;

        // Вывод количества клиентов
        private string clientCount;
        public string ClientCount
        {
            get { return clientCount; }
            set
            {
                clientCount = value;
                OnPropertyChanged();
            }
        }
        
        // Команда для добавления нового клиента
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        NewUserWindow nuw = new NewUserWindow(new Zakazi());
                        if (nuw.ShowDialog() == true)
                        {
                            Zakazi zakaz = nuw.Zakaz; // Получение имени нового клиента с другого окна
                            db.Zakaz.Add(zakaz); // Добавление
                            db.SaveChanges(); // Сохранение
                            Count();
                        }
                    }));
            }
        }

        private void Count()
        {
            ClientCount = "Количество клиентов: " + Zakazi.Count().ToString(); // Вывод количества существующих клиентов
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new RelayCommand(obj =>
                    {
                        db.SaveChanges();
                        MessageBox.Show("Данные сохранены", "Сохранение");

                    }));
            }
        }
        // Команда для удаления клиента
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                        {

                            if (SelectedZakaz != null)
                            {
                                var result = MessageBox.Show("Вы уверены?", "Подтвердить", MessageBoxButton.OKCancel);
                                if (result == MessageBoxResult.OK)
                                {
                                    var delete = obj as Zakazi; // Определение выделенного объекта
                                    db.Zakaz.Remove(delete); // Удаление
                                    db.SaveChanges(); // Сохранение
                                    Count();
                                    MessageBox.Show("Клиент удалён");
                                }
                            }
                        }));
            }
        }
        // Список клиентов в listbox'e
        public IEnumerable<Zakazi> Zakazi
        {
            get { return zakazi; }
            set
            {
                zakazi = value;
                OnPropertyChanged("Zakazi");
            }
        }

        // Информация о клиенте в Дата Гриде
        public IEnumerable<Zakazi> SelectedZakazi
        {
            get { return selectedZakazi; }
            {
                selectedZakazi = value;
                OnPropertyChanged("SelectedZakazi");
            }
        }
        
        // Фильтрация по выбранному клиенту
        public Zakazi SelectedZakaz
        {
            get { return selectedZakaz; }
            set
            { 
                selectedZakaz = value;
                OnPropertyChanged();
                if (SelectedZakaz != null) // Проверка на ноль чтобы не было ошибки при удалении клиента
                    SelectedZakazi = db.Zakaz.Where(c => c.Id == SelectedZakaz.Id).ToList(); // Выводит информацию по выделенному пользователю в datagrid. Фильтрует по ID
            }
        }

        // Конструктор Вью Модели
        public MainViewModel()
        {
            db = new ApplicationContext(); // Инициализация контекста для работы с базой
            db.Zakaz.Load();
            Zakazi = db.Zakaz.Local.ToBindingList();
            Count();
        }
    }
}
