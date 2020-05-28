using SUBDLab5.BusinessLogic;
using SUBDLab5.Services;
using System;
using System.Diagnostics;

namespace SUBDLab5
{
    class Program
    {
        public static readonly NewsPortalDatabase db = new NewsPortalDatabase();
        static void Main(string[] args)
        {
            MainLogic logic = new MainLogic(new AuthorService(), new CategoryService(), new CommentService(), new NewsService(), new SubscriptionService(), new UsernameService());
            Insert(logic);
            NewsService newsLogic = new NewsService();
            Stopwatch clock = new Stopwatch();
            clock.Start();
            //logic.CreateUsername("aasdas", "AYdass!ff", "12312644");
            //logic.ReadUsername();
            //logic.UpdateUsername(6, "Tf", "Ta", "hga");
            //logic.DeleteUsername(6, "Tf", "Ta", "hga");
            //logic.UsernameComment();
            //logic.UserNewsComment();
            //logic.AuthorNews();
            //logic.OrderUsername();
            newsLogic.ReadStranichno(3, 1);
            clock.Stop();
            Console.WriteLine(clock.ElapsedMilliseconds);

        }
        public static void Insert(MainLogic logic)
        {
/*            logic.CreateAuthor("Ivan Petrov");
            logic.CreateAuthor("Petr Ivanov");

            logic.CreateCategory("Health");
            logic.CreateCategory("Auto");
            logic.CreateCategory("Politics");

            logic.CreateComment("VAuu", 1, 2);
            logic.CreateComment("Davno zamwetil chto politica ne ta stala", 2, 1);

            logic.CreateNews("Ukrali tualet", DateTime.Parse("11.07.2000"), 1, 3);
            logic.CreateNews("Novii VolksWagen polo za 10 rublei", DateTime.Parse("22.11.2000"), 1, 2);
            logic.CreateNews("Konstitucia obnovili)", DateTime.Parse("21.02.2021"), 2, 1);
            logic.CreateNews("Konstitucia otmenili)", DateTime.Parse("21.03.2021"), 2, 1);

            logic.CreateSubscription(1, 1);
            logic.CreateSubscription(2, 3);
            logic.CreateSubscription(3, 2);

            logic.CreateUsername("DOMINATOR777", "Alfkf", "123456");
            logic.CreateUsername("PESHKANAVALNOGO1", "KotYa883", "pasLol");
            logic.CreateUsername("OPOZICIA", "flflfl", "loveGames");
            logic.CreateUsername("babushkinirecepti", "salambrodyagi", "lovefTest");*/

        }

    }
}