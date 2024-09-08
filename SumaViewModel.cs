using System.ComponentModel;
using System.Windows.Input;

public class SumaViewModel : INotifyPropertyChanged
{
    private double _numero1;
    private double _numero2;
    private string _resultado;

    public double Numero1
    {
        get { return _numero1; }
        set
        {
            _numero1 = value;
            OnPropertyChanged(nameof(Numero1));
        }
    }

    public double Numero2
    {
        get { return _numero2; }
        set
        {
            _numero2 = value;
            OnPropertyChanged(nameof(Numero2));
        }
    }

    public string Resultado
    {
        get { return _resultado; }
        set
        {
            _resultado = value;
            OnPropertyChanged(nameof(Resultado));
        }
    }

    public ICommand SumarCommand { get; }
    public ICommand LimpiarCommand { get; }

    public SumaViewModel()
    {
        SumarCommand = new Command(OnSumar);
        LimpiarCommand = new Command(OnLimpiar);
    }

    private void OnSumar()
    {
        if (Numero1 == 0 || Numero2 == 0)
        {
            Resultado = "Por favor, ingresa ambos numeros";
        }
        else
        {
            double suma = Numero1 + Numero2;
            Resultado = $"El resultado es: {suma}";
        }
    }

    private void OnLimpiar()
    {
        Numero1 = 0;
        Numero2 = 0;
        Resultado = string.Empty;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
