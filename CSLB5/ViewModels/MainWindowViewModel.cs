using System.Collections.Generic;
using System.Windows.Input;
using MVVM;
using MVVM.Commands;

namespace CSLB5.ViewModels;

public class MainWindowViewModel : BindableBase
{
    public MainWindowViewModel()
    {
        Models = new();
        Models.Add(new ReservationObserverByLectureViewModel());
        Models.Add(new ReservationObserverByTutorViewModel());
        
        //SelectModel = Models[0];
        OpenObserverByLecture = new RelayCommand(OnOpenObserverByLecture);
        OpenObserverByTutor = new RelayCommand(OnOpenObserverByTutor);
    }
    
    public List<BindableBase> Models { get; private set; }

    private BindableBase _selectModel;
    public BindableBase SelectModel
    {
        get => _selectModel;
        set => SetProperty(ref _selectModel, value);
    }

    public ICommand OpenObserverByLecture { get;  }

    private void OnOpenObserverByLecture()
    {
        SelectModel = Models[0];
    }
    
    public ICommand OpenObserverByTutor { get;  }

    private void OnOpenObserverByTutor()
    {
        SelectModel = Models[1];
    }
}