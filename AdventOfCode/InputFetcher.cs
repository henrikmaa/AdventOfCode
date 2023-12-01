
namespace AdventOfCode
{
    public class InputFetcher
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private readonly string? _sessionToken;

        public InputFetcher(string? sessionToken)
        {
            _sessionToken = sessionToken;
        }

        public async Task<string> FetchPuzzleInputAsync(int year, int day)
        {
            try
            {
                var url = $"https://adventofcode.com/{year}/day/{day}/input";
                
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Cookie", $"session={_sessionToken}");
                 
                var response = await HttpClient.SendAsync(request);
                
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Request was not successful. Status code = {response.StatusCode}");
                }
                
                var puzzleInput = await response.Content.ReadAsStringAsync();
                return puzzleInput;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch puzzle input: {ex.Message}");
                throw;
            }
        }
    }
}
