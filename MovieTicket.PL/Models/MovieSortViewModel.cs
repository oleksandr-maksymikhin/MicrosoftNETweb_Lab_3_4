namespace MovieTicket.PL.Models
{
    public class MovieSortViewModel
    {
        public SortState TitleSort { get; }
        public SortState DirectorSort { get; }
        public SortState GenreSort { get; }
        public SortState DateSort { get; }
        public SortState Current { get; }

        public MovieSortViewModel(SortState sortOrder)
        {
            TitleSort = sortOrder == SortState.TitleAsc ? SortState.TitleDesc : SortState.TitleAsc;
            DirectorSort = sortOrder == SortState.DirectorAsc ? SortState.DirectorDesc : SortState.DirectorAsc;
            GenreSort = sortOrder == SortState.GenreAsc ? SortState.GenreDesc : SortState.GenreAsc;
            DateSort = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            Current = sortOrder;
        }
    }
}
