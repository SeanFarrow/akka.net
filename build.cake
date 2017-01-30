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

//To keep cake happy, think this is a bug.
Task("Default")
.IsDependentOn("Help");

RunTarget(target);
