function smallest(args) {
    var elements = Object.getOwnPropertyNames(args);


    elements.sort();
    console.log("Element " + args.toString());
    console.log("Lexicographically first: " + elements[0] + " and last: " + elements[elements.length - 1]);
    console.log();
}
smallest(window);
smallest(navigator);
smallest(document);