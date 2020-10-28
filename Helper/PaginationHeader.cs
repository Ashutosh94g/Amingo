namespace Amingo.Helpers
{
	public class PaginationHeader
	{
		public int CurrentPage { get; set; }
		public int ItemsPerPage { get; set; }
		public int TotalItem { get; set; }
		public int TotalPages { get; set; }

		public PaginationHeader(int currentPage, int itemsPerPage, int totalItem, int totalPages)
		{
			CurrentPage = currentPage;
			ItemsPerPage = itemsPerPage;
			TotalItem = totalItem;
			TotalPages = totalPages;
		}
	}
}