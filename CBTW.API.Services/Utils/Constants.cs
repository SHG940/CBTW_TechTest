namespace CBTW.API.Services.Utils;

public static class Constants
{
    public const string BookExtractionInfoBasePrompt = """
                                      Extract the key information of the following input related to a book;
                                      the key information I want you to extract is the following: 'author', 'title', 'keywords', and 'matchReason' which contains a small description of why matched (max 2 sentences).
                                      The way I want you to give me the information is in minimized JSON format as the following example (the json object only):
                                      {'title':'Moby Dick','author':'Herman Melville','keywords':['Adventure Fiction','1851-10-18','Whale','Sea','Ahab Captain'],'matchReason':'Exact title match; Herman Melville is primary author; Action fiction is the gender of the novel; 1851-10-18 is the publish date; Whale, Sea, and Ahab Captain are characters and locations'}.
                                      In case that you can't find the title or the author, try to guess the title or the author based on the extracted keywords,
                                      in that scenario return just "not found"
                                      Input: {{text}}
                                      """;
}