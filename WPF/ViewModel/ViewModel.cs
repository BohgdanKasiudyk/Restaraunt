
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using BLL.Abstraction;
using DTO;

namespace WPF.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
         private readonly IDishService dishService;
         private readonly IMenuService menuService;
        private readonly IOrderService orderService;
        private DishDTO selectDish;
        private DishDTO selectedDishInOrder;
        private MenuDTO selectedMenu;
        
        public ObservableCollection<DishDTO> Dishes { get; set; }
        public ObservableCollection<DishDTO> DishesInOrder { get; set; }
        
        public ObservableCollection<MenuDTO> Menus { get; set; }
        public ICommand DoOrderCommand { get; private set; }
        public ICommand AddToOrderCommand { get; private set; }
        public ICommand DelFromOrderCommand { get; private set; }
        public ICommand CleanOrderCommand { get; private set; }
        
        public ICommand SelectMenuCommand { get; private set; }
        

        public DishDTO SelectDish
        {
            get { return selectDish; }
            set
            {
                selectDish = value;
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
                OnPropertyChanged("SelectedMenu");
            }
        }

        public ViewModel(IDishService dishService, IOrderService orderService, IMenuService menuService)
        {
            this.menuService = menuService;
            this.dishService = dishService;
            this.orderService = orderService;
            Menus = new ObservableCollection<MenuDTO>(this.menuService.GetALLMenus());
            //Dishes = new ObservableCollection<DishDTO>();
            DishesInOrder = new ObservableCollection<DishDTO>();

            DoOrderCommand = new RelayCommand.RelayCommand(obj => DoOrder());
            AddToOrderCommand = new RelayCommand.RelayCommand(obj => AddToOrder());
            DelFromOrderCommand = new RelayCommand.RelayCommand(obj => DelFromOrder());
            CleanOrderCommand = new RelayCommand.RelayCommand(obj => CleanOrder());
        }

        private void SelectMenu()
        {
            Dishes = new ObservableCollection<DishDTO>(menuService.GetAllDishesFromMenu(SelectedMenu.Id));
        }

        private void DoOrder()
        {
            OrderDTO orderDTO = orderService.CreateOrder(DishesInOrder);
            DishesInOrder.Clear();
            selectedDishInOrder = null;
            
            MessageBox.Show(GenerateMessage(orderDTO));
        }

        private string GenerateMessage(OrderDTO orderDTO)
        {
            String message = "Start order : " + orderDTO.BeginOfOrder + "\n";
            message += "Name : Price : Preparing time \n";
            foreach(DishOrderDTO dishOrderDTO in orderDTO.DishOrderDTOs)
            {
                message += dishOrderDTO.DishDTO.Name + " : " + dishOrderDTO.DishDTO.Price + " : " + "\n";
            }
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

        private void CleanOrder()
        {
            DishesInOrder.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
         
    }
}