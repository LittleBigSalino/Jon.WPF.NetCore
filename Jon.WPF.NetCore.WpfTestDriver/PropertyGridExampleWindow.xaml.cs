using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Jon.WPF.NetCore.WpfTestDriver
{
    /// <summary>
    /// Interaction logic for PropertyGridExampleWindow.xaml
    /// </summary>
    public partial class PropertyGridExampleWindow : Window
    {
        public PropertyGridExampleWindow()
        {
            InitializeComponent();

            string theValue = @" public class Person
    {
        [DisplayName(""First Name"")]
        [Description(""The person's first name."")]
        [Category(""Personal Information"")]
        public string First { get; set; }

        [DisplayName(""Middle Name"")]
        [Description(""The person's middle name (if applicable)."")]
        [Category(""Personal Information"")]
        public string Middle { get; set; }

        [DisplayName(""Last Name"")]
        [Description(""The person's last name."")]
        [Category(""Personal Information"")]
        public string Last { get; set; }

        [DisplayName(""Date of Birth"")]
        [Description(""The person's date of birth."")]
        [Category(""Personal Information"")]
        public DateTime DOB { get; set; }

        [DisplayName(""Address"")]
        [Description(""The person's physical address."")]
        [Category(""Address Info"")]
        public Address Address { get; set; }

        [DisplayName(""Street Address 1"")]
        [Description(""The person's physical address."")]
        public string Street => Address.Street;

        [DisplayName(""Street Address 1"")]
        [Description(""The person's physical address."")]
        public string Stree2 => Address.Street2;

        [DisplayName(""City"")]
        [Description(""The person's City."")]
        public string City => Address.City;

        [DisplayName(""State"")]
        [Description(""The person's State."")]
        public string State=> Address.State;

        [DisplayName(""PostalCode"")]
        [Description(""The person's Postal Code."")]
        public string PostalCode => Address.Postal;

        [DisplayName(""Contact Information"")]
        [Description(""A list of the person's contact information."")]
        [Category(""Contact Information"")]
        public List<ContactInfo> ContactInfoList { get; set; }
    }";

            Address address = new()
            {
                Street = "123 Main St",
                Street2 = "Apt 2",
                City = "Tucson",
                State = "AZ",
                Postal = "12345"
            };
            Person person = new()
            {
                First = "Jon",
                Last = "Sales",
                Middle = "M",
                DOB = new DateTime(1978, 5, 7),
                Address = address
            };
            PropertyGridMain.SelectedObject = person;
            TextBoxCodeBox.Text = theValue;
        }
    }

    public class Person
    {
        [DisplayName("First Name")]
        [Description("The person's first name.")]
        [Category("Personal Information")]
        public string? First { get; set; }

        [DisplayName("Middle Name")]
        [Description("The person's middle name (if applicable).")]
        [Category("Personal Information")]
        public string? Middle { get; set; }

        [DisplayName("Last Name")]
        [Description("The person's last name.")]
        [Category("Personal Information")]
        public string? Last { get; set; }

        [DisplayName("Date of Birth")]
        [Description("The person's date of birth.")]
        [Category("Personal Information")]
        public DateTime DOB { get; set; }

        [DisplayName("Address")]
        [Description("The person's physical address.")]
        [Category("Address Info")]
        public Address? Address { get; set; }

        [DisplayName("Street Address 1")]
        [Description("The person's physical address.")]
        public string Street => Address.Street;

        [DisplayName("Street Address 1")]
        [Description("The person's physical address.")]
        public string Stree2 => Address.Street2;

        [DisplayName("City")]
        [Description("The person's City.")]
        public string City => Address.City;

        [DisplayName("State")]
        [Description("The person's State.")]
        public string State => Address.State;

        [DisplayName("PostalCode")]
        [Description("The person's Postal Code.")]
        public string PostalCode => Address.Postal;

        [DisplayName("Contact Information")]
        [Description("A list of the person's contact information.")]
        [Category("Contact Information")]
        public List<ContactInfo>? ContactInfoList { get; set; }
    }

    public class Address
    {
        [DisplayName("Street Address")]
        [Description("The first line of the street address.")]
        [Category("Address")]
        public string? Street { get; set; }

        [DisplayName("Street Address 2")]
        [Description("The second line of the street address (if applicable).")]
        [Category("Address")]
        public string? Street2 { get; set; }

        [DisplayName("City")]
        [Description("The name of the city.")]
        [Category("Address")]
        public string? City { get; set; }

        [DisplayName("State")]
        [Description("The name of the state or province.")]
        [Category("Address")]
        public string? State { get; set; }

        [DisplayName("Postal Code")]
        [Description("The postal code or ZIP code.")]
        [Category("Address")]
        public string? Postal { get; set; }

        public override string ToString()
        {
            return $"{Street} {Street2} {City}, {State} {Postal}";
        }
    }

    public class ContactInfo
    {
        [DisplayName("Contact Type")]
        [Description("The type of contact information.")]
        [Category("Contact Information")]
        public ContactInfoType Type { get; set; }

        [DisplayName("Contact Value")]
        [Description("The value of the contact information.")]
        [Category("Contact Information")]
        public string? Value { get; set; }
    }

    public enum ContactInfoType
    {
        [Description("Email Address")]
        Email,
        [Description("Phone Number")]
        Phone
    }
}