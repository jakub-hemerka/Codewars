using PaginationHelper;

IList<char> collection = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f' };
//IList<string> collection = Array.Empty<string>();

PaginationHelper<char> helper = new(collection, 4);


delegate ResultCallBack<int response>;

Console.WriteLine(helper.ItemCount);
Console.WriteLine(helper.PageCount);
Console.WriteLine(helper.PageItemCount(0));
Console.WriteLine(helper.PageItemCount(1));
Console.WriteLine(helper.PageItemCount(2));

Console.WriteLine(helper.PageIndex(0));
Console.WriteLine(helper.PageIndex(5));
Console.WriteLine(helper.PageIndex(2));
Console.WriteLine(helper.PageIndex(20));
Console.WriteLine(helper.PageIndex(-10));