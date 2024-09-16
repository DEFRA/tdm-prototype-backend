# tdm-prototype-backend

Core delivery C# ASP.NET backend template.

### Install MongoDB
- Install [MongoDB](https://www.mongodb.com/docs/manual/tutorial/#installation) on your local machine
- Start MongoDB:
```bash
sudo mongod --dbpath ~/mongodb-cdp
```

### Inspect MongoDB

To inspect the Database and Collections locally:
```bash
mongosh
```

### Testing

Run the tests with:

Tests run by running a full `WebApplication` backed by [Ephemeral MongoDB](https://github.com/asimmon/ephemeral-mongo).
Tests do not use mocking of any sort and read and write from the in-memory database.

```bash
dotnet test
````

### Running

Run CDP-Deployments application:
```bash
dotnet run --project TdmPrototypeBackend --launch-profile Development
```

### Testing push

# tdm-prototype-backend-cli
This is a git style command line interface to be able to quickly automate common tasks that can be run manually or automated.

## Project Dependencies

|Package| Description  |
|--|--|
| [CommandLineParser](https://github.com/commandlineparser/commandline)| Used for parsing command line arguments  |
| [MediatR](https://github.com/jbogard/MediatR) | Used as a mediator to segregate the commands the CLI will support  |
| [Humanizer](https://github.com/Humanizr/Humanizer)| Used for converting strings |
| [RazorLight](https://github.com/toddams/RazorLight)| Used for the templating engine for generating CSharp classes |
| [JsonSchema.Net](https://github.com/jsonsystems/json-schema)| Used to convert the JsonSchema into an object model to be parsed |

## Commands
### generate-csharp-from-json-schema

|Verb| Description  |
|--|--|
|generate-csharp-from-json-schema  | Generates Csharp classes from Json Schema. |

|Option| Description  |
|--|--|
| -s, --schema  | The Json schema file, which to use to generate the csharp classes. |
| -o, --outputPath   | The path to save the generated csharp classes. |


### Example

    generate-csharp-from-json-schema --schema C:\jsonschema.json --outputPath C:\output
