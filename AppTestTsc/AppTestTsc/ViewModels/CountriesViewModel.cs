using Acr.UserDialogs;
using AppTestTsc.Complements;
using AppTestTsc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using AppTestTsc.Views;

namespace AppTestTsc.ViewModels
{
    public class CountriesViewModel : BaseViewModel
    {
        #region Fields


        private Command editCommand;

        private Command deleteCommand;

        private Command addCountrieCommand;

        private Command saveCountrieCommand;

        private Command viewCommand;
        
        public bool showPopUp;

        public string titlePopUp;

        public ObservableCollection<Countries> countriesDetailAux;

        public Countries currentCountrie;

        #endregion

        #region Constructor

        public CountriesViewModel()
        {          
           ShowPopUp = false;
           GetCountries();


        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of countries page view model.
        /// </summary>

        public static List<Countries> CountriesDetails { get; set; }

        public bool IsNewCountrie { get; set; }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command is executed when the edit button is clicked.
        /// </summary>
        public Command EditCommand
        {
            get
            {
                return this.editCommand ?? (this.editCommand = new Command(this.EditButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the delete button is clicked.
        /// </summary>
        public Command DeleteCommand
        {
            get
            {
                return this.deleteCommand ?? (this.deleteCommand = new Command(this.DeleteButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the add card button is clicked.
        /// </summary>
        public Command AddCountrieCommand
        {
            get
            {
                return this.addCountrieCommand ?? (this.addCountrieCommand = new Command(this.AddCountrieButtonClicked));
            }
        }


        /// <summary>
        /// Gets the command is executed when the button save is clicked
        /// </summary>
        public Command SaveCountrieCommand
        {
            get
            {
                return this.saveCountrieCommand ?? (this.saveCountrieCommand = new Command(this.SaveButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the button view is clicked
        /// </summary>
        public Command ViewCommand
        {
            get
            {
                return this.viewCommand ?? (this.viewCommand = new Command(this.ViewButtonClicked));
            }
        }




        /// <summary>
        /// Gets the cproperty to open the popup if is edit or modify
        /// </summary>
        public bool ShowPopUp
        {
            get
            {
                return this.showPopUp;
            }

            set
            {
                if (this.showPopUp == value)
                {
                    return;
                }

                this.SetProperty(ref this.showPopUp, value);

            }

        }


        /// <summary>
        /// Gets or set property to change header PopUp
        /// </summary>
        public string TitlePopUp
        {
            get
            {
                return this.titlePopUp;
            }

            set
            {
                if (this.titlePopUp == value)
                {
                    return;
                }

                this.SetProperty(ref this.titlePopUp, value);

            }

        }

        /// <summary>
        /// Gets or set property to change Current Countrie
        /// </summary>
        public Countries CurrentCountrie
        {
            get
            {
                return this.currentCountrie;
            }

            set
            {
                if (this.currentCountrie == value)
                {
                    return;
                }

                this.SetProperty(ref this.currentCountrie, value);

            }

        }

        /// <summary>
        /// Gets the cproperty to open the popup if is edit or modify
        /// </summary>
        public ObservableCollection<Countries> CountriesDetailAux
        {
            get
            {
                return this.countriesDetailAux;
            }

            set
            {
                if (this.countriesDetailAux != value)

                {
                    countriesDetailAux = value;

                    OnPropertyChanged();
                }

            }

        }


        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>


        /// <summary>
        /// Invoked when the edit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void EditButtonClicked(object obj)
        {
            try
            {

                ShowPopUp = true;
                TitlePopUp = "Editar País";
                Label lbl = obj as Label;
                int id = int.Parse(lbl.Text);
                IsNewCountrie = false;

                var existCountrie = CountriesDetailAux.FirstOrDefault(x => x.Id == id);
                if(existCountrie!=null)
                {

                    CurrentCountrie = existCountrie;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Invoked when the delete button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        async void DeleteButtonClicked(object obj)
        {
            try
            {
                if (await App.Current.MainPage.DisplayAlert("Alerta", "Está seguro que desea eliminar el país seleccionado", "Si", "No"))
                {
                    Label lbl = obj as Label;
                    int id = int.Parse(lbl.Text);

                    DeleteCountrie((int)id);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Invoked when the add card button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void AddCountrieButtonClicked(object obj)
        {
       
                try
                {

                    ShowPopUp = true;
                    TitlePopUp = "Crear País";
                    IsNewCountrie = true;
                    CurrentCountrie = new Countries();

                }
                catch (Exception)
                {

                    throw;
                }

        }

        /// <summary>
        /// Invoked when the add card button clicked
        /// </summary>
        /// <param name="obj">The object</param>
       async void SaveButtonClicked(object obj)
        {

            try
            {
                if (IsNewCountrie)
                {
                    if (await App.Current.MainPage.DisplayAlert("Alerta", "Está seguro que desea guardar un nuevo país", "Si", "No"))
                    {

                        NewCountrie();

                    }

                }
                else
                {
                    if (await App.Current.MainPage.DisplayAlert("Alerta", "Está seguro que desea actualizar el país", "Si", "No"))
                    {

                        UpdateCountrie();


                    }

                }
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(ex.Message, "Alerta", "Aceptar");
            }
          

        }

        async void ViewButtonClicked(object obj)
        {

            try
            {
                Label lbl = obj as Label;
                int id = int.Parse(lbl.Text);

               await  App.Current.MainPage.Navigation.PushAsync(new SubdivisionPage(id));

            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(ex.Message, "Alerta", "Aceptar");
            }


        }

        /// <summary>
        /// Invoked method get countries
        /// </summary>
        /// <param name="obj">The object</param>
        async void GetCountries()
        {
            try
            {
                CountriesDetails = new List<Countries>();
                this.CountriesDetailAux = new ObservableCollection<Countries>();

                var resultCountries = await DataStoreCountries.GetCountriesAsync();

                if (resultCountries.Message == "OK")
                {

                    var result = resultCountries.Data as List<Countries>;               
                    result.ForEach(x => CountriesDetailAux.Add(x));
                }

               // SetListCountries();

                
            }
            catch (Exception ex)
            {

                await UserDialogs.Instance.AlertAsync(ex.Message, "Alerta", "Aceptar");
            }
        }

        /// <summary>
        /// Invoked method update countries
        /// </summary>
        /// <param name="obj">The object</param>
        async void UpdateCountrie()
        {
            try
            {
                var resultCountries = await DataStoreCountries.UpdateCountrieAsync(CurrentCountrie);

                if(resultCountries.Message=="OK")
                {
                   await UserDialogs.Instance.AlertAsync("Datos almacenados con éxito", "Alerta", "Aceptar");
                   GetCountries();
                   ShowPopUp = false;
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync(resultCountries.Message, "Alerta", "Aceptar");
                }

            }
            catch (Exception ex)
            {

                await UserDialogs.Instance.AlertAsync(ex.Message, "Alerta", "Aceptar");
            }

        }

        /// <summary>
        /// Invoked method new countries
        /// </summary>
        /// <param name="obj">The object</param>
        async void NewCountrie()
        {
            try
            {
                var resultCountries = await DataStoreCountries.AddCountrieAsync(CurrentCountrie);

                if (resultCountries.Message == "OK")
                {
                    await UserDialogs.Instance.AlertAsync("Datos almacenados con éxito", "Alerta", "Aceptar");
                    GetCountries();
                    ShowPopUp = false;
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync(resultCountries.Message, "Alerta", "Aceptar");
                }

            }
            catch (Exception ex)
            {

                await UserDialogs.Instance.AlertAsync(ex.Message, "Alerta", "Aceptar");
            }

        }

        /// <summary>
        /// Invoked method delete countries
        /// </summary>
        /// <param name="obj">The object</param>
        async void DeleteCountrie(int id)
        {
            try
            {
                var resultCountries = await DataStoreCountries.DeleteItemAsync(id);

                if (resultCountries.Message == "OK")
                {
                    await UserDialogs.Instance.AlertAsync("Registro eliminado con éxito", "Alerta", "Aceptar");
                    GetCountries();
                    ShowPopUp = false;
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync(resultCountries.Message, "Alerta", "Aceptar");
                }

            }
            catch (Exception ex)
            {

                await UserDialogs.Instance.AlertAsync(ex.Message, "Alerta", "Aceptar");
            }

        }

        #endregion


    }
}