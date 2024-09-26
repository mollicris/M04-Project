using Microsoft.SemanticKernel;

string yourDeploymentName = "Implementaciogpt35";
string yourEndpoint = "https://semantickernellearn.openai.azure.com/";
string yourApiKey = "85f465e14d7d40c5bb992ecced2a8186";

var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
    yourDeploymentName,
    yourEndpoint,
    yourApiKey,
    "gpt-35-turbo");
var kernel = builder.Build();

kernel.ImportPluginFromType<MusicLibraryPlugin>();

string prompt = @"This is a list of music available to the user:
    {{MusicLibraryPlugin.GetMusicLibrary}}

    This is a list of music the user has recently played:

    {{MusicLibraryPlugin.GetRecentPlays}}
    
    Based on their recently played music, suggest a song from
    the list to play next";

var result = await kernel.InvokePromptAsync(prompt);

Console.WriteLine(result);