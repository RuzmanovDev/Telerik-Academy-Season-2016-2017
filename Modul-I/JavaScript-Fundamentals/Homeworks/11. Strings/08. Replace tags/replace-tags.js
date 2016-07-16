function solve(args) {
    var regExTag = new RegExp('<a href="(.*?)">(.*?)</a>', "g");
   
    var newText = args[0].replace(regExTag, function (none, href, content) {
        
            return '[' + content + '](' + href + ')';      
    });

    console.log(newText);
}