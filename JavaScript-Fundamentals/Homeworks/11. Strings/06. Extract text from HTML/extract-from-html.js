function solve(args) {
    var input = args.slice(1);
    var result = input.map(e=>e.replace(/<(.*?)>/g, '').trim());
  
console.log(result.join("").trim());
}

var text = [
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
];

solve(text);