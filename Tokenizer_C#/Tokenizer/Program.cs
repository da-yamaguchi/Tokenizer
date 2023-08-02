using System;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.DeepDev;
using Microsoft.Extensions.Configuration;

// var c = new ConfigurationBuilder()
//     .AddUserSecrets<Program>()
//     .Build();
var tokenizer = await TokenizerBuilder.CreateByModelNameAsync("gpt-3.5-turbo");

Console.WriteLine("トークンを数えたい文字列を入力してください。");
var input = Console.ReadLine()!.Trim();
var encoded = tokenizer.Encode(input, Array.Empty<string>());
Console.WriteLine($"{encoded.Count} tokens.");

var client = new OpenAIClient(
    // c.GetValue<Uri>("Endpoint"),
    // new AzureKeyCredential(c.GetValue<string>("Key")!));
    new Uri("endpointを直接"),
    new AzureKeyCredential("keyを直接"));
var result = await client.GetCompletionsAsync("デプロイ名を直接", new CompletionsOptions
{
    MaxTokens = 100,
    Prompts =
    {
        input,
    }
});

Console.WriteLine($"{result.Value.Usage.PromptTokens} tokens.");

