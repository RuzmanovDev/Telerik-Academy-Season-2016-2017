function solve(args) {
    var rc = args[0].split(' ').map(Number),
    rows = rc[0],
    cols = rc[1],
    r,
    c,
    direction,
    deltaRow,
    deltaCol,
    sum,
    currentLine,
    field = args.slice(1).map(function(line) {
      return line.split(' ');
    }),

    // slow
    // for(r = 0; r < rows; r +=1){
    //     field[r] = [];
    //     currentLine = args[1+r].split(' ');
    //     for(c=0; c < cols ; c += 1 ){
    //     field[r][c]= currentLine[c];
    //     }
    // }

    sum = 0;
    r=0;
    c=0;
    sum+=1;

    while (true) {
        // get dir
         direction = field[r][c];
         // callculate next dir
        deltaRow = direction[0]==='d'? 1 :-1;
        deltaCol = direction[1] ==='l'? -1 : +1;
        // set the dir as visited
        field[r][c]='v';
        // callculate next dir
        r+=deltaRow;
        c+=deltaCol;
        // is it visited or is it out break
        if(r>=rows || c>=cols || r<0 || c<0){
            console.log('successed with ' + sum);
            return;
        }
        if(field[r][c]==='v'){
            console.log('failed at (' + r +', '+c+')');
            return;
        }
        sum += function(r,c){
              return (1 << r) + c;
        }(r,c);
        
    }
}

var args =[
  '3 5',
  'dr dl dr ur ul',
  'dr dr ul ur ur',
  'dl dr ur dl ur'   
];

solve(args);
