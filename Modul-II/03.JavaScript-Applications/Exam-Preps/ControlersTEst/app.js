import 'jquery';
import Print from 'test';

var container = $("#wrapper");

$('<h1 />').text("BAUSH").appendTo(container);

var pr = new Print();

pr.print('DA');