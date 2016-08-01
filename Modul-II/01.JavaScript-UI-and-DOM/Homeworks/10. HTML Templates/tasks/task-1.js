/* globals $ */

function solve() {

  return function (selector) {
    /* insert the template here as a string
         example:
         var template =
           '<ul>' +
             '{{#students}}' +
             '<li>' +
               '{{name}}' +
             '</li>' +
             '{{/students}}' +
           '</ul>';
     */

    var template = '<table class="items-table">' +
      '<thead>' +
      '<tr>' +
      '<th>#</th>' +
      '{{#headers}}' +
      '<th>{{this}}</th>' +
      '{{/headers}}' +
      '</tr>' +
      '</thead>' +
      '<tbody>' +
      '{{#items}}' +
      '<tr>' +
      '<td>{{@index}}</td>' +
      '<td>{{this.col1}}</td>' +
      '<td>{{this.col2}}</td>' +
      '<td>{{this.col3}}</td>' +
      '</tr>' +
      '{{/items}}' +
      '</tbody>' +
      '</table>';

    $(selector).html(template);
  };
}

module.exports = solve;