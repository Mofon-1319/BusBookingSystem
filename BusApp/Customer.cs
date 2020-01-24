namespace BusApp
{
    class Customer
    {
        public string userName { get; set; }
        public string userId { get; set; }
        public string userPassword { get; set; }

        public string userPhone { get; set; }

        public int userAge { get; set; }

        public Customer()
        {

        }
        public Customer(string userId, string password)
        {
            this.userId = userId;
            this.userPassword = password;
        }
        public Customer(string name, string userId, string password, string phone, int age)
        {
            this.userName = name;
            this.userId = userId;
            this.userPassword = password;
            this.userPhone = phone;
            this.userAge = age;
        }
    }

    //class Admin
    //{
    //    public string adminName { get; set; }
    //    public string adminId { get; set; }
    //    public string adminPassword { get; set; }

    //    public string busFrom { get; set; }
    //    public string busTo { get; set; }
    //    public string busArrivalTime { get; set; }
    //    public string busDepartureTime { get; set; }
    //    public string busRate { get; set; }
    //    public Admin()
    //    {

    //    }
    //    public Admin(string name, string userId, string password)
    //    {
    //        this.adminName = name;
    //        this.adminId = userId;
    //        this.adminPassword = password;
    //    }

    //    public Admin(string from, string to, string arrTime, string depTime, string rate)
    //    {
    //        this.busFrom = from;
    //        this.busTo = to;
    //        this.busArrivalTime = arrTime;
    //        this.busDepartureTime = depTime;
    //        this.busRate = rate;
    //    }
    //}
}
