using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositorySongExtensions
    {
/*        public static IQueryable<Song> FilterSongs(this IQueryable<Song> Songs, uint minAge, uint maxAge) =>
            Songs.Where(e => (e.Name >= minAge && e.Age <= maxAge));

        public static IQueryable<Song> Search(this IQueryable<Song> Songs, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return Songs;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return Songs.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Song> Sort(this IQueryable<Song> Songs, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return Songs.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Song>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return Songs.OrderBy(e => e.Name);

            return Songs.OrderBy(orderQuery);
        }*/
    }
}
