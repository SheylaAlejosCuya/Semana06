using Semana06.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Bussines;

namespace Semana06.ViewModel
{
    public class ManCategoriaViewModel : ViewModelBase
    {
        #region propiedades
        int _ID;
        public int ID
        {
            get { return _ID;  }
            set
            {
                if( _ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }
        string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if(_Nombre != value)
                {
                    _Nombre = value;
                    OnPropertyChanged();
                }
            }
        }
        string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                if(_Descripcion != value)
                {
                    _Descripcion = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        public ICommand GrabarCommand { set; get; }
        public ICommand CerrarCommand { set; get; }

        public ManCategoriaViewModel()
        {
            GrabarCommand = new RelayCommand<Object>(
                o =>
                {
                    if (ID > 0)
                        new CategoriaModel().Actualizar(new Entity.Categoria
                        {
                            IdCategoria = ID,
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion
                        });
                    else
                        new CategoriaModel().Insertar(new Entity.Categoria
                        {
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion
                        });
                });
            CerrarCommand = new RelayCommand<Window>(
                param => Cerrar(param)
                );
        }
        void Cerrar(Window window)
        {
            window.Close();
        }
    }
}
