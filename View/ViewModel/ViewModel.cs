using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using BLL.Abstraction;
using DTO;

namespace View.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        
         private readonly IMenuService menuService;
        private readonly IOrderService orderService;
        private DishDTO selectedDish;
        private DishDTO selectedDishInOrder;
        private MenuDTO selectedMenu;

        private ObservableCollection<DishDTO> dishes;
        public ObservableCollection<DishDTO> DishesInOrder { get;  }
        
        public ObservableCollection<MenuDTO> Menus { get;  }
        public ICommand DoOrderCommand { get;  }
        public ICommand AddToOrderCommand { get;  }
        public ICommand DelFromOrderCommand { get;  }
        public ICommand CleanOrderCommand { get;  }
        
       
        
       
        

        public DishDTO SelectDish
        {
            get { return selectedDish; }
            set
            {
                selectedDish = value;
                OnPropertyChanged("SelectDish");
            }
        }

        public DishDTO SelectedDishInOrder
        {
            get { return selectedDishInOrder; }
            set
            {
                selectedDishInOrder = value;
                
                OnPropertyChanged("SelectedDishInOrder");
            }
        }

        public MenuDTO SelectedMenu
        {
            get { return selectedMenu; }
            set
            {
                selectedMenu = value;
                Dishes = new ObservableCollection<DishDTO>(menuService.GetAllDishesFromMenu(SelectedMenu.Id));
                OnPropertyChanged("SelectedMenu");
            }
        }

        public ObservableCollection<DishDTO> Dishes
        {
            get { return dishes; }
            set
            {
                dishes = value;
                OnPropertyChanged("Dishes");
            }
        }

        public ViewModel( IOrderService orderService, IMenuService menuService)
        {
            this.menuService = menuService;
            
            this.orderService = orderService;
            Menus = new ObservableCollection<MenuDTO>(this.menuService.GetALLMenus());
            Dishes = new ObservableCollection<DishDTO>();
            DishesInOrder = new ObservableCollection<DishDTO>();

            DoOrderCommand = new RelayCommand.RelayCommand(obj => CreateOrder(),o => CreateOrderCanExecute());
            AddToOrderCommand = new RelayCommand.RelayCommand(obj => AddToOrder(), obj => CanAddDish());
            DelFromOrderCommand = new RelayCommand.RelayCommand(obj => DelFromOrder(), obj => DeleteItemOrderCanExecute() );
            CleanOrderCommand = new RelayCommand.RelayCommand(obj => CleanItemsFromOrder(), obj => CleanItemsOrderCanExecute() );
            
            
        }

        private bool CanAddDish()
        {
            return (selectedDish != null);
        }
        private bool CleanItemsOrderCanExecute()
        {
            return (DishesInOrder.Count != 0);
        }
        

        private bool DeleteItemOrderCanExecute()
        {
            return (SelectedDishInOrder != null);
        }
        

        private bool CreateOrderCanExecute()
        {
            return (DishesInOrder.Count != 0);
        }

       
        private void CreateOrder()
        {   
            
            
            OrderDTO order = orderService.CreateOrder(DishesInOrder);
            DishesInOrder.Clear();
            selectedDishInOrder = null;
            MessageBox.Show(Message(order));



        }

        private string Message(OrderDTO orderDTO)
        {
            String message = "Start time : " + orderDTO.BeginOfOrder + "\n" + "Time to cook:  " + orderDTO.CookingTime;
           
            return message;
        }

        private void AddToOrder()
        {
            DishesInOrder.Add(SelectDish);
        }

        private void DelFromOrder()
        {
            DishesInOrder.Remove(SelectedDishInOrder);
        }

        private void CleanItemsFromOrder()
        {
            DishesInOrder.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

            
        }
         
    }
}