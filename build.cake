var target = Argument("target", "Help");
var configuration = Argument<string>("configuration", "Release");

//--------------------------------------------------------------------------------
// Help 
//--------------------------------------------------------------------------------

Task("Help")
    .Does(() =>
{
      Information("usage:");
      Information("build [target]");
      Information("");
      Information(" Targets for building:");
      Information(" * Build      Builds");
      Information(" * Nuget      Create and optionally publish nugets packages");
      Information(" * RunTests   Runs tests");
      Information(" * MultiNodeTests  Runs the slower multiple node specifications");
      Information(" * All        Builds, run tests, creates and optionally publish nuget packages");
      Information("");
      Information(" Other Targets");
      Information(" * Help       Display this help"); 
      Information(" * HelpNuget  Display help about creating and pushing nuget packages"); 
      Information(" * HelpDocs   Display help about creating and pushing API docs");
      Information(" * HelpMultiNodeTests  Display help about running the multiple node specifications");
      Information("");
});

Task("HelpNuget")
    .Does(() =>
{
      Information("usage: ");
      Information("build Nuget [nugetkey=<key> [nugetpublishurl=<url>]] ");
      Information("            [symbolskey=<key> symbolspublishurl=<url>] ");
      Information("            [nugetprerelease=<prefix>]");
      Information("");
      Information("Arguments for Nuget target:");
      Information("   nugetprerelease=<prefix>   Creates a pre-release package.");
      Information("                              The version will be version-prefix<date>");
      Information("                              Example: nugetprerelease=dev =>");
      Information("                                       0.6.3-dev1408191917");
      Information("");
      Information("In order to publish a nuget package, keys must be specified.");
      Information("If a key is not specified the nuget packages will only be created on disk");
      Information("After a build you can find them in bin/nuget");
      Information("");
      Information("For pushing nuget packages to nuget.org and symbols to symbolsource.org");
      Information("you need to specify nugetkey=<key>");
      Information("   build Nuget nugetKey=<key for nuget.org>");
      Information("");
      Information("For pushing the ordinary nuget packages to another place than nuget.org specify the url");
      Information("  nugetkey=<key>  nugetpublishurl=<url>  ");
      Information("");
      Information("For pushing symbols packages specify:");
      Information("  symbolskey=<key>  symbolspublishurl=<url> ");
     Information("");
      Information("Examples:");
      Information("  build Nuget                      Build nuget packages to the bin/nuget folder");
      Information("");
      Information("  build Nuget nugetprerelease=dev  Build pre-release nuget packages");
      Information("");
      Information("  build Nuget nugetkey=123         Build and publish to nuget.org and symbolsource.org");
      Information("");
      Information("  build Nuget nugetprerelease=dev nugetkey=123 nugetpublishurl=http://abc");
      Information("              symbolskey=456 symbolspublishurl=http://xyz");
      Information("                                   Build and publish pre-release nuget packages to http://abc");
      Information("                                   and symbols packages to http://xyz");
      Information("");
});

Task("HelpDocs")
.Does(() =>
{
      Information("usage: ");
      Information("build Docs");
      Information("Just builds the API docs for Akka.NET locally. Does not attempt to publish.");
      Information("");
      Information("build PublishDocs azureKey=<key> ");
      Information("                  azureUrl=<url> ");
      Information("                 [unstable=true]");
      Information("");
      Information("Arguments for PublishDocs target:");
      Information("   azureKey=<key>             Azure blob storage key.");
      Information("                              Used to authenticate to the storage account.");
      Information("");
      Information("   azureUrl=<url>             Base URL for Azure storage container.");
      Information("                              FAKE will automatically set container");
      Information("                              names based on build parameters.");
      Information("");
      Information("   [unstable=true]            Indicates that we'll publish to an Azure");
      Information("                              container named 'unstable'. If this param");
      Information("                              is not present we'll publish to containers");
      Information("                              'stable' and the 'release.version'");
      Information("");
      Information("In order to publish documentation all of these values must be provided.");
      Information("Examples:");
      Information("  build PublishDocs azureKey=1s9HSAHA+...");
      Information("                    azureUrl=http://fooaccount.blob.core.windows.net/docs");
      Information("                                   Build and publish docs to http://fooaccount.blob.core.windows.net/docs/stable");
      Information("                                   and http://fooaccount.blob.core.windows.net/docs/{release.version}");
      Information("");
      Information("  build PublishDocs azureKey=1s9HSAHA+...");
      Information("                    azureUrl=http://fooaccount.blob.core.windows.net/docs");
      Information("                    unstable=true");
      Information("                                   Build and publish docs to http://fooaccount.blob.core.windows.net/docs/unstable");
      Information("");
});

//To keep cake happy, think this is a bug.
Task("Default")
.IsDependentOn("Help");

RunTarget(target);
