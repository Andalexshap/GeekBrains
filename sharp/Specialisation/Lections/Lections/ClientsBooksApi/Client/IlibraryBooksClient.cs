namespace ClientsBooksApi.Client
{
    public interface ILibraryBooksClient
    {
        public Task<bool> Exist(Guid id);

    }

    public class LibraryBooksClient : ILibraryBooksClient
    {
        readonly HttpClient client = new HttpClient();
        public async Task<bool> Exist(Guid id)
        {
            using HttpResponseMessage response = await client.GetAsync($"https://localhost:7136/Library/check_book?bookId={id.ToString()}");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody == "true")
                return false;

            if (responseBody == "false")
                return true;

            throw new Exception("Unknow response");
        }

    }
    public interface ILibraryUsersClient
    {
        public Task<bool> Exist(Guid id);
    }

    public class LibraryUsersClient : ILibraryUsersClient
    {
        readonly HttpClient client = new HttpClient();
        public async Task<bool> Exist(Guid id)
        {
            using HttpResponseMessage response = await client.GetAsync($"https://localhost:7145/User/exist?userId={id}");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody == "true")
                return false;
            if (responseBody == "false")
                return true;

            throw new Exception("Unknow response");
        }
    }
}
