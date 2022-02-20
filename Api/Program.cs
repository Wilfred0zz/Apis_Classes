using System;

interface IProflieInterface<T>
{
    void ProfileInfo(T obj); 

}

interface User
{
    string name { get; set; }
    int age { get; set; }
    char gender { get; set; }
}

public class newUserProfile: User
{
    public string name { get; set; }
    public int age { get; set; }
    public char gender { get; set; }

};

public class SetUserProfileInfo: IProflieInterface<newUserProfile>
{

    //delegate definition
    public delegate void SettingProfileEventHandler(object source, EventArgs e);

    //event declaration
    public event SettingProfileEventHandler ProfileSet;

     public void ProfileInfo(newUserProfile newUserProfileInfo)
    {
        Console.WriteLine($"Creating new user account so that you can experience the world of socials '{newUserProfileInfo.name}', Loading.. ");
        Thread.Sleep(2000);
        Console.WriteLine($"Adding your age '{newUserProfileInfo.age}'... ");


        Console.WriteLine($"Saving gender '{newUserProfileInfo.gender}'.... \n");
        Thread.Sleep(2000);


        OnProfileSet();
    }

    protected virtual void OnProfileSet()
    {
        if (ProfileSet != null)
            ProfileSet(this, EventArgs.Empty);
    }
}

public class MessageUserProfileSet
{
    public void OnProfileSet(object source, EventArgs e)
    {
        Console.WriteLine("Congratulations your profile has been set! Have fun socializing!!!");
    }
}


class ProfileId<T>
{
    private T[] arr = new T[5];
    public T this[int i]
    {
        get { return arr[i]; }
        set { arr[i] = value; }
    }
}


class Program
{
    static void Main(string[] args)
    {
        var userProfile = new newUserProfile { name = "Wilfredo", age = 21, gender = 'M' };
        var setUpProfile = new SetUserProfileInfo();
        var userNotification = new MessageUserProfileSet();//subscriber
        var userId = new ProfileId<int>();
        userId[0] = 3;


        setUpProfile.ProfileSet += userNotification.OnProfileSet;
        setUpProfile.ProfileInfo(userProfile);
        
        Console.WriteLine($"Your UserId is... {userId[0]}");


        Console.ReadKey();


       
        //Console.WriteLine("Hello, Acitivity 4!");

    }
}