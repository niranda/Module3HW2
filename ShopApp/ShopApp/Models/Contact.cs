namespace ShopApp.Models
{
    public class Contact
    {
        public Contact(string fullName, string phoneNumber)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
