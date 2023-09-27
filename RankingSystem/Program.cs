using RankingSystem;

User user = new User();

Console.WriteLine(user.rank);
Console.WriteLine(user.progress);

user.incProgress(-1);

Console.WriteLine(user.progress);
Console.WriteLine(user.rank);