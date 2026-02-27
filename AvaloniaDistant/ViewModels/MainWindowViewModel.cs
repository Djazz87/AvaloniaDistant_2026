using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaDistant.Models;
using AvaloniaDistant.Services;
using AvaloniaDistant.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace YourProjectName.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<IllnessRecordDTO> _illnessRecordsDTOList = new();

    public MainWindowViewModel()
    {
        
        
        
        IllnessRecordsDTOList = new ObservableCollection<IllnessRecordDTO>(
            DataBaseServices.GetIllnessRecords()
      
        );
        
    }
    private Employee _selectedEmployee;

    public Employee SelectedEmployee
    {
        get => _selectedEmployee;
        set
        {
            if (Equals(value, _selectedEmployee) ) return;
            _selectedEmployee = value;
            OnPropertyChanged();
        }
    }
    
    [ObservableProperty]
    private ObservableCollection<IllnessRecordDTO> _products =new();

    
    
    
}
