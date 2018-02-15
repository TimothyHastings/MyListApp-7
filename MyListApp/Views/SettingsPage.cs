using System;

using Xamarin.Forms;

namespace MyListApp
{
    public class SettingsPage : ContentPage
    {
        void GetData()
        {
            if (Model.Users.Count > 0){
                firstNameEntry.Text = Model.Users[0].FirstName;
                surnameEntry.Text = Model.Users[0].Surname;
                userNameEntry.Text = Model.Users[0].UserName;
                passwordEntry.Text = Model.Users[0].Password;
                serverURLEntry.Text = Model.Users[0].ServerURL;
            }
            else{
                firstNameEntry.Text = "";
                surnameEntry.Text = "";
                userNameEntry.Text = "";
                passwordEntry.Text = "";
                serverURLEntry.Text = "";
            }
        }

        Label descriptionLabel = new Label()
        {
            Text = "Please enter your credentials.",
        };

        Entry firstNameEntry = new Entry()
        {
            Placeholder="First Name",
            WidthRequest = 250,
            HorizontalOptions = LayoutOptions.Center
        };

        Entry surnameEntry = new Entry()
        {
            Placeholder = "Surname",
            WidthRequest = 250,
            HorizontalOptions = LayoutOptions.Center
        };

        Entry userNameEntry = new Entry()
        {
            Placeholder="User name",
            WidthRequest = 250,
            HorizontalOptions = LayoutOptions.Center
        };

        Entry passwordEntry = new Entry()
        {
            Placeholder = "User name",
            WidthRequest = 250,
            IsPassword = true,
            HorizontalOptions = LayoutOptions.Center
        };

        Entry serverURLEntry = new Entry()
        {
            Placeholder = "Server URL",
            WidthRequest = 250,
            Keyboard = Keyboard.Url,
            HorizontalOptions = LayoutOptions.Center
        };

        Button saveButton = new Button()
        {
            Text = "Save",
            WidthRequest = 100,
            TextColor = Color.White,
            FontAttributes = FontAttributes.Bold,
            BackgroundColor = Color.Green,
            HorizontalOptions = LayoutOptions.Center
        };


        public SettingsPage()
        {
            Title = "Settings";
            Content = new StackLayout
            {
                Spacing = 20,
                Children ={
                    descriptionLabel,
                    firstNameEntry,
                    surnameEntry,
                    userNameEntry,
                    serverURLEntry,
                    saveButton
                }
            };

            saveButton.Clicked += OnSaveButtonClicked;

            GetData();
        }

        void OnSaveButtonClicked(object sender, EventArgs args)
        {
            // TODO Validate
            User user = new User();
            user.FirstName = firstNameEntry.Text;
            user.Surname = surnameEntry.Text;
            user.UserName = userNameEntry.Text;
            user.Password = passwordEntry.Text;
            user.ServerURL = serverURLEntry.Text;
            Model.Users.Clear();
            Model.Users.Add(user);
            Database.SaveModel();
        }
    }
}

