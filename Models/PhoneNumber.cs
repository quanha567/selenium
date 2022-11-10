namespace PhoneNumber.Models
{
    public class Phone
    {
        public int id { get; set; }
        public string phoneNumber { get; set; }
        public string name { get; set; }
        public string state { get; set; }

        public Phone() { }

        public Phone(int id, string phoneNumber)
        {
            this.id = id;
            this.phoneNumber = phoneNumber;
            this.state = "";
            this.name = "";
        }

        public Phone(int id, string phoneNumber, string name, string state)
        {
            this.id = id;
            this.phoneNumber = phoneNumber;
            this.name = name;
            this.state = state;
        }
    }
}
