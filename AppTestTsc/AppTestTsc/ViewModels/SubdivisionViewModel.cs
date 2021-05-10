using Acr.UserDialogs;
using AppTestTsc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace AppTestTsc.ViewModels
{
    public class SubdivisionViewModel : BaseViewModel
    {

        #region Fields

        private Command editCommand;

        private Command deleteCommand;

        private Command addSubdivisionCommand;

        private Command saveSubdivisionCommand;

        public bool showPopUp;

        public ObservableCollection<Subdivisions> subdivisionDetail;

        public Subdivisions currentSubdivision;

        public string titlePopUp;

        #endregion Fields

        #region Constructor
        public SubdivisionViewModel(int id)
        {
            ShowPopUp = false;
            IdCountrie = id;
            GetSubdivisions(id);


        }
        #endregion Constructor


        #region Properties

        public bool IsNewSubdivision { get; set; }

        public int IdCountrie { get; set; }
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
        /// Gets the cproperty to open the popup if is edit or modify
        /// </summary>
        public ObservableCollection<Subdivisions> SubdivisionDetail
        {
            get
            {
                return this.subdivisionDetail;
            }

            set
            {
                if (this.subdivisionDetail != value)

                {
                    subdivisionDetail = value;

                    OnPropertyChanged();
                }

            }

        }

        /// <summary>
        /// Gets or set property to change Current Countrie
        /// </summary>
        public Subdivisions CurrentSubdivision
        {
            get
            {
                return this.currentSubdivision;
            }

            set
            {
                if (this.currentSubdivision == value)
                {
                    return;
                }

                this.SetProperty(ref this.currentSubdivision, value);

            }

        }
        #endregion properties

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
        public Command AddSubdivisionCommand
        {
            get
            {
                return this.addSubdivisionCommand ?? (this.addSubdivisionCommand = new Command(this.AddCountrieButtonClicked));
            }
        }


        /// <summary>
        /// Gets the command is executed when the button save is clicked
        /// </summary>
        public Command SaveSubdivisionCommand
        {
            get
            {
                return this.saveSubdivisionCommand ?? (this.saveSubdivisionCommand = new Command(this.SaveButtonClicked));
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



        #endregion

        #region Methods
        /// <summary>
        /// Invoked method get countries
        /// </summary>
        /// <param name="obj">The object</param>
        async void GetSubdivisions(int id)
        {
            try
            {
                SubdivisionDetail = new ObservableCollection<Subdivisions>();
                
                var resultCountries = await DataStoreSubdivisions.GetSubdivisiosAsync(id);

                if (resultCountries.Message == "OK")
                {

                    var result = resultCountries.Data as List<Subdivisions>;
                    result.ForEach(x => SubdivisionDetail.Add(x));
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
        async void UpdateSubdivisions()
        {
            try
            {
                var resultCountries = await DataStoreSubdivisions.UpdateSubdivisioAsync(CurrentSubdivision, IdCountrie);

                if (resultCountries.Message == "OK")
                {
                    await UserDialogs.Instance.AlertAsync("Datos almacenados con éxito", "Alerta", "Aceptar");
                    GetSubdivisions(IdCountrie);
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
        async void NewSubdivisions()
        {
            try
            {
                var resultCountries = await DataStoreSubdivisions.AddSubdivisioAsync(CurrentSubdivision, IdCountrie);

                if (resultCountries.Message == "OK")
                {
                    await UserDialogs.Instance.AlertAsync("Datos almacenados con éxito", "Alerta", "Aceptar");
                    GetSubdivisions(IdCountrie);
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
        async void DeleteSubdivisions(int id, int idCountrie)
        {
            try
            {
                var resultCountries = await DataStoreSubdivisions.DeleteSubdivisiomAsync(id,idCountrie);

                if (resultCountries.Message == "OK")
                {
                    await UserDialogs.Instance.AlertAsync("Registro eliminado con éxito", "Alerta", "Aceptar");
                    GetSubdivisions(IdCountrie);
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
        /// Invoked when the edit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void EditButtonClicked(object obj)
        {
            try
            {

                ShowPopUp = true;
                TitlePopUp = "Editar Subdivision";
                Label lbl = obj as Label;
                int id = int.Parse(lbl.Text);
                IsNewSubdivision = false;

                var existCountrie = SubdivisionDetail.FirstOrDefault(x => x.Id == id);
                if (existCountrie != null)
                {

                    CurrentSubdivision = existCountrie;
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
                if (await App.Current.MainPage.DisplayAlert("Alerta", "Está seguro que desea eliminar la subdivision seleccionada", "Si", "No"))
                {
                    Label lbl = obj as Label;
                    int id = int.Parse(lbl.Text);

                    DeleteSubdivisions((int)id,IdCountrie);

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
                TitlePopUp = "Crear Subdivision";
                IsNewSubdivision = true;
                CurrentSubdivision = new Subdivisions();

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
                if (IsNewSubdivision)
                {
                    if (await App.Current.MainPage.DisplayAlert("Alerta", "Está seguro que desea guardar una nueva subdivision", "Si", "No"))
                    {

                        NewSubdivisions();

                    }

                }
                else
                {
                    if (await App.Current.MainPage.DisplayAlert("Alerta", "Está seguro que desea actualizar la subdivision", "Si", "No"))
                    {

                        UpdateSubdivisions();


                    }

                }
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(ex.Message, "Alerta", "Aceptar");
            }


        }


        #endregion Methods


    }

}
