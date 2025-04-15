using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawfectCareLimited
{
    public partial class RegisterInterfaceForm : Form
    {
        public RegisterInterfaceForm()
        {
            InitializeComponent();
            petDetailsLabel.Visible = false;
            petNameLabel.Visible = false;
            petTypeLabel.Visible = false;
            petBreedLabel.Visible = false;
            petAgeLabel.Visible = false;
            petIdLabel.Visible = false;
            registerButton.Visible = false;


            petNameValue.Visible = false;
            petBreedValue.Visible = false;
            petAgeValue.Visible = false;
            petIdValue.Visible = false;
            petTypeValue.Visible = false;

        }

        private async void registerButton_Click(object sender, EventArgs e)
        {
            nextButton.Visible = true;

            using (HttpClient client = new HttpClient())
            {

                // Retrieve pet data from UI controls.
                string petName = petNameValue.Text;
                string petType = petTypeValue.Text;
                string petBreed = petBreedValue.Text;
                string petAge = petAgeValue.Text;
                string petId = petIdValue.Text;
                string ownerId = ownerIdValue.Text;

                

                // Construct the pet data as a Dictionary
                var petData = new Dictionary<string, object>
                {
                    { "PetID", petId },
                    { "OwnerID", ownerId },
                    { "PetName", petName },
                    { "PetType", petType },
                    { "Breed", petBreed },
                    { "Age", petAge }
                };

                try
                {
                    // Insert the pet and owner data.
                    string petApiUrl = "https://localhost:7038/api/pet";

                    // Convert to JSON
                    var petJson = System.Text.Json.JsonSerializer.Serialize(petData);
                    var petContent = new StringContent(petJson, Encoding.UTF8, "application/json");

                    // Post pet only if owner insert succeeded
                    HttpResponseMessage petResponse = await client.PostAsync(petApiUrl, petContent);


                    // Check if owner insert was successful
                    if (petResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pet details added successfully.");                       
                    }
                    else
                    {
                        string petError = await petResponse.Content.ReadAsStringAsync();
                        MessageBox.Show($"Pet Error: {petError}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private async void nextButton_Click(object sender, EventArgs e)
        {
            petDetailsLabel.Visible = true;
            petNameLabel.Visible = true;
            petTypeLabel.Visible = true;
            petBreedLabel.Visible = true;
            petAgeLabel.Visible = true;
            petIdLabel.Visible = true;
            registerButton.Visible = true;
            nextButton.Visible = false;

            petNameValue.Visible = true;
            petBreedValue.Visible = true;
            petAgeValue.Visible = true;
            petIdValue.Visible = true;
            petTypeValue.Visible = true;

            using (HttpClient client = new HttpClient())
            {
                // Retrieve owner data from UI controls.
                string firstName = firstNameValue.Text;
                string lastName = lastNameValue.Text;
                string phoneNumber = phoneNumberValue.Text;
                string email = emailValue.Text;
                string address = addressValue.Text;
                string ownerId = ownerIdValue.Text;

                
                // Construct the owner data as a Dictionary
                var ownerData = new Dictionary<string, object>
                {
                    { "OwnerID", ownerId },
                    { "FirstName", firstName },
                    { "LastName", lastName },
                    { "PhoneNo", phoneNumber },
                    { "Email", email },
                    { "Address", address }
                };

                // Insert Owner.
                try
                {
                    // Insert the pet and owner data.
                    string ownerApiUrl = "https://localhost:7038/api/owner";

                    
                    var ownerJson = System.Text.Json.JsonSerializer.Serialize(ownerData);
                    var ownerContent = new StringContent(ownerJson, Encoding.UTF8, "application/json");

                    // Send POST request
                    HttpResponseMessage ownerResponse = await client.PostAsync(ownerApiUrl, ownerContent);

                    // Check if owner insert was successful
                    if (ownerResponse.IsSuccessStatusCode)
                    {          
                        MessageBox.Show("Owner details added successfully.");
                    }
                    else
                    {
                        string ownerError = await ownerResponse.Content.ReadAsStringAsync();
                        MessageBox.Show($"Owner Error: {ownerError}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

        }
    }
}
