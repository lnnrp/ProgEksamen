using System.Text;
using System.Text.Json;

namespace RESTService
{
    /// <summary>
    /// Needs seperate GameAPI running first to work!!
    /// </summary>
    public class Program
    {
        private static HttpClient httpClient;

        // Main is changed to be async task, so its able to await main loop 
        static async Task Main(string[] args)
        {
            Console.WriteLine("program started");
            Console.WriteLine("get: type 'get' to get all games or 'get 1' to get a specific game");
            Console.WriteLine("post: type 'post gameName genre year' to post a new game to the collection");
            Console.WriteLine("put: type 'put gameName genre year' to replace an exisiting games info");
            Console.WriteLine("patch: type 'patch gameName genre year' to replace an element for an exisiting game");
            Console.WriteLine("delete: type 'delete 1' to delete a specific game from the collection\n");


            SetupHttpClient();

            // Uses async/await as to not block everything while waiting for answer
            await MainLoop();

        }

        private static void SetupHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5000/api/games/"); // Base adress for the url
            httpClient.Timeout = TimeSpan.FromSeconds(10);
        }

        private static async Task MainLoop()
        {
            while (true)
            {
                var consoleInput = Console.ReadLine();
                if (consoleInput == null)
                    continue;
                string[] inputTokens = consoleInput.Split(new char[] { ' ' });


                List<string> tokens = inputTokens.Skip(1).ToList();
                switch (inputTokens[0])
                {
                    case "get":
                        await HandleGetAsync(tokens);
                        break;
                    case "post":
                        await HandlePost(tokens);
                        break;
                    case "put":
                        await HandlePut(tokens);
                        break;
                    case "patch":
                        await HandlePatch(tokens);
                        break;
                    case "delete":
                        await HandleDelete(tokens);
                        break;
                    default:
                        Console.Error.WriteLine("invalid command");
                        continue;
                }
            }
        }

        //Get only expects 1 param for specific or 0 for the full collection
        //ex: "get" for full collection or "get 1" for game with id 1
        private static async Task HandleGetAsync(List<string> tokens)
        {
            try
            {
                HttpResponseMessage responseGet = await httpClient.GetAsync((tokens.Count > 0) ? tokens[0] : "");
                if (responseGet.IsSuccessStatusCode)
                {
                    string content = await responseGet.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($" Get failed at {tokens[0]} with status code: {responseGet.StatusCode} - {responseGet.ReasonPhrase}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        //Post expects a URL and a 3 additional paramaters, title (token[0]), genre(token[1]) and release year(token[2]).
        //ex: "post tombRaider action 1996" NOTE: game cant contain spaces... I was lazy... Don't judge me.
        private static async Task HandlePost(List<string> tokens)
        {
            try
            {
                //Post expects and URL and a 3 additional paramaters, title, genre adn release year.
                if (tokens.Count < 3)
                {
                    Console.WriteLine("incorrect amount of parameters for Game Object");
                    return;
                }
                GameDto gameObj = new GameDto() { Title = tokens[0], Genre = tokens[1], ReleaseYear = int.Parse(tokens[2]) };

                var jsonData = JsonSerializer.Serialize(gameObj);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    // Håndter succesresponsen
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"POST-anmodning lykkedes. Respons: {responseContent}");
                }
                else
                {
                    // Håndter fejlresponsen (statuskode er ikke 2xx)
                    Console.WriteLine($"POST-anmodning mislykkedes. Statuskode: {response.StatusCode}");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Put expects 1 param for id and 3 params for game 
        //ex: "put 1 tombRaider action 1996"
        private static async Task HandlePut(List<string> tokens)
        {
            try
            {
                if (tokens.Count < 4)
                {
                    Console.WriteLine("incorrect amount of parameters for Game Object");
                    return;
                }
                GameDto gameObj = new GameDto() { Title = tokens[1], Genre = tokens[2], ReleaseYear = int.Parse(tokens[3]) };

                var jsonData = JsonSerializer.Serialize(gameObj);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage responsePut = await httpClient.PutAsync(tokens[0], content);

                if (responsePut.IsSuccessStatusCode)
                {
                    string contentAns = await responsePut.Content.ReadAsStringAsync();
                    Console.WriteLine(contentAns);
                }
                else
                {
                    Console.WriteLine(responsePut.StatusCode);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Patch expects 1 param for id and 3 for game (?) (maybe change to get specific?
        //ex: patch 1 tombRaider horror 1996
        private static async Task HandlePatch(List<string> tokens)
        {
            try
            {
                if (tokens.Count < 4)
                {
                    Console.WriteLine("incorrect amount of parameters for Game Object");
                    return;
                }
                GameDto gameObj = new GameDto() { Title = tokens[1], Genre = tokens[2], ReleaseYear = int.Parse(tokens[3]) };

                var jsonData = JsonSerializer.Serialize(gameObj);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage responsePatch = await httpClient.PatchAsync(tokens[0], content);

                if (responsePatch.IsSuccessStatusCode)
                {
                    string contentAns = await responsePatch.Content.ReadAsStringAsync();
                    Console.WriteLine(contentAns);
                }
                else
                {
                    Console.WriteLine(responsePatch.StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Delete expects 1 param for specific 
        //ex: "delete 1" to delete game 1 from the collection
        private static async Task HandleDelete(List<string> tokens)
        {
            try
            {
                HttpResponseMessage responseGet = await httpClient.DeleteAsync(tokens[0]);
                string content = await responseGet.Content.ReadAsStringAsync();
                if (responseGet.IsSuccessStatusCode)
                {
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine(responseGet.StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}