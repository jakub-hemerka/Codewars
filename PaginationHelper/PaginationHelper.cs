namespace PaginationHelper;
public class PaginationHelper<T>
{
    private readonly IList<T> _collection;
    private readonly int _itemsPerPage;

    /// <summary>
    /// Constructor, takes in a list of items and the number of items that fit within a single page
    /// </summary>
    /// <param name="collection">A list of items</param>
    /// <param name="itemsPerPage">The number of items that fit within a single page</param>
    public PaginationHelper(IList<T> collection, int itemsPerPage)
    {
        _collection = collection;
        _itemsPerPage = itemsPerPage;
    }

    /// <summary>
    /// The number of items within the collection
    /// </summary>
    public int ItemCount => _collection.Count;

    /// <summary>
    /// The number of pages
    /// </summary>
    public int PageCount => (int)Math.Ceiling(_collection.Count / (double)_itemsPerPage);

    /// <summary>
    /// Returns the number of items in the page at the given page index 
    /// </summary>
    /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
    /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
    public int PageItemCount(int pageIndex)
    {
        if (pageIndex >= PageCount || pageIndex < 0)
        {
            return -1;
        }

        if (pageIndex < PageCount - 1)
        {
            return _itemsPerPage;
        }

        return _collection.Count % _itemsPerPage == 0 ? _itemsPerPage : _collection.Count % _itemsPerPage;
    }

    /// <summary>
    /// Returns the page index of the page containing the item at the given item index.
    /// </summary>
    /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
    /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
    public int PageIndex(int itemIndex)
    {
        if (itemIndex >= ItemCount || itemIndex < 0)
        {
            return -1;
        }

        int result = -1;

        for (int i = 0; i < ItemCount; i += _itemsPerPage)
        {
            if (i <= itemIndex)
            {
                result += 1;
            }
        }

        return result;
    }
}