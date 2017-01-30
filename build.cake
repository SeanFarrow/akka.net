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
//To keep cake happy, think this is a bug.
Task("Default")
.IsDependentOn("Help");

RunTarget(target);
