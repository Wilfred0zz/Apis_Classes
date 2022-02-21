namespace UsersApi
{
    public class User : IProfile
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }

        public void PrintInfoEntered()
        {
            Console.WriteLine($"Your name is: {Name}, Your age is: {Age}, Your Gender is: {Gender}, Your Email is  {Email}");
        }


        //delegate definition
        public delegate void UserAddedEventHandler(object source, EventArgs e);

        //event declaration
        public event EventHandler UserAdded;


        public void CreateUser()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Creating new user account so that you can experience the world of socials, Loading...");
            Thread.Sleep(1000);
            Console.WriteLine("Loading .......");
            Thread.Sleep(2000);
            OnCreateUser();
        }

        protected virtual void OnCreateUser()
        {
            if (UserAdded != null)
                UserAdded(this, EventArgs.Empty);
        }

        //indexer
        private int[] arr = new int[5];
        public int this[int profileId]
        { get => arr[profileId]; set => arr[profileId] = value; }

    }

    public class MessageUserProfileSet
    {
        public void OnProfileSet(object source, EventArgs e)
        {
            Console.WriteLine("Congratulations your profile has been set! Have fun socializing!!!");
            Thread.Sleep(1000);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User userProfile = new User { Name = "Wilfredo", Age = 21, Gender = 'M', Email = "lol@gmail.com" };

            userProfile.PrintInfoEntered();

            var userNotification = new MessageUserProfileSet();//subscriber
            userProfile[0] = 3;


            userProfile.UserAdded += userNotification.OnProfileSet!;
            userProfile.CreateUser();

            Console.WriteLine($"Your UserId is... {userProfile[0]}");


            Console.ReadKey();


            Console.WriteLine("Hello, Acitivity 4!");

        }
    }



}